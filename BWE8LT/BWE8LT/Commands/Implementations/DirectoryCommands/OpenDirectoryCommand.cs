using BWE8LT.Controller;

namespace BWE8LT.Commands.Implementations.DirectoryCommands;

public class OpenDirectoryCommand : ICommand
{
    public void Execute(ConsoleKey pressedKey, ConsoleController consoleController)
    {
	    consoleController.CurrentWindow.FileService.OpenDirectory(consoleController.CurrentWindow.Cursor.GetSelectedContent());
        consoleController.CurrentWindow.Cursor.MoveCursor(0);
        
        consoleController.CurrentWindow.WriteLoadedFilesToConsole();
        consoleController.CurrentWindow.UpdateHeader([
	        "Current working directory: ", 
	        consoleController.CurrentWindow.FileService.WorkingDirectory
        ]);
        
        consoleController.UpdateWindowIndicators();
        consoleController.CurrentWindow.RefreshDisplay();
    }
}