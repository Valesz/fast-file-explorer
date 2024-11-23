namespace BWE8LT.Commands;

public interface ICommand
{
    public static Dictionary<ConsoleKey, Action> Commands { get; } = [];
    
    public void Execute();
}