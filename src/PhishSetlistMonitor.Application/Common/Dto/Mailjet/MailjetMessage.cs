namespace PhishSetlistMonitor.Application.Common.Dto.Mailjet;

public record MailjetMessage
{
    public MailjetFrom From { get; init; }
    public MailjetRecipient To { get; init; }
    public string Subject { get; init; }
    public string TextPart { get; init; }
}
