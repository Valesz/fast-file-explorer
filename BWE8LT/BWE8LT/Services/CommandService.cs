using System.Collections;
using System.Text.Json;
using System.Text.Json.Nodes;
using BWE8LT.Commands;
using BWE8LT.Model;
using BWE8LT.Utils;

namespace BWE8LT.Services;

public class CommandService
{
    private readonly string _configPath;
    
    public static HashSet<Command> Commands { get; } = new HashSet<Command>();

    public CommandService(string configPath)
    {
        _configPath = configPath;
    }
    
    public void LoadCommands()
    {
        string configText = File.ReadAllText(_configPath);

        var serializer = new JsonSerializerOptions
        {
            Converters = { new CommandConverter() }
        };
        
        CommandConfig config = JsonSerializer.Deserialize<CommandConfig>(configText, serializer);

        foreach (Command command in config.CommandsList)
        {
            ICommand.Commands.Add(command.Key, command.Action);
        }
    }
}