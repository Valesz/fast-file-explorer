using BWE8LT.Services;

namespace BWE8LT.Model;

public record Command(
    ConsoleKey Key, 
    Action<ConsoleKey, ConsoleController> Action
);