using BWE8LT.Model;

namespace BWE8LT.Services.Implementations;

public class Cursor : ICursor
{
    private readonly Window _window;
    
    public int Position { get; set; }

    private int LookAheadInConsole { get; }
    
    public Cursor(Window window)
    {
        _window = window;
        
        LookAheadInConsole = 4;
    }
    
    public void MoveCursor(int newCursorPosition)
    {
        if (newCursorPosition < 0 || newCursorPosition > _window.Content.Count - 1 || Position == newCursorPosition)
        {
            return;
        }
        
        Position = newCursorPosition;

        if (Position < _window.WindowStartIndex + LookAheadInConsole)
        {
            _window.SetWindowTopPosition(_window.WindowStartIndex + (Position - _window.WindowStartIndex - LookAheadInConsole));
        } else if (Position > _window.WindowEndIndex - LookAheadInConsole - 1)
        {
            _window.SetWindowTopPosition(_window.WindowStartIndex + (Position - _window.WindowEndIndex + LookAheadInConsole));
        }
    }

    public FileItem GetSelectedFile()
    {
        return _window.FileService.Files[Position];
    }
}