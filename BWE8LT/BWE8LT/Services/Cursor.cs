using BWE8LT.Utils;

namespace BWE8LT.Services;

public class Cursor
{
    private readonly Window _window;
    
    public int Position { get; private set; }

    public int LookAheadInConsole { get; set; }
    
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

    public string GetSelectedContent()
    {
        return _window.Content[Position];
    }
}