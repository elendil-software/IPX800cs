using IPX800cs.IO;

namespace TestConsoleApplication.Configuration
{
    public class TestCase
    {
        public string Command { get; set; }
        public int Number { get; set; }
        public int? Delay { get; set; }
        public OutputState? State { get; set; }
        
    }
}