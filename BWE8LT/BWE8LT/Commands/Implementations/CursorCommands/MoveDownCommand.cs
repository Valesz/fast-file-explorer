using BWE8LT.Controller;

namespace BWE8LT.Commands.Implementations.CursorCommands;

public class MoveDownCommand : ICommand
{
    public void Execute(ConsoleKey pressedKey, ConsoleController consoleController)
    {
	    consoleController.CurrentWindow.Cursor.MoveCursor(consoleController.CurrentWindow.Cursor.Position + 1);
        consoleController.CurrentWindow.RefreshDisplay();
    }
}