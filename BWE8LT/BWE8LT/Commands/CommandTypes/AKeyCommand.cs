using BWE8LT.Controller;

namespace BWE8LT.Commands.CommandTypes;

public abstract class AKeyCommand : ICommand
{
    protected abstract void Execute(ConsoleKeyInfo pressedKey, IConsoleController consoleController);
    
    public void Execute(object pressedKey, IConsoleController consoleController)
    {
        if (pressedKey is ConsoleKeyInfo key)
        {
            this.Execute(key, consoleController);
            return;
        }

        throw new ArgumentException("Wrong type provided to action");
    }
}