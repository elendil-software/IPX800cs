using System.Collections.Generic;
using IPX800cs.Commands;
using IPX800cs.Commands.Builders.v2;
using IPX800cs.IO;

namespace IPX800cs.Test.Commands.Builders;

public class IPX800V2M2MCommandFactoryTestCases
{
    private static readonly IPX800V2M2MCommandFactory CommandFactory = new();
    
    public static IEnumerable<object[]> SupportedGetInputTestCases => new[]
    {
        new object[] { new Input { Number = 2, Type = InputType.DigitalInput}, Command.CreateM2M("GetIn2"), CommandFactory },
    };
    
    public static IEnumerable<object[]> UnsupportedGetInputTestCases => new[]
    {
        new object[] { new Input { Number = 2, Type = InputType.VirtualDigitalInput}, CommandFactory }
    };
    
    public static IEnumerable<object[]> UnsupportedGetInputsTestCases => new[]
    {
        new object[] { InputType.DigitalInput, CommandFactory },
        new object[] { InputType.VirtualDigitalInput, CommandFactory },
        new object[] { InputType.OptoInput, CommandFactory },
        new object[] { (InputType)1000, CommandFactory }
    };
    
    public static IEnumerable<object[]> SupportedGetAnalogInputTestCases => new[]
    {
        new object[] { new AnalogInput { Number = 2, Type = AnalogInputType.AnalogInput}, Command.CreateM2M("GetAn2"), CommandFactory },
    };
    
    public static IEnumerable<object[]> UnsupportedGetAnalogInputTestCases => new[]
    {
        new object[] { new AnalogInput { Number = 2, Type = AnalogInputType.VirtualAnalogInput}, CommandFactory }
    };
    
    public static IEnumerable<object[]> UnsupportedGetAnalogInputsTestCases => new[]
    {
        new object[] { AnalogInputType.AnalogInput, CommandFactory },
        new object[] { AnalogInputType.VirtualAnalogInput, CommandFactory },
        new object[] { (InputType)1000, CommandFactory }
    };
    
    public static IEnumerable<object[]> SupportedGetOutputTestCases => new[]
    {
        new object[] { new Output { Number = 2, Type = OutputType.Output}, Command.CreateM2M("GetOut2"), CommandFactory },
        new object[] { new Output { Number = 2, Type = OutputType.DelayedOutput}, Command.CreateM2M("GetOut2"), CommandFactory }
    };
    
    public static IEnumerable<object[]> UnsupportedGetOutputTestCases => new[]
    {
        new object[] { new Output { Number = 2, Type = OutputType.VirtualOutput}, CommandFactory },
        new object[] { new Output { Number = 2, Type = OutputType.DelayedVirtualOutput}, CommandFactory },
        new object[] { new Output { Number = 2, Type = OutputType.OpenCollectorOutput}, CommandFactory },
        new object[] { new Output { Number = 2, Type = OutputType.DelayedOpenCollectorOutput}, CommandFactory },
        new object[] { new Output { Number = 2, Type = (OutputType)1000}, CommandFactory },
    };
    
    public static IEnumerable<object[]> UnsupportedGetOutputsTestCases => new[]
    {
        new object[] { OutputType.Output, CommandFactory },
        new object[] { OutputType.VirtualOutput, CommandFactory },
        new object[] { OutputType.OpenCollectorOutput, CommandFactory },
        new object[] { OutputType.DelayedOpenCollectorOutput, CommandFactory },
        new object[] { (OutputType)1000, CommandFactory }
    }; 
    
    public static IEnumerable<object[]> SupportedSetOutputTestCases => new[]
    {
        new object[] { new Output {Type = OutputType.Output, Number = 2, State = OutputState.Active }, Command.CreateM2M("Set21"), CommandFactory },
        new object[] { new Output {Type = OutputType.DelayedOutput, Number = 2, State = OutputState.Active }, Command.CreateM2M("Set2F"), CommandFactory },
        new object[] { new Output {Type = OutputType.Output, Number = 2, State = OutputState.Inactive }, Command.CreateM2M("Set20"), CommandFactory },
        new object[] { new Output {Type = OutputType.DelayedOutput, Number = 2, State = OutputState.Inactive }, Command.CreateM2M("Set20"), CommandFactory }
    };
    
    public static IEnumerable<object[]> UnsupportedSetOutputTestCases => new[]
    {
        new object[] { new Output { Number = 2, Type = OutputType.VirtualOutput}, CommandFactory },
        new object[] { new Output { Number = 2, Type = OutputType.OpenCollectorOutput}, CommandFactory },
        new object[] { new Output { Number = 2, Type = OutputType.DelayedOpenCollectorOutput}, CommandFactory }
    }; 
}