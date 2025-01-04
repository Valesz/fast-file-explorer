using System.Collections.Frozen;

using BWE8LT.Commands.CommandImplementations.LineCommands.ContentCommands;
using BWE8LT.Commands.CommandImplementations.LineCommands.CursorCommands;
using BWE8LT.Commands.CommandTypes;

namespace BWE8LT.Utils.Constants;

public static class StringToLineCommandMap
{
    public static FrozenDictionary<string, ICommand> Commands { get; }

    static StringToLineCommandMap()
    {
        Commands = new Dictionary<string, ICommand>
        {
            {"JUMP_TO_LINE", new JumpToALineNumber()},
            {"GREP_STRING_CONTAINS", new FilterEntriesContainsStringCommand()},
            {"GREP_REGEX", new FilterEntriesByRegex()},
            {"FILTER_FILES", new FilterToFileEntries()},
            {"FILTER_DIRECTORIES", new FilterToDirectoryEntries()}
        }.ToFrozenDictionary();
    }
}