using BWE8LT.Commands.CommandTypes;
using BWE8LT.Controller;

namespace BWE8LT.Commands.CommandImplementations.KeyCommands.DirectoryCommands;

public class LeaveDirectoryCommand : AKeyCommand
{
    protected override void Execute(ConsoleKeyInfo pressedKey, IConsoleController consoleController)
    {
	    string workingDirectory = consoleController.CurrentWindow.FileService.WorkingDirectory;
	    int indexOfLastSeparator = workingDirectory.LastIndexOf(Path.DirectorySeparatorChar);
	    
        if (indexOfLastSeparator == workingDirectory.Length - 1)
        {
            return;
        }
        
        string newDirectory = consoleController.CurrentWindow.FileService.LeaveDirectory();
        consoleController.CurrentWindow.FileService.ReadAllFiles(newDirectory);
        consoleController.CurrentWindow.Cursor.MoveCursor(0);
        
        consoleController.CurrentWindow.Clear();
        consoleController.CurrentWindow.WriteLoadedFilesToConsole();
        consoleController.CurrentWindow.UpdateHeader([
	        "Current working directory: ", 
	        consoleController.CurrentWindow.FileService.WorkingDirectory
        ]);
        
        consoleController.CurrentWindow.UpdateFooter([consoleController.GetWindowIndicators()]);
        consoleController.CurrentWindow.RefreshDisplay();
    }
}