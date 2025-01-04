using BWE8LT.Model;

namespace BWE8LT.Services;

public interface IFileService
{
    public string WorkingDirectory { get; }
    
    public FileItem[] Files { get; set; }

    public string OpenDirectory(string path);

    public string LeaveDirectory();

    public void ReadAllFiles(string path);

    public string GetLastDirectoryInPath();

    public string GetFullPathForLoadedFile(int index);

    public void PasteDirectory(string sourcePath, string destinationPath);

    public void PasteFile(string sourcePath, string destinationPath);

    public void DeleteFile(string pathToFile);

    public void DeleteDirectory(string pathToDirectory);
}