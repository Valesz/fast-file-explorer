using BWE8LT.Commands.CommandTypes;
using BWE8LT.Controller;

namespace BWE8LT.Commands.CommandImplementations.KeyCommands.CursorCommands;

public class MoveUpCommand : AKeyCommand
{
    protected override void Execute(ConsoleKeyInfo pressedKey, IConsoleController consoleController)
    {
        if (consoleController.CurrentWindow.Cursor.Position - 1 < 0)
        {
            return;
        }
        
        consoleController.CurrentWindow.Cursor.MoveCursor(consoleController.CurrentWindow.Cursor.Position - 1);
        consoleController.CurrentWindow.RefreshDisplay();
    }
}