using System;
using System.Threading;
using IPX800cs.Contracts;
using IPX800cs.IO;
using TestConsoleApplication.Configuration;

namespace TestConsoleApplication.TestExecutors
{
    internal class SetVirtualOutputTestCommand : TestCommandBase
    {
        public SetVirtualOutputTestCommand(TestCase testCase, IIPX800 ipx800, LogFile logFile) : base(testCase, ipx800, logFile)
        {
        }

        protected override string ExecuteCommand()
        {
            if (TestCase.State.HasValue)
            {
                OutputState initialState = ((IIPX800v4)IPX800).GetVirtualOutput(TestCase.Number);
                
                string result = ((IIPX800v4)IPX800).SetVirtualOutput(TestCase.Number, TestCase.State.Value).ToString();
                LogFile.Log($"SetVirtualOutput result : {result}");
                Thread.Sleep(200);
                
                var outputState = ((IIPX800v4)IPX800).GetVirtualOutput(TestCase.Number);
                LogFile.Log($"GetVirtualOutput result : {outputState}");
                if (outputState != TestCase.State.Value)
                {
                    LogFile.Log($"WARN : should be {TestCase.State.Value}");
                }
                
                ((IIPX800v4)IPX800).SetVirtualOutput(TestCase.Number, initialState);
                return "";
            }
            else
            {
                throw new InvalidOperationException("State parameter is missing");
            }
        }
    }
}