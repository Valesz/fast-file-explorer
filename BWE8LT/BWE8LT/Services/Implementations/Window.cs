using System.Text;

namespace BWE8LT.Services.Implementations;

public class Window : IWindow
{
    public List<string> HeaderContent { get; }
    
    public List<string> FooterContent { get; }

    private int ContentBufferSize { get; }
    
    public List<List<string>> Content { get; }

    public int WindowStartIndex { get; private set; }

    public int WindowEndIndex { get; private set; }

    public ICursor Cursor { get; }
    
    public IFileService FileService { get; }

    public Window(string workingDirectory)
    {
	    Cursor = new Cursor(this);
	    FileService = new FileService(workingDirectory);

        HeaderContent = ["Header", GetHeaderContentFooterDivider()];
        FooterContent = [GetHeaderContentFooterDivider(), ""];
        
        ContentBufferSize = 100;
        Content = [];
        
        WindowStartIndex = 0;
        WindowEndIndex = CalculateWindowHeight();
    }

    public int CalculateWindowHeight() => Console.WindowHeight - FooterContent.Count - HeaderContent.Count - 1;
    
    private static string GetHeaderContentFooterDivider() => new string('-', Console.WindowWidth);
    
    public void RefreshDisplay()
    {
        var originalCursorPosition = Console.GetCursorPosition().Top;
        Console.SetCursorPosition(0, 0);
        
        foreach (var line in HeaderContent)
        {
            Console.Write(line.PadRight(Console.WindowWidth));
        }
        
        for (int i = WindowStartIndex; i <= Math.Min(Content.Count - 1, WindowEndIndex); )
        {
            if (Cursor.Position == i)
                Console.ForegroundColor = ConsoleColor.Green;

            foreach (string line in Content[i])
            {
                Console.Write(line.PadRight(Console.WindowWidth));
                i++;
            }
            
            Console.ResetColor();
        }
        
        for (int i = Math.Min(Content.Count - 1, WindowEndIndex); i < WindowEndIndex; i++)
        {
            Console.Write("".PadRight(Console.WindowWidth));
        }

        foreach (var line in FooterContent)
        {
            Console.Write(line.PadRight(Console.WindowWidth));
        }

        if (Content.Count > CalculateWindowHeight())
        {
            DrawScrollBar();    
        }
        
        Console.SetCursorPosition(0, originalCursorPosition);
    }

    private static List<string> WrapText(string text, int width)
    {
        char[] letters = text.ToCharArray();
        List<string> lines = new List<string>();
        StringBuilder currentLine = new StringBuilder();

        foreach (char letter in letters)
        {
            if (currentLine.Length + 1 > width)
            {
                lines.Add(currentLine.ToString());
                currentLine.Clear();
            }

            currentLine.Append(letter);
        }

        if (currentLine.Length > 0)
        {
            lines.Add(currentLine.ToString());
        }

        return lines;
    }
    
    private void DrawScrollBar()
    {
        double visiblePercentage = (double)Cursor.Position / Content.Count;
        int indicatorPosition = (int)(visiblePercentage * CalculateWindowHeight());
        
        Console.ForegroundColor = ConsoleColor.DarkGray;
        for (int i = HeaderContent.Count; i < Console.WindowHeight - FooterContent.Count; i++)
        {
            Console.SetCursorPosition(Console.WindowWidth - 1, i);
            Console.Write("█");
        }
        
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(Console.WindowWidth - 1, HeaderContent.Count + indicatorPosition);
        
        Console.Write("█");
        
        Console.ResetColor();
    }

    public void SetWindowTopPosition(int top)
    {
        WindowStartIndex = Math.Clamp(top, 0, Content.Count);
        WindowEndIndex = WindowStartIndex + CalculateWindowHeight();
    }

    public void WriteLine(string line)
    {
        var lines = WrapText(line, Console.WindowWidth);
        Content.Add(lines);

        while (Content.Count > ContentBufferSize)
        {
            Content.RemoveAt(0);
        }
    }

    public void Write(string text)
    {
        if (Content.Count == 0)
        {
            Content[^1].Add(text);
            return;
        }

        if (Content[^1][^1].Length + text.Length + 1 > Console.WindowWidth)
        {
            var lines = WrapText(Content[^1] + text, Console.WindowWidth);
            
            Content.RemoveAt(Content.Count - 1);
            Content[^1].AddRange(lines);
            return;
        }
        
        Content[^1][^1] += text;
    }

    public void Clear()
    {
        Content.Clear();
        WindowStartIndex = 0;
        WindowEndIndex = CalculateWindowHeight();
    }

    public void UpdateHeader(List<string> header)
    {
        var lines = new List<string>();
        foreach (var line in header)
        {
            lines.AddRange(WrapText(line, Console.WindowWidth));
        }
        
        HeaderContent.Clear();
        HeaderContent.AddRange(lines);
        HeaderContent.Add(GetHeaderContentFooterDivider());

        WindowEndIndex = WindowStartIndex + CalculateWindowHeight();
    }

    public void UpdateFooter(List<string> footer)
    {
        var lines = new List<string>();
        foreach (var line in footer)
        {
            lines.AddRange(WrapText(line, Console.WindowWidth));
        }
        
        FooterContent.Clear();
        FooterContent.Add(GetHeaderContentFooterDivider());
        FooterContent.AddRange(lines);

        WindowEndIndex = WindowStartIndex + CalculateWindowHeight();
    }

    public void WriteLoadedFilesToConsole()
    {
        StringBuilder lineBuilder = new StringBuilder();
        int count = 1;
        
        foreach (var file in FileService.Files)
        {
            lineBuilder.Append($"{count}. {file.Name} - ");
            lineBuilder.Append(file.IsDirectory ? "(DIR)" : "(FILE)");
            
            this.WriteLine(lineBuilder.ToString());
            lineBuilder.Clear();
            count++;
        }
    }

    public void SetCursorVisibility(bool visibility)
    {
        Console.CursorVisible = visibility;
    }
}