using MediatR;
using PhishSetlistMonitor.Application.PollSetlists.Dto;

namespace PhishSetlistMonitor.Application.PollSetlists.Queries;

public class GetSetlistsQueryHandler : IRequestHandler<GetSetlistsQuery, IReadOnlyCollection<Setlist>>
{
    public GetSetlistsQueryHandler()
    {

    }

    public async Task<IReadOnlyCollection<Setlist>> Handle(GetSetlistsQuery request,
        CancellationToken cancellationToken)
    {
        await Task.Delay(1, cancellationToken);
        return Enumerable.Empty<Setlist>().ToList();
    }
}
