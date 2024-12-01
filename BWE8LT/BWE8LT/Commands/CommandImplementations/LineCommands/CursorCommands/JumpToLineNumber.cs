using BWE8LT.Commands.CommandTypes;
using BWE8LT.Controller;

namespace BWE8LT.Commands.CommandImplementations.LineCommands.CursorCommands;

public class JumpToLineNumber : ILineCommand
{
    public void Execute(string line, ConsoleController consoleController)
    {
        string[] args = line.Split(" ")[1..];
        consoleController.CurrentWindow.Cursor.MoveCursor(Int32.Parse(args[0]) - 1);
        consoleController.CurrentWindow.RefreshDisplay();
    }
}