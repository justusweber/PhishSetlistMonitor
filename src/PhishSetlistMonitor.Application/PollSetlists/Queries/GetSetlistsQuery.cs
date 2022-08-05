using MediatR;
using PhishSetlistMonitor.Application.Common.Dto;
using PhishSetlistMonitor.Application.Common.Dto.Setlists;

namespace PhishSetlistMonitor.Application.PollSetlists.Queries;

public record GetSetlistsQuery(string EndpointKey, DateOnly ShowDate) : IRequest<Setlist>;
