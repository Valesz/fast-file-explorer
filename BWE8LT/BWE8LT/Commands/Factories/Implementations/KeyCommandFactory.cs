using BWE8LT.Commands.CommandTypes;
using BWE8LT.Utils.Constants;

namespace BWE8LT.Commands.Factories.Implementations;

public class KeyCommandFactory : ICommandFactory<IKeyCommand>
{
    public IKeyCommand CreateCommand(string command)
    {
        return StringToKeyCommandMap.Commands[command];
    }

    public bool SupportsType(string type) => "KeyCommand" == type;
}