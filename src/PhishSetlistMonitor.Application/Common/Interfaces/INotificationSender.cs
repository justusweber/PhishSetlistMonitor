using PhishSetlistMonitor.Application.Common.Dto.Mailjet;

namespace PhishSetlistMonitor.Application.Common.Interfaces;

public interface INotificationSender
{
    Task<bool> SendPhishSetlistNotificationAsync(MailjetEmail mailjetEmail, CancellationToken cancellationToken);
}
