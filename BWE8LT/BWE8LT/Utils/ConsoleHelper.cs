using BWE8LT.Services;

namespace BWE8LT.Utils;

public class ConsoleHelper
{
    private List<string> consoleBuffer = new List<string>();
    
    private static ConsoleHelper _instance;

    public static ConsoleHelper Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ConsoleHelper();
            }
            
            return _instance;
        }
    }

    private ConsoleHelper()
    {
        
    }
    
    public void RewriteLine(int linePosition, string line)
    {
        Console.SetCursorPosition(0, linePosition);
        Console.Write(line.PadRight(Console.WindowWidth));
        Console.SetCursorPosition(0, linePosition);
    }

    public void WriteAllFilesToConsole(string[] files)
    {
        Console.Clear();
        
        for (int i = 0; i < files.Length; i++)
        {
            this.RewriteLine(i, files[i]);
        }
    }
}