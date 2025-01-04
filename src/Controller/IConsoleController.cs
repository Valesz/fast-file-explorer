using BWE8LT.Services;

namespace BWE8LT.Controller;

public interface IConsoleController
{
    public ICommandService CommandService { get; }
    
    public IWindow CurrentWindow { get; set; }
    
    public List<IWindow> Windows { get; }
    
    public List<string> Clipboard { get; }

    public int CreateNewWindow(string workingDirectory);

    public void DeleteWindow(int index);

    public void SwitchCurrentWindow(int index);

    public int GetIndexOfCurrentWindow();

    public string GetWindowIndicators();

    public void Copy(string[] path);
}