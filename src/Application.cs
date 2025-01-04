using BWE8LT.Controller;
using BWE8LT.Controller.Implementations;
using BWE8LT.Services;
using BWE8LT.Services.Implementations;

namespace BWE8LT;

public static class Application
{
    public static void Start(string currentWorkingDirectory)
    {
        ICommandService commandService = new CommandService();
        IConsoleController consoleController = new ConsoleController(currentWorkingDirectory, commandService);
        try
        {
            consoleController.CommandService.LoadCommands(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "Commands.json"));
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
        consoleController.CurrentWindow.FileService.ReadAllFiles(
            consoleController.CurrentWindow.FileService.WorkingDirectory
        );
        
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
            ConsoleKeyInfo pressedKey = consoleController.CommandService.ReadKeyCommand();
            consoleController.CommandService.ExecuteKeyCommand(pressedKey, consoleController);
        }
    }
}