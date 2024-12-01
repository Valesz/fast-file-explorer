using BWE8LT.Model;

namespace BWE8LT.Services.Implementations;

public class FileService : IFileService
{
    public string WorkingDirectory { get; set; }

    public FileItem[] Files { get; set; }

    public FileService(string workingDirectory)
    {
        WorkingDirectory = workingDirectory;
        ReadAllFiles(WorkingDirectory);
    }

    public string OpenDirectory(string path)
    {
        if (!Directory.Exists(path))
        {
            return WorkingDirectory;
        }
        
        WorkingDirectory = path;
        return WorkingDirectory;
    }

    public string LeaveDirectory()
    {
        int indexOfLastSeparator = WorkingDirectory.LastIndexOf(Path.DirectorySeparatorChar);
        
        if (WorkingDirectory.IndexOf(Path.VolumeSeparatorChar) == indexOfLastSeparator - 1)
        {
            if (indexOfLastSeparator == WorkingDirectory.Length - 1)
            {
                return WorkingDirectory;
            }
            
            WorkingDirectory = WorkingDirectory.Substring(0, indexOfLastSeparator + 1);
            return WorkingDirectory;
        }
        
        WorkingDirectory = WorkingDirectory.Substring(0, indexOfLastSeparator);
        return WorkingDirectory;
    }
    
    public void ReadAllFiles(string path)
    {
        Files = Directory.GetFileSystemEntries(path).Select(entry => new FileItem(
            entry,
            entry.Substring(entry.LastIndexOf(Path.DirectorySeparatorChar) + 1),
            Directory.Exists(entry)
        )).OrderByDescending(entry => entry.IsDirectory).ToArray();
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

    public string GetFullPathForLoadedFile(int index)
    {
        return Files[index].FullPath;
    }
    
    public void PasteDirectory(string sourcePath, string destinationPath)
    {
        if (destinationPath.StartsWith(sourcePath))
        {
            throw new ArgumentException("You cannot copy something into it's own subdirectory");
        }
        
        string directoryName = new DirectoryInfo(sourcePath).Name;
        string newDestinationDir = Path.Combine(destinationPath, directoryName);

        if (Directory.Exists(newDestinationDir))
        {
            int counter = 1;

            while (Directory.Exists(newDestinationDir))
            {
                directoryName = $"{directoryName}_({counter})";
                newDestinationDir = Path.Combine(destinationPath, directoryName);
                counter++;   
            }
        }
        
        string[] files = Directory.GetFiles(sourcePath);
        string[] directories = Directory.GetDirectories(sourcePath);
        
        Directory.CreateDirectory(newDestinationDir);
        
        foreach (string filePath in files)
        {
            PasteFile(filePath, newDestinationDir);
        }
        
        foreach (string directoryPath in directories)
        {
            PasteDirectory(directoryPath, newDestinationDir);
        }
    }

    public void PasteFile(string sourcePath, string destinationPath)
    {
        string fileName = Path.GetFileName(sourcePath);
        string destinationFilePath = Path.Combine(destinationPath, fileName);

        if (File.Exists(destinationFilePath))
        {
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
            string extension = Path.GetExtension(fileName);
            int counter = 1;

            while (File.Exists(destinationFilePath))
            {
                fileName = $"{fileNameWithoutExtension}_({counter}){extension}";
                destinationFilePath = Path.Combine(destinationPath, fileName);
                counter++;
            }
        }

        File.Copy(sourcePath, destinationFilePath);
    }

    public void DeleteFile(string pathToFile)
    {
        if (!File.Exists(pathToFile))
        {
            return;
        }
        
        File.Delete(pathToFile);
    }

    public void DeleteDirectory(string pathToDirectory)
    {
        if (!Directory.Exists(pathToDirectory))
        {
            return;
        }
        
        Directory.Delete(pathToDirectory, true);
    }
}