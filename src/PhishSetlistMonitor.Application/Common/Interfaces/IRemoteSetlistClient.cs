namespace PhishSetlistMonitor.Application.Common.Interfaces;

public interface IRemoteSetlistClient
{
    Task<T> GetPhishNetApiDataAsync<T>(string endpointKey,
        Dictionary<string, string> apiParameters,
        CancellationToken cancellationToken) where T : new();
}
