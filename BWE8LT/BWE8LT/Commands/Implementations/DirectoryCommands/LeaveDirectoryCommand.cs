using BWE8LT.Controller;

namespace BWE8LT.Commands.Implementations.DirectoryCommands;

public class LeaveDirectoryCommand : ICommand
{
    public void Execute(ConsoleKey pressedKey, ConsoleController consoleController)
    {
	    string workingDirectory = consoleController.CurrentWindow.FileService.WorkingDirectory;
	    int indexOfLastSeparator = workingDirectory.LastIndexOf(Path.DirectorySeparatorChar);
	    
        consoleController.CurrentWindow.FileService.LeaveDirectory();
        consoleController.CurrentWindow.Cursor.MoveCursor(0);

        if (indexOfLastSeparator == workingDirectory.Length - 1)
        {
	        return;
        }
        
        consoleController.CurrentWindow.WriteLoadedFilesToConsole();
        consoleController.CurrentWindow.UpdateHeader([
	        "Current working directory: ", 
	        consoleController.CurrentWindow.FileService.WorkingDirectory
        ]);
        
        consoleController.UpdateWindowIndicators();
        consoleController.CurrentWindow.RefreshDisplay();
    }
}