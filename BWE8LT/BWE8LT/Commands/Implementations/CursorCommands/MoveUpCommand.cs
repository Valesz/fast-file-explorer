using BWE8LT.Controller;

namespace BWE8LT.Commands.Implementations.CursorCommands;

public class MoveUpCommand : ICommand
{
    public void Execute(ConsoleKey pressedKey, ConsoleController consoleController)
    {
        if (consoleController.CurrentWindow.Cursor.Position - 1 < 0)
        {
            return;
        }
        
        consoleController.CurrentWindow.Cursor.MoveCursor(consoleController.CurrentWindow.Cursor.Position - 1);
        consoleController.CurrentWindow.RefreshDisplay();
    }
}