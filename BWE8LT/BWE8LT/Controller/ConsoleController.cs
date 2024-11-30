using BWE8LT.Utils;

namespace BWE8LT.Services;

public class ConsoleController
{
	public ConsoleWindow CurrentWindow { get; set; }

	public List<ConsoleWindow> Windows { get; }

	public ConsoleController(string workingDirectory)
	{
		Windows = new List<ConsoleWindow>();
		
		ConsoleWindow initalWindow = new ConsoleWindow(workingDirectory);
		
		CurrentWindow = initalWindow;
		Windows.Add(initalWindow);
	}
}