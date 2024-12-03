using BWE8LT.Commands.CommandTypes;
using BWE8LT.Controller;

namespace BWE8LT.Commands.CommandImplementations.KeyCommands.FileCommands;

public class ReloadEntriesCommand : AKeyCommand
{
    protected override void Execute(ConsoleKeyInfo pressedKey, IConsoleController consoleController)
    {
        consoleController.CurrentWindow.FileService.ReadAllFiles(
            consoleController.CurrentWindow.FileService.WorkingDirectory
        );
        
        consoleController.CurrentWindow.Clear();
        consoleController.CurrentWindow.WriteLoadedFilesToConsole();
        consoleController.CurrentWindow.RefreshDisplay();
    }
}