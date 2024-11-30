using BWE8LT.Utils.Constants;

namespace BWE8LT.Commands;

public static class CommandFactory
{
    public static ICommand CreateCommand(string command)
    {
        return StringCommandMap.Commands[command];
    }
}