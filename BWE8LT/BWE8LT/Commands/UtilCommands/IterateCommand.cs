using BWE8LT.Services;

namespace BWE8LT.Commands.UtilCommands;

public class IterateCommand : ICommand
{
    private static string Times { get; set; } = String.Empty;
    
    public void Execute(ConsoleKey pressedKey, ConsoleController consoleController)
    {
        Times += pressedKey.ToString()[^1];
        
        consoleController.CurrentWindow.UpdateFooter([Times]);
        
        ConsoleKey commandKey = CommandService.ReadCommandKey();
        if (Int32.TryParse(commandKey.ToString()[^1].ToString(), out _))
        {
            CommandService.ExecuteCommand(commandKey, consoleController);
            return;
        }
        
        for (int i = 0; i < Int32.Parse(Times); i++)
        {
            CommandService.ExecuteCommand(commandKey, consoleController);
        }
        
        Times = String.Empty;
        consoleController.CurrentWindow.UpdateFooter([""]);
    }
}