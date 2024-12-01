using BWE8LT.Commands.CommandTypes;
using BWE8LT.Controller;

namespace BWE8LT.Commands.CommandImplementations.KeyCommands.WindowCommands;

public class CreateNewWindowCommand : IKeyCommand
{
    public void Execute(ConsoleKeyInfo pressedKey, IConsoleController consoleController)
    {
        int indexOfNewWindow = consoleController.CreateNewWindow(consoleController.CurrentWindow.FileService.WorkingDirectory);
        
        consoleController.SwitchCurrentWindow(indexOfNewWindow);
        
        consoleController.CurrentWindow.UpdateHeader([
            "Current working directory: ",
            consoleController.CurrentWindow.FileService.WorkingDirectory
        ]);
        
        consoleController.CurrentWindow.WriteLoadedFilesToConsole();
        
        consoleController.CurrentWindow.UpdateFooter([consoleController.GetWindowIndicators()]);
        consoleController.CurrentWindow.RefreshDisplay();
    }
}