using BWE8LT.Commands.CommandTypes;
using BWE8LT.Controller;

namespace BWE8LT.Commands.CommandImplementations.KeyCommands.WindowCommands;

public class SwitchToRightMostWindowCommand : AKeyCommand
{
    protected override void Execute(ConsoleKeyInfo pressedKey, IConsoleController consoleController)    
    {
        consoleController.SwitchCurrentWindow(consoleController.Windows.Count - 1);
        
        consoleController.CurrentWindow.UpdateFooter([consoleController.GetWindowIndicators()]);
        consoleController.CurrentWindow.RefreshDisplay();
    }
}