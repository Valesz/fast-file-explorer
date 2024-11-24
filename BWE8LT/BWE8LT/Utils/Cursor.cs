using BWE8LT.Services;

namespace BWE8LT.Utils;

public class Cursor
{
    private readonly FileService _fileService;
    
    private readonly ConsoleHelper _consoleHelper;
    
    private static Cursor _instance;

    public static Cursor Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Cursor(FileService.Instance, ConsoleHelper.Instance);
            }
            
            return _instance;
        }
    }
    
    public int Position { get; private set; }

    public int LookAheadInConsole { get; set; }
    
    private Cursor(FileService fileService, ConsoleHelper helper)
    {
        _fileService = fileService;
        _consoleHelper = helper;
        
        LookAheadInConsole = 4;
    }
    
    public void MoveCursor(int newCursorPosition)
    {
        if (newCursorPosition < 0 || newCursorPosition > _consoleHelper.Content.Count - 1 || Position == newCursorPosition)
        {
            return;
        }
        
        Position = newCursorPosition;

        if (Position < _consoleHelper.WindowStartIndex + LookAheadInConsole)
        {
            _consoleHelper.SetWindowTopPosition(_consoleHelper.WindowStartIndex + (Position - _consoleHelper.WindowStartIndex - LookAheadInConsole));
        } else if (Position > _consoleHelper.WindowEndIndex - LookAheadInConsole - 1)
        {
            _consoleHelper.SetWindowTopPosition(_consoleHelper.WindowStartIndex + (Position - _consoleHelper.WindowEndIndex + LookAheadInConsole));
        }
        
        _consoleHelper.RefreshDisplay();
    }

    public string GetSelectedContent()
    {
        return _consoleHelper.Content[Position];
    }
}