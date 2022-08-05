namespace PhishSetlistMonitor.Application.Common.Dto.Mailjet;

public record MailjetEmail
{
    public MailjetMessage MailjetMessage { get; init; }
}
