using BWE8LT.Commands.CommandTypes;
using BWE8LT.Utils.Constants;

namespace BWE8LT.Commands.Factories.Implementations;

public class LineCommandFactory : ICommandFactory
{
    public (object, ICommand) CreateCommand(string command, string key)
    {
        return (key, StringToLineCommandMap.Commands[command]);
    }

    public bool SupportsType(string type) => "LineCommand" == type;
}