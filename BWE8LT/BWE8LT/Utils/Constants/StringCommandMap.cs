using System.Collections.Frozen;

using BWE8LT.Commands;
using BWE8LT.Commands.Implementations.CursorCommands;
using BWE8LT.Commands.Implementations.DirectoryCommands;
using BWE8LT.Commands.Implementations.FileCommands;
using BWE8LT.Commands.Implementations.UtilCommands;
using BWE8LT.Commands.Implementations.WindowCommands;

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
            {"MOVE_TOP", new JumpToTopCommand()},
            {"MOVE_MIDDLE", new JumpToMiddleCommand()},
            {"MOVE_BOTTOM", new JumpToBottomCommand()},
            {"NEW_WINDOW", new CreateNewWindowCommand()},
            {"SWITCH_WINDOW_LEFT", new SwitchToLeftWindowFromCurrentCommand()},
            {"SWITCH_WINDOW_RIGHT", new SwitchToRightWindowFromCurrentCommand()},
            {"DELETE_WINDOW", new DeleteCurrentWindowCommand()},
            {"COPY_ENTRY", new CopyCommand()},
            {"PASTE_ENTRY", new PasteCommand()},
            {"DELETE_ENTRY", new DeleteEntryCommand()},
            {"FIND_CHAR", new JumpToContentStartsWithLetterCommand()},
            {"SAVE_CONFIG", new SaveConfigCommand()},
        }.ToFrozenDictionary();
    }
}