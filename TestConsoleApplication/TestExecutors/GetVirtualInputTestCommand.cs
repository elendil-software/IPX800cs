using IPX800cs.Contracts;
using TestConsoleApplication.Configuration;

namespace TestConsoleApplication.TestExecutors
{
    internal class GetVirtualInputTestCommand : TestCommandBase
    {
        public GetVirtualInputTestCommand(TestCase testCase, IIPX800 ipx800, LogFile logFile) : base(testCase, ipx800, logFile)
        {
        }

        protected override string ExecuteCommand() => ((IIPX800v4)IPX800).GetVirtualInput(TestCase.Number).ToString();
    }
}