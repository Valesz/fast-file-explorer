using BWE8LT.Commands.CommandTypes;
using BWE8LT.Controller;

namespace BWE8LT.Commands.CommandImplementations.KeyCommands.CursorCommands;

public class JumpToContentStartsWithLetterCommand : IKeyCommand
{
    public void Execute(ConsoleKeyInfo pressedKey, IConsoleController consoleController)
    {
        char startingChar = Console.ReadKey().KeyChar;
        int indexOfLine =
            consoleController.CurrentWindow.Content.FindIndex(
                consoleController.CurrentWindow.Cursor.Position + 1,
                line => line.ToLower().StartsWith(startingChar)
            );

        if (indexOfLine < 0)
        {
            indexOfLine = 
                consoleController.CurrentWindow.Content.FindIndex(
                line => line.ToLower().StartsWith(startingChar)
                );
            
            if (indexOfLine < 0)
                return;
        }
        
        consoleController.CurrentWindow.Cursor.MoveCursor(indexOfLine);
        consoleController.CurrentWindow.RefreshDisplay();
    }
}