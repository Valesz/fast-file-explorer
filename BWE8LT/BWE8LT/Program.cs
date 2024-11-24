using System.ComponentModel;
using System.Runtime.CompilerServices;

using BWE8LT.Commands;
using BWE8LT.Model;
using BWE8LT.Services;
using BWE8LT.Utils;

namespace BWE8LT;

class Program
{
    static void Main(string[] args)
    {
        Start(args.Length > 0 ? args[0] : Directory.GetCurrentDirectory());
    }

    public static void Start(string currentWorkingDirectory)
    {
        try
        {
            CommandService.Instance.LoadCommands(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "Commands.json"));
        }
        catch (DirectoryNotFoundException ex)
        {
            Console.Error.WriteLine(ex.Message);
            Environment.Exit(-1);
        }
        catch (ArgumentException ex)
        {
            Console.Error.WriteLine(ex.Message);
            Environment.Exit(-1);
        }
        
        Console.Clear();
        
        FileService.Instance.CurrentWorkingDirectory = currentWorkingDirectory;
        FileService.Instance.ReadAllFiles(FileService.Instance.CurrentWorkingDirectory);
        
        ConsoleHelper.Instance.UpdateHeader(["Current Working Directory:", FileService.Instance.CurrentWorkingDirectory]);
        ConsoleHelper.Instance.WriteAllFilesToConsole(FileService.Instance.Files);
        
        Cursor.Instance.MoveCursor(0);

        while (true)
        {
            ConsoleKey pressedKey = CommandService.Instance.ReadCommandKey();
            CommandService.Instance.ExecuteCommand(pressedKey);
        }
    }
}
