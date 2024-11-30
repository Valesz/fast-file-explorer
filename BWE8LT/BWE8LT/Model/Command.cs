using BWE8LT.Controller;

namespace BWE8LT.Model;

public record Command(
    ConsoleKey Key, 
    Action<ConsoleKey, ConsoleController> Action
);