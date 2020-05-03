namespace TestConsoleApplication.Configuration
{
    internal enum Command
    {
        //v2, v3, v4
        GetOutput,
        GetInput,
        GetAnalogInput,
        SetOutput,
        SetDelayedOutput,
        
        //v3, v4
        GetInputs,
        GetOutputs,
        
        //v4
        GetVirtualOutput,
        GetVirtualInput,
        GetVirtualAnalogInput,
        SetVirtualOutput,
        SetDelayedVirtualOutput,
        GetAnalogInputs,
        GetVirtualOutputs,
        GetVirtualInputs,
        GetVirtualAnalogInputs
    }
}