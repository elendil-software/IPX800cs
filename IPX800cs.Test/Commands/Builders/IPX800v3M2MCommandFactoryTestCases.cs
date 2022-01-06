using System.Collections.Generic;
using IPX800cs.Commands.Builders.v3;
using IPX800cs.IO;

namespace IPX800cs.Test.Commands.Builders;



public class IPX800v3M2MCommandFactoryTestCases
{
    private static readonly IPX800v3M2MCommandFactory CommandFactory = new();
    
    public static IEnumerable<object[]> SupportedGetInputTestCases => new[]
    {
        new object[] { new Input { Number = 2, Type = InputType.DigitalInput}, "GetIn2", CommandFactory },
    };
    
    public static IEnumerable<object[]> UnsupportedGetInputTestCases => new[]
    {
        new object[] { new Input { Number = 2, Type = InputType.VirtualDigitalInput}, CommandFactory }
    };
    
    public static IEnumerable<object[]> SupportedGetInputsTestCases => new[]
    {
        new object[] { InputType.DigitalInput, "GetInputs", CommandFactory }
    };
    
    public static IEnumerable<object[]> UnsupportedGetInputsTestCases => new[]
    {
        new object[] { InputType.VirtualDigitalInput, CommandFactory },
        new object[] { (InputType)1000, CommandFactory }
    };
    
    public static IEnumerable<object[]> SupportedGetAnalogInputTestCases => new[]
    {
        new object[] { new AnalogInput { Number = 2, Type = AnalogInputType.AnalogInput}, "GetAn2", CommandFactory }
    };
    
    public static IEnumerable<object[]> UnsupportedGetAnalogInputTestCases => new[]
    {
        new object[] { new AnalogInput { Number = 2, Type = AnalogInputType.VirtualAnalogInput}, CommandFactory },
    };

    public static IEnumerable<object[]> UnsupportedGetAnalogInputsTestCases => new[]
    {
        new object[] { AnalogInputType.AnalogInput, CommandFactory },
        new object[] { AnalogInputType.VirtualAnalogInput, CommandFactory },
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
    
    public static IEnumerable<object[]> SupportedGetOutputsTestCases => new[]
    {
        new object[] { OutputType.Output, "GetOutputs", CommandFactory }
    }; 
    
    public static IEnumerable<object[]> UnsupportedGetOutputsTestCases => new[]
    {
        new object[] { OutputType.VirtualOutput, CommandFactory },
        new object[] { (OutputType)1000, CommandFactory }
    }; 
    
    public static IEnumerable<object[]> SupportedSetOutputTestCases => new[]
    {
        new object[] { new Output {Type = OutputType.Output, Number = 2, State = OutputState.Active, IsDelayed = false }, "Set021", CommandFactory },
        new object[] { new Output {Type = OutputType.Output, Number = 2, State = OutputState.Active, IsDelayed = true }, "Set021p", CommandFactory },
        new object[] { new Output {Type = OutputType.Output, Number = 2, State = OutputState.Inactive, IsDelayed = false }, "Set020", CommandFactory },
        new object[] { new Output {Type = OutputType.Output, Number = 2, State = OutputState.Inactive, IsDelayed = true }, "Set020", CommandFactory }
    };
    
    public static IEnumerable<object[]> UnsupportedSetOutputTestCases => new[]
    {
        new object[] { new Output { Number = 2, Type = OutputType.VirtualOutput}, CommandFactory }
    }; 
}