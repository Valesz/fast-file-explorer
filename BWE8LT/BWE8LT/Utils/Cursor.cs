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
        if (Position < _fileService.Files.Length)
            _consoleHelper.RewriteLine(Position, _fileService.Files[Position]);
     
        Position = Math.Clamp(newCursorPosition, 0, _fileService.Files.Length - 1);
        
        Console.ForegroundColor = ConsoleColor.Green;
        _consoleHelper.RewriteLine(Position, _fileService.Files[Position]);
        Console.ResetColor();
    }
}