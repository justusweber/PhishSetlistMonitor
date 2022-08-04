using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PhishSetlistMonitor.Application.Common.Interfaces;
using System.Net.Http.Json;

namespace PhishSetlistMonitor.Infrastructure.HttpClients.PhishNet.PhishNetApi;

public class PhishNetClient : IRemoteSetlistClient
{
    private readonly ILogger<PhishNetClient> _logger;
    private readonly HttpClient _httpClient;
    private readonly PhishNetApiHttpClientSettings _phishNetApiHttpClientSettings;
    private readonly PhishNetApiHttpClientSettingsEndpoints _phishNetApiHttpClientSettingsEndpoints;

    public PhishNetClient(ILogger<PhishNetClient> logger,
        PhishNetApiHttpClient apiHttpClient,
        IOptions<PhishNetApiHttpClientSettings> phishNetHttpClientSettingsAccessor,
        IOptions<PhishNetApiHttpClientSettingsEndpoints> phishNetHttpClientSettingsEndpointsAccessor)
    {
        _logger = logger;
        _httpClient = apiHttpClient.Client;
        _phishNetApiHttpClientSettings = phishNetHttpClientSettingsAccessor.Value;
        _phishNetApiHttpClientSettingsEndpoints = phishNetHttpClientSettingsEndpointsAccessor.Value;
    }

    public async Task<T> GetPhishNetApiDataAsync<T>(string endpointKey,
        Dictionary<string, string> apiParameters,
        CancellationToken cancellationToken) where T : new()
    {
        try
        {
            return await MakeAuthorizedPhishNetApiDataRequestAsync<T>(endpointKey, apiParameters, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error performing an async Http GET operation in {nameof(PhishNetClient)}");
            return new T();
        }
    }

    private async Task<T> MakeAuthorizedPhishNetApiDataRequestAsync<T>(string endpointKey, Dictionary<string, string> apiParameters, CancellationToken cancellationToken) where T : new()
    {
        // from the endpoint key passed in, build the URL, and place into it the API secret key
        apiParameters["ApiKey"] = _phishNetApiHttpClientSettings.ApiKey;
        _phishNetApiHttpClientSettingsEndpoints.Endpoints.TryGetValue(endpointKey, out var url);
        if (url is null) return new T();

        var parameterizedUrl = url.BuildStringFromPattern(apiParameters);

        var jsonResponse = await _httpClient.GetFromJsonAsync<T>(parameterizedUrl, cancellationToken: cancellationToken);
        return jsonResponse ?? new T();
    }
}
