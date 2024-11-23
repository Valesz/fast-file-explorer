using BWE8LT.Services;

namespace BWE8LT.Utils;

public class ConsoleHelper
{
    private List<string> HeaderContent { get; set; }
    
    private List<string> FooterContent { get; set; }

    private int ContentBufferSize { get; set; }
    
    public List<string> Content { get; }

    public int WindowStartIndex { get; set; }

    public int WindowEndIndex { get; set; }
    
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
        Console.CursorVisible = false;

        HeaderContent = ["Header", GetHeaderContentFooterDivider()];
        FooterContent = [GetHeaderContentFooterDivider(), ""];
        
        ContentBufferSize = 100;
        Content = [];
        
        WindowStartIndex = 0;
        WindowEndIndex = CalculateWindowEndIndex();
        
        RefreshDisplay();
    }

    private int CalculateWindowEndIndex() => Console.WindowHeight - FooterContent.Count - HeaderContent.Count;
    
    private string GetHeaderContentFooterDivider() => new string('-', Console.WindowWidth);
    
    public void RefreshDisplay()
    {
        var originalCursorPosition = Console.GetCursorPosition().Top;
        Console.SetCursorPosition(0, 0);
        
        foreach (var line in HeaderContent)
        {
            Console.Write(line.PadRight(Console.WindowWidth));
        }

        for (int i = WindowStartIndex; i < Math.Min(Content.Count, WindowEndIndex); i++)
        {
            if (Cursor.Instance.Position == i)
                Console.ForegroundColor = ConsoleColor.Green;
                
            Console.Write(Content[i].PadRight(Console.WindowWidth));
            
            Console.ResetColor();
        }
        
        for (int i = Math.Min(Content.Count, WindowEndIndex); i < WindowEndIndex; i++)
        {
            Console.Write("".PadRight(Console.WindowWidth));
        }

        foreach (var line in FooterContent)
        {
            Console.Write(line.PadRight(Console.WindowWidth));
        }
        
        Console.SetCursorPosition(0, originalCursorPosition);
    }

    public void WriteLine(string line)
    {
        Content.Add(line);

        while (Content.Count > ContentBufferSize)
        {
            Content.RemoveAt(0);
        }
        
        RefreshDisplay();
    }

    public void Write(string text)
    {
        if (Content.Count == 0)
        {
            Content.Add(text);
        }
        else
        {
            Content[^1] += text;
        }
        
        RefreshDisplay();
    }

    public void Clear()
    {
        Content.Clear();
        WindowStartIndex = 0;
        WindowEndIndex = CalculateWindowEndIndex();
        
        RefreshDisplay();
    }

    public void UpdateHeader(List<string> header)
    {
        HeaderContent = header;
        HeaderContent.Add(GetHeaderContentFooterDivider());

        WindowEndIndex = CalculateWindowEndIndex();
        RefreshDisplay();
    }

    public void UpdateFooter(List<string> footer)
    {
        FooterContent = footer;
        FooterContent.Add(GetHeaderContentFooterDivider());
        
        WindowEndIndex = CalculateWindowEndIndex();
        RefreshDisplay();
    }
    
    public void RewriteLine(int linePosition, string line)
    {
        Content[linePosition] = line;
        
        RefreshDisplay();
    }

    public void WriteAllFilesToConsole(string[] files)
    {
        this.Clear();
        
        for (int i = 0; i < files.Length; i++)
        {
            this.WriteLine(files[i]);
        }
    }
}