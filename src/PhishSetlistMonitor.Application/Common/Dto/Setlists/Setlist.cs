namespace PhishSetlistMonitor.Application.Common.Dto.Setlists;

public record Setlist
{
    public string Venue { get; init; }
    public DateTime ShowDate { get; init; }
    public IReadOnlyCollection<SetlistSong> SetlistSongs { get; init; }
}
