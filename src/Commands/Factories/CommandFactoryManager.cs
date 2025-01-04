using BWE8LT.Commands.CommandTypes;
using BWE8LT.Commands.Factories.Implementations;

namespace BWE8LT.Commands.Factories;

public class CommandFactoryManager
{
    private readonly List<ICommandFactory> _factories =
    [
        new KeyCommandFactory(),
        new LineCommandFactory()
    ];
    
    public (object, ICommand) CreateCommand(string command, string key, string type)
    {
        ICommandFactory? factory = _factories.Find(factory => factory.SupportsType(type));
        
        return factory?.CreateCommand(command, key) 
               ?? throw new ArgumentException("Given type doesn't have a factory for it");
    }
}