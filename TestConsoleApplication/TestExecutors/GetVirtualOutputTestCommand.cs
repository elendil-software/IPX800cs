using IPX800cs;
using TestConsoleApplication.Configuration;

namespace TestConsoleApplication.TestExecutors;

internal class GetVirtualOutputTestCommand : TestCommandBase
{
    public GetVirtualOutputTestCommand(TestCase testCase, IIPX800 ipx800, LogFile logFile) : base(testCase, ipx800, logFile)
    {
    }

    protected override string ExecuteCommand() => IPX800.GetVirtualOutput(TestCase.Number).ToString();
}