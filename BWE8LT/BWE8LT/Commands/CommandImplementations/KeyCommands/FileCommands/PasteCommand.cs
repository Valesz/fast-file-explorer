using BWE8LT.Commands.CommandTypes;
using BWE8LT.Controller;

namespace BWE8LT.Commands.CommandImplementations.KeyCommands.FileCommands;

public class PasteCommand : IKeyCommand
{
    public void Execute(ConsoleKeyInfo pressedKey, ConsoleController consoleController)
    {
        if (consoleController.Clipboard.Count <= 0)
        {
            return;
        }

        string workingDirectory = consoleController.CurrentWindow.FileService.WorkingDirectory;
        
        foreach (string copiedPath in consoleController.Clipboard)
        {
            if (Directory.Exists(copiedPath))
            {
                consoleController.CurrentWindow.FileService.PasteDirectory(copiedPath, workingDirectory);
            }
            else
            {
                consoleController.CurrentWindow.FileService.PasteFile(copiedPath, workingDirectory);
            }   
        }
        
        consoleController.CurrentWindow.FileService.ReadAllFiles(consoleController.CurrentWindow.FileService.WorkingDirectory);
        consoleController.CurrentWindow.WriteLoadedFilesToConsole();
        consoleController.CurrentWindow.RefreshDisplay();
    }
}