using BWE8LT.Commands.CursorCommands;
using BWE8LT.Commands.DirectoryCommands;

namespace BWE8LT.Commands;

public class CommandFactory
{
    public static ICommand CreateCommand(string command)
    {
        switch (command)
        {
            case "MOVE_UP":
                return new MoveUpCommand();
            case "MOVE_DOWN":
                return new MoveDownCommand();
            case "EXIT_APPLICATION":
                return new ExitApplicationCommand();
            case "OPEN_FOLDER":
                return new OpenDirectoryCommand();
            case "CLOSE_FOLDER":
                return new LeaveDirectoryCommand();
            default:
                throw new ArgumentException($"Invalid command: {command}");
        }
    }
}