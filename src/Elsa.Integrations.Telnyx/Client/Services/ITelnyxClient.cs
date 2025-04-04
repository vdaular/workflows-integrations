﻿namespace Elsa.Integrations.Telnyx.Client.Services;

public interface ITelnyxClient
{
    ICallsApi Calls { get; }
    INumberLookupApi NumberLookup { get; }
}