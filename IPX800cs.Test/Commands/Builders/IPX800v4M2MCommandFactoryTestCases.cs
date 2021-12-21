using System.Collections.Generic;
using IPX800cs.Commands.Builders.v4;
using IPX800cs.IO;

namespace IPX800cs.Test.Commands.Builders;

public class IPX800v4M2MCommandFactoryTestCases
{
    private static readonly IPX800v4M2MCommandFactory CommandFactory = new();
    
    public static IEnumerable<object[]> SupportedGetInputTestCases => new[]
    {
        new object[] { new Input { Number = 2, Type = InputType.DigitalInput}, "Get=D", CommandFactory },
        new object[] { new Input { Number = 2, Type = InputType.AnalogInput}, "Get=A", CommandFactory },
        new object[] { new Input { Number = 2, Type = InputType.VirtualAnalogInput}, "Get=VA", CommandFactory },
        new object[] { new Input { Number = 2, Type = InputType.VirtualDigitalInput}, "Get=VI", CommandFactory },
    };
    
    public static IEnumerable<object[]> UnsupportedGetInputTestCases => new[]
    {
        new object[] { new Input { Number = 2, Type = (InputType)1000}, CommandFactory }
    };
    
    public static IEnumerable<object[]> SupportedGetInputsTestCases => new[]
    {
        new object[] { InputType.AnalogInput, "Get=A", CommandFactory },
        new object[] { InputType.DigitalInput, "Get=D", CommandFactory },
        new object[] { InputType.VirtualAnalogInput, "Get=VA", CommandFactory },
        new object[] { InputType.VirtualDigitalInput, "Get=VI", CommandFactory },
    };
    
    public static IEnumerable<object[]> UnsupportedGetInputsTestCases => new[]
    {
        new object[] { (InputType)1000, CommandFactory }
    };
    
    public static IEnumerable<object[]> SupportedGetOutputTestCases => new[]
    {
        new object[] { new Output { Number = 2, Type = OutputType.Output}, "Get=R", CommandFactory },
        new object[] { new Output { Number = 2, Type = OutputType.VirtualOutput}, "Get=VO", CommandFactory },
    };
    
    public static IEnumerable<object[]> UnsupportedGetOutputTestCases => new[]
    {
        new object[] { new Output { Number = 2, Type = (OutputType)1000}, CommandFactory }
    };
    
    public static IEnumerable<object[]> SupportedGetOutputsTestCases => new[]
    {
        new object[] { OutputType.Output, "Get=R", CommandFactory },
        new object[] { OutputType.VirtualOutput, "Get=VO", CommandFactory }
    }; 
    
    public static IEnumerable<object[]> UnsupportedGetOutputsTestCases => new[]
    {
        new object[] { (OutputType)1000, CommandFactory }
    }; 
    
    public static IEnumerable<object[]> SupportedSetOutputTestCases => new[]
    {
        new object[] { new Output {Type = OutputType.Output, Number = 2, State = OutputState.Active, IsDelayed = false }, "SetR=02", CommandFactory },
        new object[] { new Output {Type = OutputType.Output, Number = 2, State = OutputState.Active, IsDelayed = true }, "SetR=02", CommandFactory },
        new object[] { new Output {Type = OutputType.Output, Number = 2, State = OutputState.Inactive, IsDelayed = false }, "ClearR=02", CommandFactory },
        new object[] { new Output {Type = OutputType.Output, Number = 2, State = OutputState.Inactive, IsDelayed = true }, "ClearR=02", CommandFactory },
        new object[] { new Output {Type = OutputType.VirtualOutput, Number = 2, State = OutputState.Active, IsDelayed = false }, "SetVO=02", CommandFactory },
        new object[] { new Output {Type = OutputType.VirtualOutput, Number = 2, State = OutputState.Active, IsDelayed = true }, "SetVO=02", CommandFactory },
        new object[] { new Output {Type = OutputType.VirtualOutput, Number = 2, State = OutputState.Inactive, IsDelayed = false }, "ClearVO=02", CommandFactory },
        new object[] { new Output {Type = OutputType.VirtualOutput, Number = 2, State = OutputState.Inactive, IsDelayed = true }, "ClearVO=02", CommandFactory }
    };
    
    public static IEnumerable<object[]> UnsupportedSetOutputTestCases => new[]
    {
        new object[] { new Output { Number = 2, Type = (OutputType)1000}, CommandFactory }
    }; 
}