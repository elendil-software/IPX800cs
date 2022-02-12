using System;
using IPX800cs;
using TestConsoleApplication.Configuration;

namespace TestConsoleApplication.TestExecutors;

internal class TestExecutorFactory
{
    private readonly IIPX800 _ipx800;
    private readonly LogFile _logFile;

    public TestExecutorFactory(IIPX800 ipx800, LogFile logFile)
    {
        _ipx800 = ipx800 ?? throw new ArgumentNullException(nameof(ipx800));
        _logFile = logFile ?? throw new ArgumentNullException(nameof(logFile));
    }

    public ITestCommand Create(TestCase testCase)
    {
        if (!Enum.TryParse(testCase.Command, out Command command))
        {
            throw new ArgumentOutOfRangeException(nameof(testCase.Command), $"{testCase.Command} is not a supported test command");
        }

        switch (command)
        {
            case Command.GetInputs:
                return new GetInputsTestCommand(testCase, _ipx800, _logFile);

            case Command.GetInput:
                return new GetInputTestCommand(testCase, _ipx800, _logFile);
            
            case Command.GetOptoInputs:
                return new GetOptoInputsTestCommand(testCase, _ipx800, _logFile);

            case Command.GetOptoInput:
                return new GetOptoInputTestCommand(testCase, _ipx800, _logFile);
            
            
            case Command.GetAnalogInputs:
                return new GetAnalogInputsTestCommand(testCase, _ipx800, _logFile);
            
            case Command.GetAnalogInput:
                return new GetAnalogInputTestCommand(testCase, _ipx800, _logFile);

            
            case Command.GetOutputs:
                return new GetOutputsTestCommand(testCase, _ipx800, _logFile);
            case Command.SetOutput:
                return new SetOutputTestCommand(testCase, _ipx800, _logFile);
            case Command.GetOutput:
                return new GetOutputTestCommand(testCase, _ipx800, _logFile);
            case Command.GetDelayedOutputs:
                return new GetDelayedOutputsTestCommand(testCase, _ipx800, _logFile);
            case Command.SetDelayedOutput:
                return new SetDelayedOutputTestCommand(testCase, _ipx800, _logFile);
            case Command.GetDelayedOutput:
                return new GetDelayedOutputTestCommand(testCase, _ipx800, _logFile);

            case Command.GetOpenCollectorOutputs:
                return new GetOpenCollectorOutputsTestCommand(testCase, _ipx800, _logFile);
            case Command.GetOpenCollectorOutput:
                return new GetOpenCollectorOutputTestCommand(testCase, _ipx800, _logFile);
            case Command.SetOpenCollectorOutput:
                return new SetOpenCollectorOutputTestCommand(testCase, _ipx800, _logFile);
            case Command.GetDelayedOpenCollectorOutputs:
                return new GetDelayedOpenCollectorOutputsTestCommand(testCase, _ipx800, _logFile);
            case Command.GetDelayedOpenCollectorOutput:
                return new GetDelayedOpenCollectorOutputTestCommand(testCase, _ipx800, _logFile);
            case Command.SetDelayedOpenCollectorOutput:
                return new SetDelayedOpenCollectorOutputTestCommand(testCase, _ipx800, _logFile);
            
            case Command.GetVirtualOutput:
                return new GetVirtualOutputTestCommand(testCase, _ipx800, _logFile);
            case Command.SetVirtualOutput:
                return new SetVirtualOutputTestCommand(testCase, _ipx800, _logFile);
            case Command.SetDelayedVirtualOutput:
                return new SetDelayedVirtualOutputTestCommand(testCase, _ipx800, _logFile);
            case Command.GetDelayedVirtualOutput:
                return new GetDelayedVirtualOutputTestCommand(testCase, _ipx800, _logFile);
            case Command.GetVirtualOutputs:
                return new GetVirtualOutputsTestCommand(testCase, _ipx800, _logFile);
            case Command.GetDelayedVirtualOutputs:
                return new GetDelayedVirtualOutputsTestCommand(testCase, _ipx800, _logFile);

            case Command.GetVirtualInput:
                return new GetVirtualInputTestCommand(testCase, _ipx800, _logFile);
            case Command.GetVirtualAnalogInput:
                return new GetVirtualAnalogInputTestCommand(testCase, _ipx800, _logFile);
            case Command.GetVirtualInputs:
                return new GetVirtualInputsTestCommand(testCase, _ipx800, _logFile);
            case Command.GetVirtualAnalogInputs:
                return new GetVirtualAnalogInputsTestCommand(testCase, _ipx800, _logFile);

                
            default:
                throw new ArgumentOutOfRangeException(nameof(testCase.Command), $"{testCase.Command} is not a supported test command");
        }
    }
}