namespace BWE8LT.Services;

public class FileService
{
    public string WorkingDirectory { get; set; }

    public string[] Files { get; set; }

    public FileService(string workingDirectory)
    {
        WorkingDirectory = workingDirectory;
        ReadAllFiles(WorkingDirectory);
    }

    public void OpenDirectory(string directory)
    {
        WorkingDirectory = Path.Join(WorkingDirectory, directory);
        ReadAllFiles(WorkingDirectory);
    }

    public void LeaveDirectory()
    {
        int indexOfLastSeparator = WorkingDirectory.LastIndexOf(Path.DirectorySeparatorChar);
        
        if (WorkingDirectory.IndexOf(Path.VolumeSeparatorChar) == indexOfLastSeparator - 1)
        {
            if (indexOfLastSeparator == WorkingDirectory.Length - 1)
            {
                return;
            }
            
            WorkingDirectory = WorkingDirectory.Substring(0, indexOfLastSeparator + 1);
            ReadAllFiles(WorkingDirectory);
            return;
        }
        
        WorkingDirectory = WorkingDirectory.Substring(0, indexOfLastSeparator);
        ReadAllFiles(WorkingDirectory);
    }
    
    public void ReadAllFiles(string path)
    {
        Files = Directory.GetFileSystemEntries(path).Select(x => x.Substring(path.Length)).ToArray();
    }

    public bool IsAtVolumeRoot() =>
        WorkingDirectory.LastIndexOf(Path.DirectorySeparatorChar) == WorkingDirectory.Length - 1;
    
    public string GetLastDirectoryInPath()
    {
        if (IsAtVolumeRoot())
        {
            return WorkingDirectory.Substring(0, WorkingDirectory.LastIndexOf(Path.DirectorySeparatorChar));
        }

        return WorkingDirectory.Substring(WorkingDirectory.LastIndexOf(Path.DirectorySeparatorChar));
    }
}