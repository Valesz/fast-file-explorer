using BWE8LT.Commands.CommandTypes;
using BWE8LT.Utils.Constants;

namespace BWE8LT.Commands.Factories.Implementations;

public class LineCommandFactory : ICommandFactory<ILineCommand>
{
    public ILineCommand CreateCommand(string command)
    {
        return StringToLineCommandMap.Commands[command];
    }

    public bool SupportsType(string type) => "LineCommand" == type;
}