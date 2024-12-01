using System.Text.Json;

using BWE8LT.Commands.CommandTypes;
using BWE8LT.Controller;
using BWE8LT.Services;

namespace BWE8LT.Commands.CommandImplementations.KeyCommands.UtilCommands;

public class SaveConfigCommand : IKeyCommand
{
    public void Execute(ConsoleKeyInfo pressedKey, ConsoleController consoleController)
    {
        var serializer = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        
        string json = JsonSerializer.Serialize(CommandService.CommandConfigJson, serializer);
        File.WriteAllText(consoleController.CurrentWindow.FileService.WorkingDirectory + @"\Commands.json", json);

        consoleController.CurrentWindow.Clear();
        consoleController.CurrentWindow.FileService.ReadAllFiles(
            consoleController.CurrentWindow.FileService.WorkingDirectory
        );
        consoleController.CurrentWindow.WriteLoadedFilesToConsole();
        consoleController.CurrentWindow.RefreshDisplay();
    }
}