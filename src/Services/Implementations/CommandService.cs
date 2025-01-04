using System.Text.Json;

using BWE8LT.Commands.CommandTypes;
using BWE8LT.Commands.Factories;
using BWE8LT.Controller;
using BWE8LT.Model;

namespace BWE8LT.Services.Implementations;

public class CommandService : ICommandService
{
    public CommandConfig CommandConfig { get; set; }
    
    public void LoadCommands(string configPath)
    {
        string configText = File.ReadAllText(configPath);

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };
        
        CommandConfig = JsonSerializer.Deserialize<CommandConfig>(configText, options) 
                            ?? throw new ArgumentException("Couldn't deserialize config");

        CommandFactoryManager manager = new CommandFactoryManager();
        
        foreach (Command command in CommandConfig.CommandsList)
        {
            (object, ICommand) keyCommandPairs = manager.CreateCommand(command.Action, command.Key, command.Type);
            ICommand.Commands.Add(keyCommandPairs.Item1, keyCommandPairs.Item2.Execute);
        }
    }

    public ConsoleKeyInfo ReadKeyCommand()
    {
        ConsoleKeyInfo readKeyInfo = Console.ReadKey(true);
        
        return new ConsoleKeyInfo(
            '.',
            readKeyInfo.Key,
            readKeyInfo.Modifiers.HasFlag(ConsoleModifiers.Shift),
            readKeyInfo.Modifiers.HasFlag(ConsoleModifiers.Alt),
            readKeyInfo.Modifiers.HasFlag(ConsoleModifiers.Control)
        );
    }

    public string ReadLineCommand()
    {
        return Console.ReadLine() ?? throw new ArgumentException("Nothing provided to execute");
    }

    public void ExecuteKeyCommand(ConsoleKeyInfo commandKey, IConsoleController consoleController)
    {
        try
        {
            ICommand.Commands[commandKey].Invoke(commandKey, consoleController);
        }
        catch (KeyNotFoundException _)
        {
            consoleController.CurrentWindow.UpdateFooter([
                $"Key '{commandKey.Key}' was not found in dictionary",
                consoleController.GetWindowIndicators()
            ]);
            consoleController.CurrentWindow.RefreshDisplay();
        }
        catch (Exception ex)
        {
            consoleController.CurrentWindow.UpdateFooter([
                ex.Message,
                consoleController.GetWindowIndicators()
            ]);
            consoleController.CurrentWindow.RefreshDisplay();
        }
    }

    public void ExecuteLineCommand(string line, IConsoleController consoleController)
    {
        try
        {
            string command = line.Split(" ")[0];
            ICommand.Commands[command].Invoke(line, consoleController);
        }
        catch (Exception ex)
        {
            consoleController.CurrentWindow.UpdateFooter([
                ex.Message,
                consoleController.GetWindowIndicators()
            ]);
            consoleController.CurrentWindow.RefreshDisplay();
        }
    }
}