using BWE8LT.Controller;

namespace BWE8LT.Commands.Implementations.UtilCommands;

public class ExitApplicationCommand : ICommand
{
    public void Execute(ConsoleKey pressedKey, ConsoleController consoleController)
    {
        Console.Clear();
        Console.CursorVisible = true;
        Environment.Exit(0);
    }
}