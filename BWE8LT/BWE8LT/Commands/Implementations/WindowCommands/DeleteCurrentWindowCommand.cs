using BWE8LT.Services;

namespace BWE8LT.Commands.Implementations.WindowCommands;

public class DeleteCurrentWindowCommand : ICommand
{
    public void Execute(ConsoleKey pressedKey, ConsoleController consoleController)
    {
        int oldIndex = consoleController.GetIndexOfCurrentWindow();
        int newIndex = Math.Max(oldIndex - 1, 0);

        consoleController.DeleteWindow(oldIndex);
        
        consoleController.SwitchCurrentWindow(newIndex);
        
        consoleController.UpdateWindowIndicators();
    }
}