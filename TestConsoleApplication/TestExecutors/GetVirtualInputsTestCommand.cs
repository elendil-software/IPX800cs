using System.Collections.Generic;
using System.Linq;
using IPX800cs;
using IPX800cs.IO;
using TestConsoleApplication.Configuration;

namespace TestConsoleApplication.TestExecutors;

internal class GetVirtualInputsTestCommand : TestCommandBase
{
    public GetVirtualInputsTestCommand(TestCase testCase, IIPX800 ipx800, LogFile logFile) : base(testCase, ipx800, logFile)
    {
    }

    protected override string ExecuteCommand()
    {
        IEnumerable<InputResponse> result = IPX800.GetVirtualInputs();
        return string.Join(";", result.Select(x => $"{x.Name} ({x.Number})={x.State}").ToArray());
    }
}