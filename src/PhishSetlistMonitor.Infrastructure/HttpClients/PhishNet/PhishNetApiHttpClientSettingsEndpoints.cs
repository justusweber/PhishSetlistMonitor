namespace PhishSetlistMonitor.Infrastructure.HttpClients.PhishNet;

public record PhishNetApiHttpClientSettingsEndpoints
{
    public Dictionary<string, string> Endpoints { get; init; }
}
