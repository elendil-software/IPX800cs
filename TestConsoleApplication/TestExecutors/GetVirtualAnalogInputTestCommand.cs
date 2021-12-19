using IPX800cs;
using TestConsoleApplication.Configuration;

namespace TestConsoleApplication.TestExecutors
{
    internal class GetVirtualAnalogInputTestCommand : TestCommandBase
    {
        public GetVirtualAnalogInputTestCommand(TestCase testCase, IIPX800 ipx800, LogFile logFile) : base(testCase, ipx800, logFile)
        {
        }

        protected override string ExecuteCommand() => IPX800.GetVirtualAnalogInput(TestCase.Number).ToString();
    }
}