using BWE8LT.Commands.CommandTypes;
using BWE8LT.Controller;

namespace BWE8LT.Commands.CommandImplementations.LineCommands.CursorCommands;

public class JumpToALineNumber : ALineCommand
{
    protected override void Execute(string line, IConsoleController consoleController)
    {
        string[] args = line.Split(" ")[1..];
        consoleController.CurrentWindow.Cursor.MoveCursor(Int32.Parse(args[0]) - 1);
        consoleController.CurrentWindow.RefreshDisplay();
    }
}