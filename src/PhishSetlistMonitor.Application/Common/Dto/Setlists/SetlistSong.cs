namespace PhishSetlistMonitor.Application.Common.Dto.Setlists;

public record SetlistSong
{
    public int SongPosition { get; init; }
    public int SetNumber { get; init; }
    public string SongName { get; init; }
};
