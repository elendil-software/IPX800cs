using System.Collections.Generic;
using System.Linq;
using IPX800cs;
using TestConsoleApplication.Configuration;

namespace TestConsoleApplication.TestExecutors;

internal class GetVirtualAnalogInputsTestCommand : TestCommandBase
{
    public GetVirtualAnalogInputsTestCommand(TestCase testCase, IIPX800 ipx800, LogFile logFile) : base(testCase, ipx800, logFile)
    {
    }

    protected override string ExecuteCommand()
    {
        Dictionary<int, int> result = IPX800.GetVirtualAnalogInputs();
        return string.Join(";", result.Select(x => x.Key + "=" + x.Value).ToArray());
    }
}