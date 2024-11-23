using System.Text.Json;
using System.Text.Json.Serialization;
using BWE8LT.Commands;
using BWE8LT.Model;

namespace BWE8LT.Utils;

public class CommandConverter : JsonConverter<Command>
{
    public override Command? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        
        JsonElement root = document.RootElement;
        try
        {
            var key = Enum.Parse<ConsoleKey>(root.GetProperty("Key").GetString(), true);

            ICommand command = CommandFactory.CreateCommand(root.GetProperty("Action").GetString());

            return new Command
            {
                Key = key,
                Action = command.Execute,
            };
        }
        catch (ArgumentException ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public override void Write(Utf8JsonWriter writer, Command value, JsonSerializerOptions options)
    {
        //TODO: Implement
        throw new NotImplementedException();
    }
}