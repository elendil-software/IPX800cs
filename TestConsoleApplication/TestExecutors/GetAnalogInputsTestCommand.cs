using System.Collections.Generic;
using System.Linq;
using IPX800cs.Contracts;
using TestConsoleApplication.Configuration;

namespace TestConsoleApplication.TestExecutors
{
    internal class GetAnalogInputsTestCommand : TestCommandBase
    {
        public GetAnalogInputsTestCommand(TestCase testCase, IIPX800 ipx800, LogFile logFile) : base(testCase, ipx800, logFile)
        {
        }

        protected override string ExecuteCommand()
        {
            Dictionary<int, int> result = ((IIPX800v4) IPX800).GetAnalogInputs();
            return string.Join(";", result.Select(x => x.Key + "=" + x.Value).ToArray());
        }
    }
}