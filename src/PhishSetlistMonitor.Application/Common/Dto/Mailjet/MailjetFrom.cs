namespace PhishSetlistMonitor.Application.Common.Dto.Mailjet;

public record MailjetFrom(string Email, string Name) : MailjetEmailContact(Email, Name);
