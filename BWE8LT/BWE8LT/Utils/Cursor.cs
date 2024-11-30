namespace BWE8LT.Utils;

public class Cursor
{
    private readonly ConsoleWindow _consoleWindow;
    
    public int Position { get; private set; }

    public int LookAheadInConsole { get; set; }
    
    public Cursor(ConsoleWindow window)
    {
        _consoleWindow = window;
        
        LookAheadInConsole = 4;
    }
    
    public void MoveCursor(int newCursorPosition)
    {
        if (newCursorPosition < 0 || newCursorPosition > _consoleWindow.Content.Count - 1 || Position == newCursorPosition)
        {
            return;
        }
        
        Position = newCursorPosition;

        if (Position < _consoleWindow.WindowStartIndex + LookAheadInConsole)
        {
            _consoleWindow.SetWindowTopPosition(_consoleWindow.WindowStartIndex + (Position - _consoleWindow.WindowStartIndex - LookAheadInConsole));
        } else if (Position > _consoleWindow.WindowEndIndex - LookAheadInConsole - 1)
        {
            _consoleWindow.SetWindowTopPosition(_consoleWindow.WindowStartIndex + (Position - _consoleWindow.WindowEndIndex + LookAheadInConsole));
        }
        
        _consoleWindow.RefreshDisplay();
    }

    public string GetSelectedContent()
    {
        return _consoleWindow.Content[Position];
    }
}