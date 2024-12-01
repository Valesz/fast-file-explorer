using System.Text.Json;

using BWE8LT.Controller;
using BWE8LT.Services;
using BWE8LT.Utils;

namespace BWE8LT.Commands.Implementations.UtilCommands;

public class SaveConfigCommand : ICommand
{
    public void Execute(ConsoleKey pressedKey, ConsoleController consoleController)
    {
        var serializer = new JsonSerializerOptions
        {
            Converters = { new CommandConverter() },
            WriteIndented = true
        };
        
        string json = JsonSerializer.Serialize(CommandService.CommandConfig, serializer);
        File.WriteAllText(consoleController.CurrentWindow.FileService.WorkingDirectory + @"\Commands.json", json);

        consoleController.CurrentWindow.FileService.ReadAllFiles(
            consoleController.CurrentWindow.FileService.WorkingDirectory
        );
        consoleController.CurrentWindow.WriteLoadedFilesToConsole();
        consoleController.CurrentWindow.RefreshDisplay();
    }
}