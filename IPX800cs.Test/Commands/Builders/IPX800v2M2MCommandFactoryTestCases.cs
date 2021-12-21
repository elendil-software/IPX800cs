using System.Collections.Generic;
using IPX800cs.Commands.Builders.v2;
using IPX800cs.IO;

namespace IPX800cs.Test.Commands.Builders;

public class IPX800v2M2MCommandFactoryTestCases
{
    private static readonly IPX800v2M2MCommandFactory CommandFactory = new();
    
    public static IEnumerable<object[]> SupportedGetInputTestCases => new[]
    {
        new object[] { new Input { Number = 2, Type = InputType.DigitalInput}, "GetIn2", CommandFactory },
        new object[] { new Input { Number = 2, Type = InputType.AnalogInput}, "GetAn2", CommandFactory },
    };
    
    public static IEnumerable<object[]> UnsupportedGetInputTestCases => new[]
    {
        new object[] { new Input { Number = 2, Type = InputType.VirtualAnalogInput}, CommandFactory },
        new object[] { new Input { Number = 2, Type = InputType.VirtualDigitalInput}, CommandFactory }
    };
    
    //TODO to be implemented
    // public static IEnumerable<object[]> SupportedGetInputsTestCases => new[]
    // {
    //     new object[] { InputType.DigitalInput, "api/xdevices.json?cmd=10", CommandFactory }
    // };
    
    public static IEnumerable<object[]> UnsupportedGetInputsTestCases => new[]
    {
        new object[] { InputType.DigitalInput, CommandFactory },
        new object[] { InputType.AnalogInput, CommandFactory },
        new object[] { InputType.VirtualAnalogInput, CommandFactory },
        new object[] { InputType.VirtualDigitalInput, CommandFactory },
        new object[] { (InputType)1000, CommandFactory }
    };
    
    public static IEnumerable<object[]> SupportedGetOutputTestCases => new[]
    {
        new object[] { new Output { Number = 2, Type = OutputType.Output}, "GetOut2", CommandFactory }
    };
    
    public static IEnumerable<object[]> UnsupportedGetOutputTestCases => new[]
    {
        new object[] { new Output { Number = 2, Type = OutputType.VirtualOutput}, CommandFactory },
        new object[] { new Output { Number = 2, Type = (OutputType)1000}, CommandFactory }
    };
    
    //TODO to be implemented
    // public static IEnumerable<object[]> SupportedGetOutputsTestCases => new[]
    // {
    //     new object[] { OutputType.Output, "api/xdevices.json?cmd=20", CommandFactory }
    // }; 
    
    public static IEnumerable<object[]> UnsupportedGetOutputsTestCases => new[]
    {
        new object[] { OutputType.Output, CommandFactory },
        new object[] { OutputType.VirtualOutput, CommandFactory },
        new object[] { (OutputType)1000, CommandFactory }
    }; 
    
    public static IEnumerable<object[]> SupportedSetOutputTestCases => new[]
    {
        new object[] { new Output {Type = OutputType.Output, Number = 2, State = OutputState.Active, IsDelayed = false }, "Set21", CommandFactory },
        new object[] { new Output {Type = OutputType.Output, Number = 2, State = OutputState.Active, IsDelayed = true }, "Set2F", CommandFactory },
        new object[] { new Output {Type = OutputType.Output, Number = 2, State = OutputState.Inactive, IsDelayed = false }, "Set20", CommandFactory },
        new object[] { new Output {Type = OutputType.Output, Number = 2, State = OutputState.Inactive, IsDelayed = true }, "Set20", CommandFactory }
    };
    
    public static IEnumerable<object[]> UnsupportedSetOutputTestCases => new[]
    {
        new object[] { new Output { Number = 2, Type = OutputType.VirtualOutput}, CommandFactory }
    }; 
}