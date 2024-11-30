using System.Text;

using BWE8LT.Utils;

namespace BWE8LT.Services;

public class ConsoleController
{
	public ConsoleWindow CurrentWindow { get; set; }

	public List<ConsoleWindow> Windows { get; }

	public ConsoleController(string workingDirectory)
	{
		Windows = new List<ConsoleWindow>();
		
		ConsoleWindow initalWindow = new ConsoleWindow(workingDirectory);
		
		CurrentWindow = initalWindow;
		Windows.Add(initalWindow);
        
        UpdateWindowIndicators();
	}

    public int CreateNewWindow(string workingDirectory)
    {
        ConsoleWindow newWindow = new ConsoleWindow(workingDirectory);
        Windows.Add(newWindow);
        
        return Windows.Count;
    }

    public void DeleteWindow(int index)
    {
        if (Windows.Count == 1)
        {
            return;
        }
        
        Windows.RemoveAt(index);
    }

    public void SwitchCurrentWindow(int index)
    {
        int indexOfWindow = Math.Clamp(index, 0, Windows.Count - 1);
        
        CurrentWindow = Windows[indexOfWindow];
        
        CurrentWindow.RefreshDisplay();
    }

    public int GetIndexOfCurrentWindow()
    {
        return Windows.IndexOf(CurrentWindow);
    }

    public void UpdateWindowIndicators()
    {
        StringBuilder footerString = new StringBuilder();
        
        foreach (ConsoleWindow window in Windows)
        {
            if (window == CurrentWindow)
            {
                footerString.Append($"*{window.FileService.GetLastDirectoryInPath()}*, ");
                continue;
            }
            
            footerString.Append($"{window.FileService.GetLastDirectoryInPath()}, ");
        }

        footerString.Remove(footerString.Length - 2, 2);
        
        CurrentWindow.UpdateFooter([footerString.ToString()]);
    }
}