using BWE8LT.Commands.CursorCommands;
using BWE8LT.Commands.DirectoryCommands;
using BWE8LT.Commands.UtilCommands;

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
            case "ITERATE":
                return new IterateCommand();
            case "MOVE_TOP":
                return new MoveToTopCommand();
            case "MOVE_MIDDLE":
                return new MoveToMiddleCommand();
            case "MOVE_BOTTOM":
                return new MoveToBottomCommand();
            default:
                throw new ArgumentException($"Invalid command: {command}");
        }
    }
}