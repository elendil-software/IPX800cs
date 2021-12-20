using System;
using IPX800cs;
using TestConsoleApplication.Configuration;

namespace TestConsoleApplication.TestExecutors;

internal abstract class TestCommandBase : ITestCommand
{
    protected readonly TestCase TestCase;
    protected readonly IIPX800 IPX800;
    protected readonly LogFile LogFile;

    protected TestCommandBase(TestCase testCase, IIPX800 ipx800, LogFile logFile)
    {
        TestCase = testCase ?? throw new ArgumentNullException(nameof(testCase));
        IPX800 = ipx800 ?? throw new ArgumentNullException(nameof(ipx800));
        LogFile = logFile ?? throw new ArgumentNullException(nameof(ipx800));
    }
        
    protected abstract string ExecuteCommand();
        
    public void Execute()
    {
        try
        {
            LogConfiguration();
            var result = ExecuteCommand();

            if (!string.IsNullOrWhiteSpace(result))
            {
                LogFile.Log($"Result : {result}\n");
            }
            else
            {
                LogFile.Log("");
            }
        }
        catch (Exception ex)
        {
            LogFile.Log(ex);
        }
    }
        
    private void LogConfiguration()
    {
        LogFile.Log($"Command : {TestCase.Command}");
        LogFile.Log($"Number : {TestCase.Number}");

        if (TestCase.State.HasValue)
        {
            LogFile.Log($"Number : {TestCase.State.Value}");
        }
            
        if (TestCase.Delay.HasValue)
        {
            LogFile.Log($"Delay : {TestCase.Delay.Value}");
        }
    }
}