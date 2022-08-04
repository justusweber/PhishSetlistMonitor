using MediatR;
using PhishSetlistMonitor.Application.Common.Dto;

namespace PhishSetlistMonitor.Application.PollSetlists.Queries;

public record GetSetlistsQuery(string EndpointKey, DateOnly ShowDate) : IRequest<Setlist>;
