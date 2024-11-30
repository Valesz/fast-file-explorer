using BWE8LT.Controller;

namespace BWE8LT.Commands.Implementations.WindowCommands;

public class DeleteCurrentWindowCommand : ICommand
{
    public void Execute(ConsoleKey pressedKey, ConsoleController consoleController)
    {
        if (consoleController.Windows.Count <= 1)
        {
            return;
        }
        
        int oldIndex = consoleController.GetIndexOfCurrentWindow();
        int newIndex = Math.Clamp(oldIndex, 0, consoleController.Windows.Count - 1);

        consoleController.DeleteWindow(oldIndex);
        
        consoleController.SwitchCurrentWindow(newIndex);
        
        consoleController.UpdateWindowIndicators();
        consoleController.CurrentWindow.RefreshDisplay();
    }
}