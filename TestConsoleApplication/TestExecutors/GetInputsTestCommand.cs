using System.Collections.Generic;
using System.Linq;
using IPX800cs.Contracts;
using IPX800cs.IO;
using TestConsoleApplication.Configuration;

namespace TestConsoleApplication.TestExecutors
{
    internal class GetInputsTestCommand : TestCommandBase
    {
        public GetInputsTestCommand(TestCase testCase, IIPX800 ipx800, LogFile logFile) : base(testCase, ipx800, logFile)
        {
        }

        protected override string ExecuteCommand()
        {
            Dictionary<int, InputState> result = ((IGetAllIO) IPX800).GetInputs();
            return string.Join(";", result.Select(x => x.Key + "=" + x.Value).ToArray());
        }
    }
}