using System.Linq;
using IPX800cs;
using TestConsoleApplication.Configuration;

namespace TestConsoleApplication.TestExecutors;

internal class GetVirtualOutputsTestCommand : TestCommandBase
{
    public GetVirtualOutputsTestCommand(TestCase testCase, IIPX800 ipx800, LogFile logFile) : base(testCase, ipx800, logFile)
    {
    }

    protected override string ExecuteCommand()
    {
        var result = IPX800.GetVirtualOutputs();
        return string.Join(";", result.Select(x => x.Key + "=" + x.Value).ToArray());
    }
}