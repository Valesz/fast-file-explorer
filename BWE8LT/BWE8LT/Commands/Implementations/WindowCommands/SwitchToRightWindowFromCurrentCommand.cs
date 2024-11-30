using BWE8LT.Services;

namespace BWE8LT.Commands.Implementations.WindowCommands;

public class SwitchToRightWindowFromCurrentCommand : ICommand
{
    public void Execute(ConsoleKey pressedKey, ConsoleController consoleController)
    {
        consoleController.SwitchCurrentWindow(consoleController.GetIndexOfCurrentWindow() + 1);
        
        consoleController.UpdateWindowIndicators();
    }
}