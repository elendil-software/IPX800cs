using System;
using System.Threading;
using IPX800cs;
using IPX800cs.IO;
using TestConsoleApplication.Configuration;

namespace TestConsoleApplication.TestExecutors;

internal class SetDelayedVirtualOutputTestCommand : TestCommandBase
{
    public SetDelayedVirtualOutputTestCommand(TestCase testCase, IIPX800 ipx800, LogFile logFile) : base(testCase, ipx800, logFile)
    {
    }

    protected override string ExecuteCommand()
    {
        if (TestCase.Delay.HasValue && TestCase.Delay > 0)
        {
            string result = IPX800.SetDelayedVirtualOutput(TestCase.Number).ToString();
            LogFile.Log($"SetDelayedVirtualOutput result : {result}");
            Thread.Sleep(200);
            
            OutputState outputState = IPX800.GetDelayedVirtualOutput(TestCase.Number);
            LogFile.Log($"GetVirtualOutput result : {outputState}");
            if (outputState == OutputState.Inactive)
            {
                LogFile.Log($"WARN : should be {OutputState.Active}");
            }
                
            LogFile.Log($"Wait for impulsion end ({TestCase.Delay} s)");
            Thread.Sleep(TestCase.Delay.Value * 1000 + 1000);
                
            outputState = IPX800.GetVirtualOutput(TestCase.Number);
            LogFile.Log($"GetVirtualOutput result : {outputState}");
            if (outputState == OutputState.Active)
            {
                LogFile.Log($"WARN : should be {OutputState.Inactive}");
            }
        }
        else
        {
            throw new InvalidOperationException("Delay parameter is missing or is 0");
        }

        return "";
    }
}