namespace TestConsoleApplication;

internal class Program
{
    public static void Main(string[] args)
    {
        string configFile = args.Length == 1 ? args[0] : "config.json";
        new IPX800Tester(configFile).Execute();

        //Console.WriteLine("Press a key");
        //Console.ReadKey();
    }
}