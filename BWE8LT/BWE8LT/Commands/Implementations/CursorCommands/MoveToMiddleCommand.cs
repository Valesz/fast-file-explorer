using BWE8LT.Services;

namespace BWE8LT.Commands.CursorCommands;

public class MoveToMiddleCommand : ICommand
{
    public void Execute(ConsoleKey pressedKey, ConsoleController consoleController)
    {
	    consoleController.CurrentWindow.Cursor.MoveCursor(consoleController.CurrentWindow.Content.Count / 2);
    }
}