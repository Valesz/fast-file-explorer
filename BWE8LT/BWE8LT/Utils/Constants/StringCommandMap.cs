using System.Collections.Frozen;

using BWE8LT.Commands;
using BWE8LT.Commands.CursorCommands;
using BWE8LT.Commands.DirectoryCommands;
using BWE8LT.Commands.Implementations.WindowCommands;
using BWE8LT.Commands.UtilCommands;

namespace BWE8LT.Utils.Constants;

public static class StringCommandMap
{
    public static FrozenDictionary<string, ICommand> Commands { get; }

    static StringCommandMap()
    {
        Commands = new Dictionary<string, ICommand>
        {
            {"MOVE_UP", new MoveUpCommand()},
            {"MOVE_DOWN", new MoveDownCommand()},
            {"EXIT_APPLICATION", new ExitApplicationCommand()},
            {"OPEN_FOLDER", new OpenDirectoryCommand()},
            {"CLOSE_FOLDER", new LeaveDirectoryCommand()},
            {"ITERATE", new IterateCommand()},
            {"MOVE_TOP", new MoveToTopCommand()},
            {"MOVE_MIDDLE", new MoveToMiddleCommand()},
            {"MOVE_BOTTOM", new MoveToBottomCommand()},
            {"NEW_WINDOW", new CreateNewWindowCommand()},
            {"SWITCH_WINDOW_LEFT", new SwitchToLeftWindowFromCurrentCommand()},
            {"SWITCH_WINDOW_RIGHT", new SwitchToRightWindowFromCurrentCommand()},
            {"DELETE_WINDOW", new DeleteCurrentWindowCommand()},
        }.ToFrozenDictionary();
    }
}