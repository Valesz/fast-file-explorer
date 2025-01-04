namespace BWE8LT;

static class Program
{
    static void Main(string[] args)
    {
        Application.Start(args.Length > 0 && Directory.Exists(args[0]) ? args[0] : Directory.GetCurrentDirectory());
    }
}
