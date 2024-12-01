using BWE8LT.Commands.CommandTypes;
using BWE8LT.Controller;
using BWE8LT.Model;

namespace BWE8LT.Commands.CommandImplementations.LineCommands.ContentCommands;

public class FilterToDirectoryEntries : ILineCommand
{
    public void Execute(string line, ConsoleController consoleController)
    {
        FileItem[] newFiles = consoleController.CurrentWindow.FileService.Files.Where(
            file => file.IsDirectory
        ).ToArray();

        consoleController.CurrentWindow.FileService.Files = newFiles;
        
        consoleController.CurrentWindow.Clear();
        consoleController.CurrentWindow.WriteLoadedFilesToConsole();
        consoleController.CurrentWindow.RefreshDisplay();
    }
}