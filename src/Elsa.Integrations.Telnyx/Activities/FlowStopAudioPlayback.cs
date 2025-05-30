using System.Runtime.CompilerServices;
using Elsa.Workflows;
using Elsa.Workflows.Activities.Flowchart.Attributes;

namespace Elsa.Integrations.Telnyx.Activities;

/// <inheritdoc />
[FlowNode("Done", "Disconnected")]
public class FlowStopAudioPlayback : StopAudioPlaybackBase
{
    /// <inheritdoc />
    public FlowStopAudioPlayback([CallerFilePath] string? source = null, [CallerLineNumber] int? line = null) : base(source, line)
    {
    }
    
    /// <inheritdoc />
    protected override ValueTask HandleDoneAsync(ActivityExecutionContext context) => context.CompleteActivityWithOutcomesAsync("Done");

    /// <inheritdoc />
    protected override ValueTask HandleDisconnectedAsync(ActivityExecutionContext context) => context.CompleteActivityWithOutcomesAsync("Disconnected");
}