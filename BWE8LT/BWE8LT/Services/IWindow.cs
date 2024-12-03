namespace BWE8LT.Services;

public interface IWindow
{
    public List<string> HeaderContent { get; }
    
    public List<string> FooterContent { get; }
    
    public List<List<string>> Content { get; }
    
    public ICursor Cursor { get; }
    
    public IFileService FileService { get; }

    public int CalculateWindowHeight();

    public void RefreshDisplay();

    public void SetWindowTopPosition(int top);

    public void Clear();

    public void UpdateHeader(List<string> header);

    public void UpdateFooter(List<string> footer);

    public void WriteLoadedFilesToConsole();

    public void SetCursorVisibility(bool visibility);
}