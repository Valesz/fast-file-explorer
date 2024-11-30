using BWE8LT.Controller;

namespace BWE8LT.Commands.Implementations.WindowCommands;

public class CreateNewWindowCommand : ICommand
{
    public void Execute(ConsoleKey pressedKey, ConsoleController consoleController)
    {
        int indexOfNewWindow = consoleController.CreateNewWindow(consoleController.CurrentWindow.FileService.WorkingDirectory);
        
        consoleController.SwitchCurrentWindow(indexOfNewWindow);
        
        consoleController.CurrentWindow.UpdateHeader([
            "Current working directory: ",
            consoleController.CurrentWindow.FileService.WorkingDirectory
        ]);
        consoleController.CurrentWindow.WriteLoadedFilesToConsole();
        
        consoleController.UpdateWindowIndicators();
        consoleController.CurrentWindow.RefreshDisplay();
    }
}