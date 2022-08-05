namespace PhishSetlistMonitor.Application.Common.Dto.Mailjet;

public record MailjetRecipient(string Email, string Name) : MailjetEmailContact(Email, Name);
