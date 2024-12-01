using BWE8LT.Controller;

namespace BWE8LT.Commands.Implementations.FileCommands;

public class DeleteEntryCommand : ICommand
{
    public void Execute(ConsoleKey pressedKey, ConsoleController consoleController)
    {
        int cursorPosition = consoleController.CurrentWindow.Cursor.Position;
        string fullPathForEntry = consoleController.CurrentWindow.FileService.GetFullPathForLoadedFile(cursorPosition);

        if (Directory.Exists(fullPathForEntry))
        {
            consoleController.CurrentWindow.FileService.DeleteDirectory(fullPathForEntry);    
        }
        else
        {
            consoleController.CurrentWindow.FileService.DeleteFile(fullPathForEntry);   
        }

        if (consoleController.CurrentWindow.Cursor.Position == consoleController.CurrentWindow.Content.Count - 1)
        {
            consoleController.CurrentWindow.Cursor.MoveCursor(consoleController.CurrentWindow.Cursor.Position - 1);
        }
        
        consoleController.CurrentWindow.FileService.ReadAllFiles(consoleController.CurrentWindow.FileService.WorkingDirectory);
        consoleController.CurrentWindow.WriteLoadedFilesToConsole();
        consoleController.CurrentWindow.RefreshDisplay();
    }
}