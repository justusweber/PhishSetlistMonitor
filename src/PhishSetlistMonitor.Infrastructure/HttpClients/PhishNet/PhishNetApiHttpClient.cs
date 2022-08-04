namespace PhishSetlistMonitor.Infrastructure.HttpClients.PhishNet;

public class PhishNetApiHttpClient
{
    public readonly HttpClient Client;

    public PhishNetApiHttpClient(HttpClient client)
    {
        Client = client;
    }
}
