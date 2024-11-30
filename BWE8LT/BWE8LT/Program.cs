using BWE8LT.Services;

namespace BWE8LT;

static class Program
{
    static void Main(string[] args)
    {
        Start(args.Length > 0 ? args[0] : Directory.GetCurrentDirectory());
    }

    public static void Start(string currentWorkingDirectory)
    {
	    ConsoleController consoleController = new ConsoleController(currentWorkingDirectory);
        try
        {
            CommandService.LoadCommands(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "Commands.json"));
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
        Console.CursorVisible = false;
        
        consoleController.CurrentWindow.FileService.ReadAllFiles(consoleController.CurrentWindow.FileService.WorkingDirectory);
        
        consoleController.CurrentWindow.UpdateHeader([
	        "Current working directory:", 
	        consoleController.CurrentWindow.FileService.WorkingDirectory
        ]);
        consoleController.CurrentWindow.WriteAllFilesToConsole();
        
        consoleController.CurrentWindow.Cursor.MoveCursor(0);

        while (true)
        {
            ConsoleKey pressedKey = CommandService.ReadCommandKey();
            CommandService.ExecuteCommand(pressedKey, consoleController);
        }
    }
}
