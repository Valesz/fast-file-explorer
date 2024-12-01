using BWE8LT.Commands.CommandTypes;
using BWE8LT.Commands.Factories.Implementations;

namespace BWE8LT.Model.JSON_Parse_Objects;

public class LineCommandJson : CommandJson
{
    public LineCommand ToCommand()
    {
        ILineCommand command = new LineCommandFactory().CreateCommand(Action);
        
        return new LineCommand(Key, command.Execute);
    }
}