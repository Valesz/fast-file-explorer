using BWE8LT.Utils;

namespace BWE8LT.Commands.CursorCommands;

public class MoveToTopCommand : ICommand
{
    public void Execute(ConsoleKey pressedKey)
    {
        Cursor.Instance.MoveCursor(0);
    }
}