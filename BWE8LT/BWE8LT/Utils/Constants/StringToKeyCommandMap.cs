using System.Collections.Frozen;

using BWE8LT.Commands.CommandImplementations;
using BWE8LT.Commands.CommandImplementations.KeyCommands.CursorCommands;
using BWE8LT.Commands.CommandImplementations.KeyCommands.DirectoryCommands;
using BWE8LT.Commands.CommandImplementations.KeyCommands.FileCommands;
using BWE8LT.Commands.CommandImplementations.KeyCommands.UtilCommands;
using BWE8LT.Commands.CommandImplementations.KeyCommands.WindowCommands;
using BWE8LT.Commands.CommandTypes;

namespace BWE8LT.Utils.Constants;

public static class StringToKeyCommandMap
{
    public static FrozenDictionary<string, ICommand> Commands { get; }

    static StringToKeyCommandMap()
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
            {"SWITCH_WINDOW_FIRST", new SwitchToLeftMostWindowCommand()},
            {"SWITCH_WINDOW_LAST", new SwitchToRightMostWindowCommand()},
            {"DELETE_WINDOW", new DeleteCurrentWindowCommand()},
            {"COPY_ENTRY", new CopyCommand()},
            {"PASTE_ENTRY", new PasteCommand()},
            {"DELETE_ENTRY", new DeleteEntryCommand()},
            {"FIND_CHAR", new JumpToContentStartsWithLetterCommand()},
            {"SAVE_CONFIG", new SaveConfigCommand()},
            {"READ_LINE_COMMAND", new StartReadingLineCommand()},
            {"RELOAD_ENTRIES", new ReloadEntriesCommand()},
        }.ToFrozenDictionary();
    }
}