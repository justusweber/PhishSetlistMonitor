using MediatR;
using PhishSetlistMonitor.Application.PollSetlists.Dto;

namespace PhishSetlistMonitor.Application.PollSetlists.Queries;

public record GetSetlistsQuery : IRequest<IReadOnlyCollection<Setlist>>;
