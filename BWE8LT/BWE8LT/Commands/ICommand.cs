using BWE8LT.Services;

namespace BWE8LT.Commands;

public interface ICommand
{
    public static Dictionary<ConsoleKey, Action<ConsoleKey, ConsoleController>> Commands { get; } = [];
    
    public void Execute(ConsoleKey pressedKey, ConsoleController consoleController);
}