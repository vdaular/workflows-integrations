using Elsa.Integrations.Telnyx.Attributes;

namespace Elsa.Integrations.Telnyx.Payloads.Call;

[WebhookActivity(
    WebhookEventTypes.CallMachinePremiumGreetingEnded, 
    WebhookActivityTypeNames.CallMachinePremiumGreetingEnded, 
    "Call Machine Premium Greeting Ended", 
    "Triggered when a machine greeting has ended."
)]
public sealed record CallMachinePremiumGreetingEnded : CallMachineGreetingEndedBase;