using BWE8LT.Services;
using BWE8LT.Utils;

namespace BWE8LT.Commands.DirectoryCommands;

public class OpenDirectoryCommand : ICommand
{
    public void Execute()
    {
        FileService.Instance.OpenDirectory(FileService.Instance.Files[Cursor.Instance.Position]);
        Cursor.Instance.MoveCursor(0);
    }
}