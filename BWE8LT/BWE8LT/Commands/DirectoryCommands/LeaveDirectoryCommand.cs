using BWE8LT.Services;

namespace BWE8LT.Commands.DirectoryCommands;

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
        
        consoleController.CurrentWindow.WriteAllFilesToConsole();
        consoleController.CurrentWindow.UpdateHeader([
	        "Current working directory: ", 
	        consoleController.CurrentWindow.FileService.WorkingDirectory
        ]);
    }
}