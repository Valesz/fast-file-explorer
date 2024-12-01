using BWE8LT.Controller;

namespace BWE8LT.Commands.CommandTypes;

public interface ICommand<in TCommand> where TCommand : notnull
{
    public static Dictionary<TCommand, Action<TCommand, IConsoleController>> Commands { get; } = [];
    
    public void Execute(TCommand pressedKey, IConsoleController consoleController);
}