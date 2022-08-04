using System.Text.Json.Serialization;

namespace PhishSetlistMonitor.Application.PollSetlists.Dto.PhishNet;

public record PhishNetSong
{
    [JsonPropertyName("venue")]
    public string Venue { get; set; }

    [JsonPropertyName("showdate")]
    public DateTime ShowDate { get; set; }

    [JsonPropertyName("song")]
    public string Name { get; init; }
}
