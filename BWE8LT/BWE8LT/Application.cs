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
        
        consoleController.CurrentWindow.SetCursorVisibility(false);
        consoleController.CurrentWindow.FileService.ReadAllFiles(consoleController.CurrentWindow.FileService.WorkingDirectory);
        
        consoleController.CurrentWindow.UpdateHeader([
            "Current working directory:", 
            consoleController.CurrentWindow.FileService.WorkingDirectory
        ]);
        consoleController.CurrentWindow.WriteLoadedFilesToConsole();
        consoleController.CurrentWindow.UpdateFooter([consoleController.GetWindowIndicators()]);
        
        consoleController.CurrentWindow.Cursor.MoveCursor(0);
        consoleController.CurrentWindow.RefreshDisplay();

        while (true)
        {
            ConsoleKeyInfo pressedKey = CommandService.ReadKeyCommand();
            CommandService.ExecuteKeyCommand(pressedKey, consoleController);
        }
    }
}