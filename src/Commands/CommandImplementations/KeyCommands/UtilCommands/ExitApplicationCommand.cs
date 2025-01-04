using BWE8LT.Commands.CommandTypes;
using BWE8LT.Controller;

namespace BWE8LT.Commands.CommandImplementations.KeyCommands.UtilCommands;

public class ExitApplicationCommand : AKeyCommand
{
    protected override void Execute(ConsoleKeyInfo pressedKey, IConsoleController consoleController)
    {
        Console.Clear();
        Console.CursorVisible = true;
        Environment.Exit(0);
    }
}