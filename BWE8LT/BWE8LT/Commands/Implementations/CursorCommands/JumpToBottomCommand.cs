using BWE8LT.Controller;

namespace BWE8LT.Commands.Implementations.CursorCommands;

public class JumpToBottomCommand : ICommand
{
    public void Execute(ConsoleKey pressedKey, ConsoleController consoleController)
    {
	    consoleController.CurrentWindow.Cursor.MoveCursor(consoleController.CurrentWindow.Content.Count - 1);
        consoleController.CurrentWindow.RefreshDisplay();
    }
}