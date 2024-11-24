using BWE8LT.Utils;

namespace BWE8LT.Commands.CursorCommands;

public class MoveToMiddleCommand : ICommand
{
    public void Execute(ConsoleKey pressedKey)
    {
        Cursor.Instance.MoveCursor(ConsoleHelper.Instance.Content.Count / 2);
    }
}