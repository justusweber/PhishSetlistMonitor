using MediatR;
using PhishSetlistMonitor.Application.Common.Dto.Mailjet;

namespace PhishSetlistMonitor.Application.PollSetlists.Commands;

public record SendNotificationCommand(MailjetEmail MailjetEmail) : IRequest<bool>;
