using BWE8LT.Services;

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
        consoleController.CurrentWindow.WriteAllFilesToConsole();
        
        consoleController.UpdateWindowIndicators();
    }
}