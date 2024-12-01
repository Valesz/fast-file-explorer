using System.Text.Json.Serialization;

namespace BWE8LT.Model.JSON_Parse_Objects;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "Type")]
[JsonDerivedType(typeof(KeyCommandJson), "KeyCommand")]
[JsonDerivedType(typeof(LineCommandJson), "LineCommand")]
public abstract class CommandJson
{
    [JsonPropertyName("Key")]
    public required string Key { get; set; }
    
    [JsonPropertyName("Action")] 
    public required string Action { get; set; }
}