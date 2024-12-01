using System.Text;

namespace BWE8LT.Services.Implementations;

public class Window : IWindow
{
    public List<string> HeaderContent { get; }
    
    public List<string> FooterContent { get; }

    private int ContentBufferSize { get; }
    
    public List<string> Content { get; }

    public int WindowStartIndex { get; set; }

    public int WindowEndIndex { get; set; }

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

    public int CalculateWindowHeight() => Console.WindowHeight - FooterContent.Count - HeaderContent.Count;
    
    private static string GetHeaderContentFooterDivider() => new string('-', Console.WindowWidth);
    
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
            if (Cursor.Position == i)
                Console.ForegroundColor = ConsoleColor.Green;
                
            Console.Write($"{i + 1}. {Content[i]}".PadRight(Console.WindowWidth));
            
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

        if (Content.Count > CalculateWindowHeight())
        {
            DrawScrollBar();    
        }
        
        Console.SetCursorPosition(0, originalCursorPosition);
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
        Content.Add(line);

        while (Content.Count > ContentBufferSize)
        {
            Content.RemoveAt(0);
        }
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
    }

    public void Clear()
    {
        Content.Clear();
        WindowStartIndex = 0;
        WindowEndIndex = CalculateWindowHeight();
    }

    public void UpdateHeader(List<string> header)
    {
        HeaderContent.Clear();
        HeaderContent.AddRange(header);
        HeaderContent.Add(GetHeaderContentFooterDivider());

        WindowEndIndex = CalculateWindowHeight();
    }

    public void UpdateHeaderLine(int index, string line)
    {
        HeaderContent[index] = line;

        WindowEndIndex = CalculateWindowHeight();
    }

    public void UpdateFooter(List<string> footer)
    {
        FooterContent.Clear();
        FooterContent.Add(GetHeaderContentFooterDivider());
        FooterContent.AddRange(footer);

        WindowEndIndex = WindowStartIndex + CalculateWindowHeight();
    }

    public void UpdateFooterLine(int index, string line)
    {
        FooterContent[index] = line;

        WindowEndIndex = WindowStartIndex + CalculateWindowHeight();
    }
    
    public void RewriteLine(int linePosition, string line)
    {
        Content[linePosition] = line;
    }

    public void WriteLoadedFilesToConsole()
    {
        StringBuilder lineBuilder = new StringBuilder();
        
        foreach (var file in FileService.Files)
        {
            lineBuilder.Append(file.Name);
            lineBuilder.Append(" - ");
            lineBuilder.Append(file.IsDirectory ? "(DIR)" : "(FILE)");
            
            this.WriteLine(lineBuilder.ToString());
            lineBuilder.Clear();
        }
    }

    public void SetCursorVisibility(bool visibility)
    {
        Console.CursorVisible = visibility;
    }
}