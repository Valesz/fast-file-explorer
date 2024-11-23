namespace BWE8LT.Model;

public class Command
{
    public required ConsoleKey Key { get; set; }

    public required Action Action { get; set; }
}