using System.Text.Json.Serialization;

namespace BWE8LT.Model;

public class Command
{
    [JsonPropertyName("Type")]
    public required string Type { get; set; }
    
    [JsonPropertyName("Key")]
    public required string Key { get; set; }

    [JsonPropertyName("Action")]
    public required string Action { get; set; }
}