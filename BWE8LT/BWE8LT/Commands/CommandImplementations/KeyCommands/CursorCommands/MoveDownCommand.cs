using BWE8LT.Commands.CommandTypes;
using BWE8LT.Controller;

namespace BWE8LT.Commands.CommandImplementations.KeyCommands.CursorCommands;

public class MoveDownCommand : AKeyCommand
{
    protected override void Execute(ConsoleKeyInfo pressedKey, IConsoleController consoleController)
    {
        if (consoleController.CurrentWindow.Cursor.Position + 1 > consoleController.CurrentWindow.Content.Count - 1)
        {
            return;
        }
        
	    consoleController.CurrentWindow.Cursor.MoveCursor(consoleController.CurrentWindow.Cursor.Position + 1);
        consoleController.CurrentWindow.RefreshDisplay();
    }
}