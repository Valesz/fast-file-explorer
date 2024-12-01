using BWE8LT.Controller;

namespace BWE8LT.Commands.Implementations.FileCommands;

public class CopyCommand : ICommand
{
    public void Execute(ConsoleKey pressedKey, ConsoleController consoleController)
    {
        int cursorPosition = consoleController.CurrentWindow.Cursor.Position;
        string fullPathForLoadedFile =
            consoleController.CurrentWindow.FileService.GetFullPathForLoadedFile(cursorPosition);
        consoleController.Copy([fullPathForLoadedFile]);
    }
}