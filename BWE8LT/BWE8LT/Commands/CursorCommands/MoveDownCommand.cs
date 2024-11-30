using BWE8LT.Services;

namespace BWE8LT.Commands.CursorCommands;

public class MoveDownCommand : ICommand
{
    public void Execute(ConsoleKey pressedKey, ConsoleController consoleController)
    {
	    consoleController.CurrentWindow.Cursor.MoveCursor(consoleController.CurrentWindow.Cursor.Position + 1);
    }
}