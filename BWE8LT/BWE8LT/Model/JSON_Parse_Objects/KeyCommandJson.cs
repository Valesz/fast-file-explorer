using BWE8LT.Commands.CommandTypes;
using BWE8LT.Commands.Factories.Implementations;

namespace BWE8LT.Model.JSON_Parse_Objects;

public class KeyCommandJson : CommandJson
{
    public KeyCommand ToCommand()
    {
        ConsoleKeyInfo key = new ConsoleKeyInfo(
            '.', 
            Enum.Parse<ConsoleKey>(Key.Split(" ")[0]), 
            Key.ToLower().Contains("shift"), 
            Key.ToLower().Contains("alt"), 
            Key.ToLower().Contains("ctrl")
        );

        IKeyCommand command = new KeyCommandFactory().CreateCommand(Action);
        
        return new KeyCommand(key, command.Execute);
    }
}