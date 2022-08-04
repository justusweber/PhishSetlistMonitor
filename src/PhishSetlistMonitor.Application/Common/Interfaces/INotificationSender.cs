namespace PhishSetlistMonitor.Application.Common.Interfaces;

public interface INotificationSender
{
    Task SendPhishSetlistNotificationAsync();
}
