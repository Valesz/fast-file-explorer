using BWE8LT.Commands.CommandTypes;
using BWE8LT.Controller;

namespace BWE8LT.Commands.CommandImplementations.KeyCommands.WindowCommands;

public class SwitchToLeftMostWindowCommand : AKeyCommand
{
    protected override void Execute(ConsoleKeyInfo pressedKey, IConsoleController consoleController)
    {
        consoleController.SwitchCurrentWindow(0);
        
        consoleController.CurrentWindow.UpdateFooter([consoleController.GetWindowIndicators()]);
        consoleController.CurrentWindow.RefreshDisplay();
    }
}