using System.Collections;
using System.Text.Json;
using System.Text.Json.Nodes;
using BWE8LT.Commands;
using BWE8LT.Model;
using BWE8LT.Utils;

namespace BWE8LT.Services;

public class CommandService
{
    private static CommandService _instance;

    public static CommandService Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new CommandService();
            }  
            
            return _instance;
        }
    }

    private CommandService()
    {
        
    }
    
    public void LoadCommands(string configPath)
    {
        string configText = File.ReadAllText(configPath);

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

    public ConsoleKey ReadCommandKey()
    {
        return Console.ReadKey(true).Key;
    }

    public void ExecuteCommand(ConsoleKey commandKey)
    {
        try
        {
            ICommand.Commands[commandKey].Invoke(commandKey);
        }
        catch (KeyNotFoundException ex)
        {
            Console.Error.WriteLine(ex.Message);
        }
    }
}