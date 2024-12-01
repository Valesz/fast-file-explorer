using BWE8LT.Commands.CommandTypes;
using BWE8LT.Controller;

namespace BWE8LT.Commands.CommandImplementations.KeyCommands.CursorCommands;

public class JumpToBottomCommand : IKeyCommand
{
    public void Execute(ConsoleKeyInfo pressedKey, ConsoleController consoleController)
    {
	    consoleController.CurrentWindow.Cursor.MoveCursor(consoleController.CurrentWindow.Content.Count - 1);
        consoleController.CurrentWindow.RefreshDisplay();
    }
}