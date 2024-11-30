using BWE8LT.Services;

namespace BWE8LT.Commands;

public class ExitApplicationCommand : ICommand
{
    public void Execute(ConsoleKey pressedKey, ConsoleController consoleController)
    {
        Console.Clear();
        Console.CursorVisible = true;
        Environment.Exit(0);
    }
}