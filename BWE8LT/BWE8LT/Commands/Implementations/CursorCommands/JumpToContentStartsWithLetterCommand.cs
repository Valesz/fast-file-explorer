using BWE8LT.Controller;

namespace BWE8LT.Commands.Implementations.CursorCommands;

public class JumpToContentStartsWithLetterCommand : ICommand
{
    public void Execute(ConsoleKey pressedKey, ConsoleController consoleController)
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