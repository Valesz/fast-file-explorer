using BWE8LT.Commands.CommandTypes;
using BWE8LT.Controller;

namespace BWE8LT.Commands.CommandImplementations.KeyCommands.CursorCommands;

public class JumpToContentStartsWithLetterCommand : AKeyCommand
{
    protected override void Execute(ConsoleKeyInfo pressedKey, IConsoleController consoleController)
    {
        char startingChar = Console.ReadKey().KeyChar;
        int indexOfLine =
            consoleController.CurrentWindow.Content.FindIndex(
                consoleController.CurrentWindow.Cursor.Position + 1,
                line => line[0].ToLower().StartsWith(startingChar)
            );

        if (indexOfLine < 0)
        {
            indexOfLine = 
                consoleController.CurrentWindow.Content.FindIndex(
                line => line[0].ToLower().StartsWith(startingChar)
                );
            
            if (indexOfLine < 0)
                return;
        }
        
        consoleController.CurrentWindow.Cursor.MoveCursor(indexOfLine);
        consoleController.CurrentWindow.RefreshDisplay();
    }
}