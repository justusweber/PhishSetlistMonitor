using PhishSetlistMonitor.Application.Common.Dto;
using PhishSetlistMonitor.Application.Common.Dto.Setlists;
using PhishSetlistMonitor.Application.PollSetlists.Dto.PhishNet;

namespace PhishSetlistMonitor.Application.PollSetlists.Mappers;

public static class SetlistMapper
{
    public static Setlist Map(PhishNetShowSetlist phishNetShowSetlist)
    {
        var setlistSongs = phishNetShowSetlist.Songs.Select(song => new SetlistSong
        {
            SongPosition = song.SongPosition,
            SetNumber = song.SetNumber,
            SongName = song.Name
        });

        var venue = phishNetShowSetlist.Songs.FirstOrDefault()?.Venue ?? "Unknown Venue";
        var showDate = phishNetShowSetlist.Songs.FirstOrDefault()?.ShowDate ?? DateTime.MinValue;
        var soundcheck = phishNetShowSetlist.Songs.FirstOrDefault()?.Soundcheck ?? "N/A";
        return new Setlist
        {
            Venue = venue,
            ShowDate = DateOnly.FromDateTime(showDate),
            Soundcheck = soundcheck,
            SetlistSongs = setlistSongs
                .OrderBy(o => o.SetNumber)
                .ThenBy(o => o.SongPosition)
                .ToList()
        };
    }
}
