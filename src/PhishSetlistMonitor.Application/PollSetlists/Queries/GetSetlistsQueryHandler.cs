using MediatR;
using Microsoft.Extensions.Logging;
using PhishSetlistMonitor.Application.Common.Dto;
using PhishSetlistMonitor.Application.Common.Dto.Setlists;
using PhishSetlistMonitor.Application.Common.Interfaces;
using PhishSetlistMonitor.Application.PollSetlists.Dto.PhishNet;
using PhishSetlistMonitor.Application.PollSetlists.Mappers;

namespace PhishSetlistMonitor.Application.PollSetlists.Queries;

public class GetSetlistsQueryHandler : IRequestHandler<GetSetlistsQuery, Setlist>
{
    private readonly ILogger<GetSetlistsQueryHandler> _logger;
    private readonly IRemoteSetlistClient _remoteSetlistClient;

    public GetSetlistsQueryHandler(ILogger<GetSetlistsQueryHandler> logger, IRemoteSetlistClient remoteSetlistClient)
    {
        _logger = logger;
        _remoteSetlistClient = remoteSetlistClient;
    }

    public async Task<Setlist> Handle(GetSetlistsQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var apiParameters = new Dictionary<string, string> {{"showDate", request.ShowDate.ToString("yyyy-MM-dd")}};
            var setlist = await _remoteSetlistClient.GetPhishNetApiDataAsync<PhishNetShowSetlist>(request.EndpointKey, apiParameters, cancellationToken);
            return SetlistMapper.Map(setlist);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in {HandlerName}", nameof(GetSetlistsQueryHandler));
            return new Setlist();
        }
    }
}
