using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.Extensions.Logging;
using PhishSetlistMonitor.Application.Common.Dto.Mailjet;
using PhishSetlistMonitor.Application.Common.Interfaces;

namespace PhishSetlistMonitor.Infrastructure.Notifications.Email.Mailjet;

public class PhishSetlistEmailSender : INotificationSender
{
    private readonly ILogger<PhishSetlistEmailSender> _logger;
    private readonly IMailjetClient _mailjetClient;

    public PhishSetlistEmailSender(ILogger<PhishSetlistEmailSender> logger,
        IMailjetClient mailjetClient)
    {
        _logger = logger;
        _mailjetClient = mailjetClient;
    }

    public async Task<bool> SendPhishSetlistNotificationAsync(MailjetEmail mailjetEmail, CancellationToken cancellationToken)
    {
        var request = new MailjetRequest { Resource = Send.Resource };
        request.Property(Send.FromEmail, mailjetEmail.MailjetMessage.From.Email);
        request.Property(Send.To, mailjetEmail.MailjetMessage.To.Email);
        request.Property(Send.Subject, mailjetEmail.MailjetMessage.Subject);
        request.Property(Send.TextPart, mailjetEmail.MailjetMessage.TextPart);

        var response = await _mailjetClient.PostAsync(request);
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine($"Total: {response.GetTotal()}, Count: {response.GetCount()}\n");
            Console.WriteLine(response.GetData());
            return true;
        }
        else
        {
            Console.WriteLine($"StatusCode: {response.StatusCode}\n");
            Console.WriteLine($"ErrorInfo: {response.GetErrorInfo()}\n");
            Console.WriteLine(response.GetData());
            return false;
        }
    }
}
