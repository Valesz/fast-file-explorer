using BWE8LT.Controller;
using BWE8LT.Services;

namespace BWE8LT;

public static class Application
{
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
        consoleController.CurrentWindow.WriteLoadedFilesToConsole();
        
        consoleController.CurrentWindow.Cursor.MoveCursor(0);
        consoleController.CurrentWindow.RefreshDisplay();

        while (true)
        {
            ConsoleKey pressedKey = CommandService.ReadCommandKey();
            CommandService.ExecuteCommand(pressedKey, consoleController);
        }
    }
}