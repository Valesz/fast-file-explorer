namespace BWE8LT.Commands;

public interface ICommand
{
    public static Dictionary<ConsoleKey, Action<ConsoleKey>> Commands { get; } = [];
    
    public void Execute(ConsoleKey pressedKey);
}