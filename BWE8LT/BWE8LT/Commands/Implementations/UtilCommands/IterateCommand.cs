using BWE8LT.Controller;
using BWE8LT.Services;

namespace BWE8LT.Commands.Implementations.UtilCommands;

public class IterateCommand : ICommand
{
    private static string Times { get; set; } = String.Empty;

    private static List<string> OriginalFooter { get; } = new List<string>();
    
    public void Execute(ConsoleKey pressedKey, ConsoleController consoleController)
    {
        if (OriginalFooter.Count == 0 && consoleController.CurrentWindow.FooterContent.Count > 0)
        {
            OriginalFooter.AddRange(consoleController.CurrentWindow.FooterContent[1..]);
        }
        
        Times += pressedKey.ToString()[^1];
        
        consoleController.CurrentWindow.UpdateFooter([Times]);
        consoleController.CurrentWindow.RefreshDisplay();
        
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
        consoleController.CurrentWindow.UpdateFooter(OriginalFooter);
        consoleController.CurrentWindow.RefreshDisplay();
    }
}