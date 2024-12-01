using System.Text.RegularExpressions;

using BWE8LT.Commands.CommandTypes;
using BWE8LT.Controller;
using BWE8LT.Model;

namespace BWE8LT.Commands.CommandImplementations.LineCommands.ContentCommands;

public class FilterEntriesByRegex : ILineCommand
{
    public void Execute(string line, IConsoleController consoleController)
    {
        string[] args = line.Split(" ")[1..];

        FileItem[] newFiles = consoleController.CurrentWindow.FileService.Files.Where(
            file => Regex.IsMatch(file.Name, args[0])
        ).ToArray();

        consoleController.CurrentWindow.FileService.Files = newFiles;
        
        consoleController.CurrentWindow.Cursor.MoveCursor(0);
        
        consoleController.CurrentWindow.Clear();
        consoleController.CurrentWindow.WriteLoadedFilesToConsole();
        consoleController.CurrentWindow.RefreshDisplay();
    }
}