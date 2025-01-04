using BWE8LT.Commands.CommandTypes;

namespace BWE8LT.Commands.Factories;

public interface ICommandFactory
{
    public (object, ICommand) CreateCommand(string command, string key);

    public bool SupportsType(string type);
}