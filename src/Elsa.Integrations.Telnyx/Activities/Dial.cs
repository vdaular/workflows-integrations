using System.Runtime.CompilerServices;
using Elsa.Extensions;
using Elsa.Integrations.Telnyx.Client.Models;
using Elsa.Integrations.Telnyx.Client.Services;
using Elsa.Integrations.Telnyx.Exceptions;
using Elsa.Integrations.Telnyx.Extensions;
using Elsa.Integrations.Telnyx.Options;
using Elsa.Workflows;
using Elsa.Workflows.Attributes;
using Elsa.Workflows.Models;
using Elsa.Workflows.UIHints;
using Microsoft.Extensions.Options;

namespace Elsa.Integrations.Telnyx.Activities;

/// <summary>
/// Dial a number or SIP URI.
/// </summary>
[Activity(Constants.Namespace, "Dial a number or SIP URI.", Kind = ActivityKind.Task)]
public class Dial : CodeActivity<DialResponse>
{
    /// <inheritdoc />
    public Dial([CallerFilePath] string? source = null, [CallerLineNumber] int? line = null) : base(source, line)
    {
    }

    /// <summary>
    /// The DID or SIP URI to dial out and bridge to the given call.
    /// </summary>
    [Input(Description = "The DID or SIP URI to dial out and bridge to the given call.")]
    public Input<string> To { get; set; } = null!;

    /// <summary>
    /// The 'from' number to be used as the caller id presented to the destination ('To' number). The number should be in +E164 format. This attribute will default to the 'From' number of the original call if omitted.
    /// </summary>
    [Input(Description = "The 'from' number to be used as the caller id presented to the destination ('To' number). The number should be in +E164 format. This attribute will default to the 'From' number of the original call if omitted.")]
    public Input<string?> From { get; set; } = null!;

    /// <summary>
    /// The string to be used as the caller id name (SIP From Display Name) presented to the destination ('To' number). The string should have a maximum of 128 characters, containing only letters, numbers, spaces, and -_~!.+ special characters. If omitted, the display name will be the same as the number in the 'From' field.
    /// </summary>
    [Input(Description =
        "The string to be used as the caller id name (SIP From Display Name) presented to the destination ('To' number). The string should have a maximum of 128 characters, containing only letters, numbers, spaces, and -_~!.+ special characters. If omitted, the display name will be the same as the number in the 'From' field.")]
    public Input<string?> FromDisplayName { get; set; } = null!;

    /// <summary>
    /// Enables answering machine detection.
    /// </summary>
    [Input(
        Description = "Enables answering machine detection.",
        UIHint = InputUIHints.DropDown,
        Options = new[] { "disabled", "detect", "detect_beep", "detect_words", "greeting_end", "premium" },
        DefaultValue = "disabled")]
    public Input<string?> AnsweringMachineDetection { get; set; } = new("disabled");

    /// <summary>
    /// Start recording automatically after an event. Disabled by default.
    /// </summary>
    [Input(Description = "Start recording automatically after an event. Disabled by default.")]
    public Input<bool> Record { get; set; } = null!;

    /// <summary>
    /// Defines the format of the recording ('wav' or 'mp3') when `record` is specified.
    /// </summary>
    [Input(
        Description = "Defines the format of the recording ('wav' or 'mp3') when `record` is specified.",
        UIHint = InputUIHints.DropDown,
        Options = new[] { "wav", "mp3" },
        DefaultValue = "mp3"
    )]
    public Input<string> RecordFormat { get; set; } = new("mp3");

    /// <inheritdoc />
    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var response = await DialAsync(context);
        Result.Set(context, response);
    }

    private async Task<DialResponse> DialAsync(ActivityExecutionContext context)
    {
        var telnyxOptions = context.GetRequiredService<IOptions<TelnyxOptions>>().Value;
        var callControlAppId = telnyxOptions.CallControlAppId;

        if (callControlAppId == null)
            throw new MissingCallControlAppIdException("No Call Control ID configured");

        var fromNumber = From.GetOrDefault(context);
        var clientState = context.CreateCorrelatingClientState();

        var request = new DialRequest(
            callControlAppId,
            To.Get(context),
            fromNumber,
            FromDisplayName.GetOrDefault(context).SanitizeCallerName(),
            AnsweringMachineDetection.GetOrDefault(context),
            Record: Record.GetOrDefault(context) ? "record-from-answer" : null,
            RecordFormat: RecordFormat.GetOrDefault(context) ?? "mp3",
            ClientState: clientState
        );

        var telnyxClient = context.GetRequiredService<ITelnyxClient>();
        var response = await telnyxClient.Calls.DialAsync(request, context.CancellationToken);

        return response.Data;
    }
}