namespace PhishSetlistMonitor.Application.Common.Dto.Setlists;

public record Setlist
{
    public string Venue { get; init; }
    public DateOnly ShowDate { get; init; }
    public string Soundcheck { get; init; }
    public IReadOnlyCollection<SetlistSong> SetlistSongs { get; init; }
}
