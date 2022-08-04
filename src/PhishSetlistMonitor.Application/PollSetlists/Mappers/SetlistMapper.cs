using PhishSetlistMonitor.Application.Common.Dto;
using PhishSetlistMonitor.Application.PollSetlists.Dto.PhishNet;

namespace PhishSetlistMonitor.Application.PollSetlists.Mappers;

public static class SetlistMapper
{
    public static Setlist Map(PhishNetShowSetlist phishNetShowSetlist)
    {
        var setlistSongs = phishNetShowSetlist.Songs.Select(song => new SetlistSong
        {
            SongName = song.Name
        });

        var venue = phishNetShowSetlist.Songs.FirstOrDefault()?.Venue ?? "Unknown Venue";
        var showDate = phishNetShowSetlist.Songs.FirstOrDefault()?.ShowDate ?? DateTime.MinValue;
        return new Setlist
        {
            Venue = venue,
            ShowDate = showDate,
            SetlistSongs = setlistSongs.ToList()
        };
    }
}
