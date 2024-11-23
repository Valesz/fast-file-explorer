using System.ComponentModel;
using BWE8LT.Commands;
using BWE8LT.Model;
using BWE8LT.Services;
using BWE8LT.Utils;

namespace BWE8LT;

class Program
{
    static void Main(string[] args)
    {
        CommandService commandConfig = new CommandService(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "Commands.json"));
        try
        {
            commandConfig.LoadCommands();
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
        
        FileService.Instance.CurrentWorkingDirectory = args.Length > 0 ? args[0] : Directory.GetCurrentDirectory();
        FileService.Instance.ReadAllFiles(FileService.Instance.CurrentWorkingDirectory);
        
        ConsoleHelper.Instance.UpdateHeader(["Current Working Directory:", FileService.Instance.CurrentWorkingDirectory]);
        ConsoleHelper.Instance.WriteAllFilesToConsole(FileService.Instance.Files);
        
        Cursor.Instance.MoveCursor(0);

        while (true)
        {
            ConsoleKey action = Console.ReadKey().Key;
            try
            {
                ICommand.Commands[action].Invoke();
            }
            catch (KeyNotFoundException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }
    }
}
