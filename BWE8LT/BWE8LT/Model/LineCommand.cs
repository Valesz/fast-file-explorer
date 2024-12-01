using BWE8LT.Controller;

namespace BWE8LT.Model;

public record LineCommand(
    string Key,
    Action<string, ConsoleController> Action
) : Command<string>(Key, Action);