using System.Runtime.CompilerServices;
using Elsa.Workflows;
using Elsa.Workflows.Activities.Flowchart.Attributes;

namespace Elsa.Integrations.Telnyx.Activities;

/// <inheritdoc />
[FlowNode("Bridged", "Disconnected")]
public class FlowBridgeCalls : BridgeCallsBase
{
    /// <inheritdoc />
    public FlowBridgeCalls([CallerFilePath] string? source = null, [CallerLineNumber] int? line = null) : base(source, line)
    {
    }

    /// <inheritdoc />
    protected override ValueTask HandleDisconnectedAsync(ActivityExecutionContext context) => context.CompleteActivityAsync("Disconnected");

    /// <inheritdoc />
    protected override ValueTask HandleBridgedAsync(ActivityExecutionContext context) => context.CompleteActivityAsync("Bridged");
}