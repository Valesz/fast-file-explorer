using BWE8LT.Controller;

namespace BWE8LT.Commands.Implementations.WindowCommands;

public class SwitchToLeftWindowFromCurrentCommand : ICommand
{
    public void Execute(ConsoleKey pressedKey, ConsoleController consoleController)
    {
        consoleController.SwitchCurrentWindow(consoleController.GetIndexOfCurrentWindow() - 1);
        
        consoleController.UpdateWindowIndicators();
        consoleController.CurrentWindow.RefreshDisplay();
    }
}