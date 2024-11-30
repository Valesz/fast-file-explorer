using System.Text.Json;

using BWE8LT.Commands;
using BWE8LT.Model;
using BWE8LT.Utils;

namespace BWE8LT.Services;

public static class CommandService
{
    public static void LoadCommands(string configPath)
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

    public static ConsoleKey ReadCommandKey()
    {
        return Console.ReadKey(true).Key;
    }

    public static void ExecuteCommand(ConsoleKey commandKey, ConsoleController consoleController)
    {
        try
        {
            ICommand.Commands[commandKey].Invoke(commandKey, consoleController);
        }
        catch (KeyNotFoundException ex)
        {
            Console.Error.WriteLine(ex.Message);
        }
    }
}