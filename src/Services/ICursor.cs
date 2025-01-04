using BWE8LT.Model;

namespace BWE8LT.Services;

public interface ICursor
{
    public int Position { get; set; }

    public void MoveCursor(int newCursorPosition);

    public FileItem GetSelectedFile();
}