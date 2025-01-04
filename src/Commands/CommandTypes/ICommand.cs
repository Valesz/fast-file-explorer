using BWE8LT.Controller;

namespace BWE8LT.Commands.CommandTypes;

public interface ICommand
{
    public static Dictionary<object, Action<object, IConsoleController>> Commands { get; } = [];
    
    public void Execute(object pressedKey, IConsoleController consoleController);
}