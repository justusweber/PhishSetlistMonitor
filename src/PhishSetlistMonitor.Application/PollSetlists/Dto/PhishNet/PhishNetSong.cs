using System.Text.Json.Serialization;

namespace PhishSetlistMonitor.Application.PollSetlists.Dto.PhishNet;

public record PhishNetSong
{
    [JsonPropertyName("set")]
    public string SetNumberString { get; init; }

    [JsonPropertyName("position")]
    public string SongPositionString { get; init; }

    [JsonPropertyName("venue")]
    public string Venue { get; set; }

    [JsonPropertyName("showdate")]
    public DateTime ShowDate { get; set; }

    [JsonPropertyName("soundcheck")]
    public string Soundcheck { get; init; }

    [JsonPropertyName("song")]
    public string Name { get; init; }

    public int SetNumber => int.TryParse(SetNumberString, out var setNumberAsInt) ? setNumberAsInt : 99;
    public int SongPosition => int.TryParse(SongPositionString, out var songPositionAsInt) ? songPositionAsInt : 0;
}
