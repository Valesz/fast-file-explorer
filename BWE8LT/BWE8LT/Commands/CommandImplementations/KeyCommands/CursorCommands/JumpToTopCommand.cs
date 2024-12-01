using BWE8LT.Commands.CommandTypes;
using BWE8LT.Controller;

namespace BWE8LT.Commands.CommandImplementations.KeyCommands.CursorCommands;

public class JumpToTopCommand : IKeyCommand
{
    public void Execute(ConsoleKeyInfo pressedKey, ConsoleController consoleController)
    {
	    consoleController.CurrentWindow.Cursor.MoveCursor(0);
        consoleController.CurrentWindow.RefreshDisplay();
    }
}