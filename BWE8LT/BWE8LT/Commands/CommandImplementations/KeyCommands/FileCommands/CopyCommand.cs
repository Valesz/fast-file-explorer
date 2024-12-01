using BWE8LT.Commands.CommandTypes;
using BWE8LT.Controller;

namespace BWE8LT.Commands.CommandImplementations.KeyCommands.FileCommands;

public class CopyCommand : IKeyCommand
{
    public void Execute(ConsoleKeyInfo pressedKey, IConsoleController consoleController)
    {
        int cursorPosition = consoleController.CurrentWindow.Cursor.Position;
        string fullPathForLoadedFile =
            consoleController.CurrentWindow.FileService.GetFullPathForLoadedFile(cursorPosition);
        consoleController.Copy([fullPathForLoadedFile]);
    }
}