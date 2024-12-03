using BWE8LT.Controller;

namespace BWE8LT.Commands.CommandTypes;

public abstract class ALineCommand : ICommand
{
    protected abstract void Execute(string line, IConsoleController consoleController);
    
    public void Execute(object pressedKey, IConsoleController consoleController)
    {
        if (pressedKey is string line)
        {
            this.Execute(line, consoleController);
            return;
        }

        throw new ArgumentException("Wrong type provided to action");
    }
}