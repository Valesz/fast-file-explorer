using BWE8LT.Commands.CommandTypes;
using BWE8LT.Controller;
using BWE8LT.Services;

namespace BWE8LT.Commands.CommandImplementations.KeyCommands.UtilCommands;

public class IterateCommand : IKeyCommand
{
    private static string Times { get; set; } = String.Empty;

    private static List<string> OriginalFooter { get; } = new List<string>();
    
    public void Execute(ConsoleKeyInfo pressedKey, ConsoleController consoleController)
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
        
        ConsoleKeyInfo commandKey = CommandService.ReadKeyCommand();
        if (Int32.TryParse(commandKey.Key.ToString()[^1].ToString(), out _))
        {
            CommandService.ExecuteKeyCommand(commandKey, consoleController);
            return;
        }
        
        for (int i = 0; i < Int32.Parse(Times); i++)
        {
            CommandService.ExecuteKeyCommand(commandKey, consoleController);
        }
        
        Times = String.Empty;
        consoleController.CurrentWindow.UpdateFooter([consoleController.GetWindowIndicators()]);
        consoleController.CurrentWindow.RefreshDisplay();
    }
}