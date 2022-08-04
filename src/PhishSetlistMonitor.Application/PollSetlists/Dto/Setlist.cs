namespace PhishSetlistMonitor.Application.PollSetlists.Dto;

public record Setlist
{
    public string ShowName { get; init; }
    public DateOnly ShowDate { get; init; }
    public IReadOnlyCollection<SetlistSong> SetlistSongs { get; init; }
}
