using BWE8LT.Services;

namespace BWE8LT.Commands.DirectoryCommands;

public class OpenDirectoryCommand : ICommand
{
    public void Execute(ConsoleKey pressedKey, ConsoleController consoleController)
    {
	    consoleController.CurrentWindow.FileService.OpenDirectory(consoleController.CurrentWindow.Cursor.GetSelectedContent());
        consoleController.CurrentWindow.Cursor.MoveCursor(0);
        
        consoleController.CurrentWindow.WriteAllFilesToConsole();
        consoleController.CurrentWindow.UpdateHeader([
	        "Current working directory: ", 
	        consoleController.CurrentWindow.FileService.WorkingDirectory
        ]);
        
        consoleController.UpdateWindowIndicators();
    }
}