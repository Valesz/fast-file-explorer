using BWE8LT.Commands.CommandTypes;
using BWE8LT.Controller;

namespace BWE8LT.Commands.CommandImplementations.KeyCommands.UtilCommands;

public class IterateCommand : AKeyCommand
{
    private static string Times { get; set; } = String.Empty;

    private static List<string> OriginalFooter { get; } = new List<string>();
    
    protected override void Execute(ConsoleKeyInfo pressedKey, IConsoleController consoleController)
    {
        if (OriginalFooter.Count == 0 && consoleController.CurrentWindow.FooterContent.Count > 0)
        {
            OriginalFooter.AddRange(consoleController.CurrentWindow.FooterContent[1..]);
        }
        
        Times += pressedKey.Key.ToString()[^1];
        
        consoleController.CurrentWindow.UpdateFooter([
            Times,
            consoleController.GetWindowIndicators()
        ]);

        consoleController.CurrentWindow.RefreshDisplay();
        
        ConsoleKeyInfo commandKey = consoleController.CommandService.ReadKeyCommand();
        if (Int32.TryParse(commandKey.Key.ToString()[^1].ToString(), out _))
        {
            consoleController.CommandService.ExecuteKeyCommand(commandKey, consoleController);
            return;
        }

        if (!Int32.TryParse(Times, out int timesInt))
        {
            Times = String.Empty;
            throw new ArgumentException("Value is either too large or not given!");
        }
        
        for (int i = 0; i < timesInt; i++)
        {
            consoleController.CommandService.ExecuteKeyCommand(commandKey, consoleController);
        }
        
        Times = String.Empty;
        consoleController.CurrentWindow.UpdateFooter([consoleController.GetWindowIndicators()]);
        consoleController.CurrentWindow.RefreshDisplay();
    }
}