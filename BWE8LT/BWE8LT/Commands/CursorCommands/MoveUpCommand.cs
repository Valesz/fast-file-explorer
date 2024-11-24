using BWE8LT.Utils;

namespace BWE8LT.Commands.CursorCommands;

public class MoveUpCommand : ICommand
{
    public void Execute(ConsoleKey pressedKey)
    {
        Cursor.Instance.MoveCursor(Cursor.Instance.Position - 1);
    }
}