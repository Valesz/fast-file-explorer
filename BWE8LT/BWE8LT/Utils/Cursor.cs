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

    private Cursor(FileService fileService, ConsoleHelper helper)
    {
        _fileService = fileService;
        _consoleHelper = helper;
    }
    
    public void MoveCursor(int newCursorPosition)
    {
        Position = Math.Clamp(newCursorPosition, 0, _consoleHelper.Content.Count - 1);

        if (Position > _consoleHelper.WindowEndIndex - 5)
        {
            _consoleHelper.WindowStartIndex++;
            _consoleHelper.WindowEndIndex++;
        } else if (Position < _consoleHelper.WindowStartIndex + 4)
        {
            int predictedWindowStartIndex = Math.Max(_consoleHelper.WindowStartIndex - 1, -1);
            if (predictedWindowStartIndex <= -1)
            {
                _consoleHelper.RefreshDisplay();
                return;
            }
            
            _consoleHelper.WindowStartIndex--;
            _consoleHelper.WindowEndIndex--;
        }
        
        _consoleHelper.RefreshDisplay();
    }

    public string GetSelectedContent()
    {
        return _consoleHelper.Content[Position];
    }
}