using BWE8LT.Commands.CommandTypes;
using BWE8LT.Controller;

namespace BWE8LT.Commands.CommandImplementations.KeyCommands.CursorCommands;

public class JumpToBottomCommand : AKeyCommand
{
    protected override void Execute(ConsoleKeyInfo pressedKey, IConsoleController consoleController)
    {
	    consoleController.CurrentWindow.Cursor.MoveCursor(consoleController.CurrentWindow.Content.Count - 1);
        consoleController.CurrentWindow.RefreshDisplay();
    }
}