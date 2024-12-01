namespace BWE8LT.Commands.Factories;

public interface ICommandFactory<out TCommandType> where TCommandType : notnull
{
    public TCommandType CreateCommand(string command);

    public bool SupportsType(string type);
}