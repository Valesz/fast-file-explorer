using BWE8LT.Commands.CommandTypes;
using BWE8LT.Controller;

namespace BWE8LT.Commands.CommandImplementations.KeyCommands.WindowCommands;

public class DeleteCurrentWindowCommand : AKeyCommand
{
    protected override void Execute(ConsoleKeyInfo pressedKey, IConsoleController consoleController)
    {
        if (consoleController.Windows.Count <= 1)
        {
            return;
        }
        
        int oldIndex = consoleController.GetIndexOfCurrentWindow();
        int newIndex = Math.Clamp(oldIndex, 0, consoleController.Windows.Count - 1);

        consoleController.DeleteWindow(oldIndex);
        
        consoleController.SwitchCurrentWindow(newIndex);
        
        consoleController.CurrentWindow.UpdateFooter([consoleController.GetWindowIndicators()]);
        consoleController.CurrentWindow.RefreshDisplay();
    }
}