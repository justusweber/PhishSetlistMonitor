namespace PhishSetlistMonitor.BackgroundService.AppSettings;

public record PhishSetlistPollingServiceSettings
{
    public int PollFrequencySeconds { get; init; }
}
