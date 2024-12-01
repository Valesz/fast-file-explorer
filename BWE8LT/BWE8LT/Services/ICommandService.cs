using BWE8LT.Controller;
using BWE8LT.Model.JSON_Parse_Objects;

namespace BWE8LT.Services;

public interface ICommandService
{
    public CommandConfigJson CommandConfigJson { get; }

    public void LoadCommands(string configPath);

    public ConsoleKeyInfo ReadKeyCommand();

    public string ReadLineCommand();

    public void ExecuteKeyCommand(ConsoleKeyInfo commandKey, IConsoleController consoleController);

    public void ExecuteLineCommand(string line, IConsoleController consoleController);
}