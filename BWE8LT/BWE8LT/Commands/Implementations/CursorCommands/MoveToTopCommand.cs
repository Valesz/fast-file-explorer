using BWE8LT.Controller;

namespace BWE8LT.Commands.Implementations.CursorCommands;

public class MoveToTopCommand : ICommand
{
    public void Execute(ConsoleKey pressedKey, ConsoleController consoleController)
    {
	    consoleController.CurrentWindow.Cursor.MoveCursor(0);
        consoleController.CurrentWindow.RefreshDisplay();
    }
}