using BWE8LT.Controller;

namespace BWE8LT.Model;

public record KeyCommand(
    ConsoleKeyInfo Key,
    Action<ConsoleKeyInfo, IConsoleController> Action
) : Command<ConsoleKeyInfo>(Key, Action);