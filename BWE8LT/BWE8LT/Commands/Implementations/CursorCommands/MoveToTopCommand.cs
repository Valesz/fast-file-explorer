using BWE8LT.Services;

namespace BWE8LT.Commands.CursorCommands;

public class MoveToTopCommand : ICommand
{
    public void Execute(ConsoleKey pressedKey, ConsoleController consoleController)
    {
	    consoleController.CurrentWindow.Cursor.MoveCursor(0);
    }
}