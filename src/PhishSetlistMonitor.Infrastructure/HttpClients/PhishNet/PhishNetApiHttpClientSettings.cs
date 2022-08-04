namespace PhishSetlistMonitor.Infrastructure.HttpClients.PhishNet;

public record PhishNetApiHttpClientSettings
{
    public string PhishNetApiBaseUrl { get; init; }
    public string ApiKey { get; init; }
}
