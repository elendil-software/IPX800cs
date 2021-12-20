using System;
using System.Threading;
using IPX800cs;
using IPX800cs.IO;
using TestConsoleApplication.Configuration;

namespace TestConsoleApplication.TestExecutors;

internal class SetOutputTestCommand : TestCommandBase
{
    public SetOutputTestCommand(TestCase testCase, IIPX800 ipx800, LogFile logFile) : base(testCase, ipx800, logFile)
    {
    }

    protected override string ExecuteCommand()
    {
        if (TestCase.State.HasValue)
        {
            OutputState initialState = IPX800.GetOutput(TestCase.Number);
                
            string result = IPX800.SetOutput(TestCase.Number, TestCase.State.Value).ToString();
            LogFile.Log($"SetOutput result : {result}");
            Thread.Sleep(200);
            
            var outputState = IPX800.GetOutput(TestCase.Number);
            LogFile.Log($"GetOutput result : {outputState}");
            if (outputState != TestCase.State.Value)
            {
                LogFile.Log($"WARN : should be {TestCase.State.Value}");
            }

            IPX800.SetOutput(TestCase.Number, initialState);
            return "";
        }
        else
        {
            throw new InvalidOperationException("State parameter is missing");
        }
    }
}