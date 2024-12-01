using BWE8LT.Commands.CommandTypes;
using BWE8LT.Controller;

namespace BWE8LT.Commands.CommandImplementations.KeyCommands.DirectoryCommands;

public class OpenDirectoryCommand : IKeyCommand
{
    public void Execute(ConsoleKeyInfo pressedKey, ConsoleController consoleController)
    {
        if (!Directory.Exists(consoleController.CurrentWindow.Cursor.GetSelectedFile().FullPath))
        {
            throw new DirectoryNotFoundException("The selected entry is not a directory!");
        }
        
	    string newDirectory = consoleController.CurrentWindow.FileService.OpenDirectory(
            consoleController.CurrentWindow.Cursor.GetSelectedFile().FullPath
        );
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