using BWE8LT.Utils;

namespace BWE8LT.Services;

public class FileService
{
    public string CurrentWorkingDirectory { get; set; }

    public string[] Files { get; set; }

    private static FileService _instance;

    public static FileService Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new FileService();
            }
            
            return _instance;
        }
    }

    private FileService()
    {
        CurrentWorkingDirectory = Directory.GetCurrentDirectory();
        ReadAllFiles(CurrentWorkingDirectory);
    }

    public void OpenDirectory(string directory)
    {
        CurrentWorkingDirectory = Path.Join(CurrentWorkingDirectory, directory);
        ReadAllFiles(CurrentWorkingDirectory);
        ConsoleHelper.Instance.WriteAllFilesToConsole(Files);
        ConsoleHelper.Instance.UpdateHeader(["Current Working directory:", CurrentWorkingDirectory]);
    }

    public void LeaveDirectory()
    {
        int indexOfLastSeparator = CurrentWorkingDirectory.LastIndexOf(Path.DirectorySeparatorChar);
        
        if (CurrentWorkingDirectory.IndexOf(Path.VolumeSeparatorChar) == indexOfLastSeparator - 1)
        {
            if (indexOfLastSeparator == CurrentWorkingDirectory.Length - 1)
            {
                return;
            }
            
            CurrentWorkingDirectory = CurrentWorkingDirectory.Substring(0, indexOfLastSeparator + 1);
            ReadAllFiles(CurrentWorkingDirectory);
            ConsoleHelper.Instance.WriteAllFilesToConsole(Files);
            ConsoleHelper.Instance.UpdateHeader(["Current Working directory:", CurrentWorkingDirectory]);
            return;
        }
        
        CurrentWorkingDirectory = CurrentWorkingDirectory.Substring(0, indexOfLastSeparator);
        ReadAllFiles(CurrentWorkingDirectory);
        ConsoleHelper.Instance.UpdateHeader(["Current Working directory:", CurrentWorkingDirectory]);
        ConsoleHelper.Instance.WriteAllFilesToConsole(Files);
    }
    
    public void ReadAllFiles(string path)
    {
        Files = Directory.GetFileSystemEntries(path).Select(x => x.Substring(path.Length)).ToArray();
    }
}