using BWE8LT.Services;
using BWE8LT.Utils;

namespace BWE8LT.Commands.UtilCommands;

public class IterateCommand : ICommand
{
    private static string Times { get; set; } = String.Empty;
    
    public void Execute(ConsoleKey pressedKey)
    {
        Times += pressedKey.ToString()[^1];
        
        ConsoleHelper.Instance.UpdateFooter([Times]);
        
        ConsoleKey commandKey = CommandService.Instance.ReadCommandKey();
        if (Int32.TryParse(commandKey.ToString()[^1].ToString(), out _))
        {
            CommandService.Instance.ExecuteCommand(commandKey);
            return;
        }
        
        for (int i = 0; i < Int32.Parse(Times); i++)
        {
            CommandService.Instance.ExecuteCommand(commandKey);
        }
        
        Times = String.Empty;
        ConsoleHelper.Instance.UpdateFooter([""]);
    }
}