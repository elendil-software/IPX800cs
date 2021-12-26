using System.Collections.Generic;
using System.Linq;
using IPX800cs;
using IPX800cs.IO;
using TestConsoleApplication.Configuration;

namespace TestConsoleApplication.TestExecutors;

internal class GetAnalogInputsTestCommand : TestCommandBase
{
    public GetAnalogInputsTestCommand(TestCase testCase, IIPX800 ipx800, LogFile logFile) : base(testCase, ipx800, logFile)
    {
    }

    protected override string ExecuteCommand()
    {
        IEnumerable<AnalogInputResponse> result = IPX800.GetAnalogInputs();
        return string.Join(";", result.Select(x => $"{x.Name} ({x.Number})={x.Value}").ToArray());
    }
}