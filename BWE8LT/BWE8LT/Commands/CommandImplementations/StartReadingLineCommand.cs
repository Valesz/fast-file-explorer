using BWE8LT.Commands.CommandTypes;
using BWE8LT.Controller;
using BWE8LT.Services;

namespace BWE8LT.Commands.CommandImplementations;

public class StartReadingLineCommand : IKeyCommand
{
    public void Execute(ConsoleKeyInfo pressedKey, ConsoleController consoleController)
    {
        consoleController.CurrentWindow.UpdateFooter(["", consoleController.GetWindowIndicators()]);
        consoleController.CurrentWindow.RefreshDisplay();
        
        Console.SetCursorPosition(
            0, 
            consoleController.CurrentWindow.HeaderContent.Count 
                + consoleController.CurrentWindow.CalculateWindowHeight() + 1
        );
        consoleController.CurrentWindow.SetCursorVisibility(true);
        
        string line = CommandService.ReadLineCommand();
        
        consoleController.CurrentWindow.SetCursorVisibility(false);
        consoleController.CurrentWindow.UpdateFooter([consoleController.GetWindowIndicators()]);
        Console.SetCursorPosition(0, 0);
        
        CommandService.ExecuteLineCommand(line, consoleController);
    }
}