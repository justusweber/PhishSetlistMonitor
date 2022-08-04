using System.Text.Json.Serialization;

namespace PhishSetlistMonitor.Application.PollSetlists.Dto.PhishNet;

public record PhishNetShowSetlist
{
    [JsonPropertyName("data")]
    public IReadOnlyCollection<PhishNetSong> Songs { get; init; }
}
