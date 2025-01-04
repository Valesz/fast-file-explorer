using BWE8LT.Commands.CommandTypes;
using BWE8LT.Utils.Constants;

namespace BWE8LT.Commands.Factories.Implementations;

public class KeyCommandFactory : ICommandFactory
{
    public (object, ICommand) CreateCommand(string command, string key)
    {
        ConsoleKeyInfo resultKey = new ConsoleKeyInfo(
            '.',
            Enum.Parse<ConsoleKey>(key.Split(' ')[0]),
            key.ToLower().Contains("shift"),
            key.ToLower().Contains("alt"),
            key.ToLower().Contains("ctrl")
        );
        
        return (resultKey, StringToKeyCommandMap.Commands[command]);
    }

    public bool SupportsType(string type) => "KeyCommand" == type;
}