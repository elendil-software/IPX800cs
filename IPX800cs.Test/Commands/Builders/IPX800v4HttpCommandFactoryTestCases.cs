using System.Collections.Generic;
using IPX800cs.Commands.Builders.v4;
using IPX800cs.IO;

namespace IPX800cs.Test.Commands.Builders;

public class IPX800v4HttpCommandFactoryTestCases
{
    private static readonly IPX800v4HttpCommandFactory CommandFactory = new();
    
    public static IEnumerable<object[]> SupportedGetInputTestCases => new[]
    {
        new object[] { new Input { Number = 2, Type = InputType.DigitalInput}, "/api/xdevices.json?Get=D", CommandFactory },
        new object[] { new Input { Number = 2, Type = InputType.AnalogInput}, "/api/xdevices.json?Get=A", CommandFactory },
        new object[] { new Input { Number = 2, Type = InputType.VirtualAnalogInput}, "/api/xdevices.json?Get=VA", CommandFactory },
        new object[] { new Input { Number = 2, Type = InputType.VirtualDigitalInput}, "/api/xdevices.json?Get=VI", CommandFactory },
    };
    
    public static IEnumerable<object[]> UnsupportedGetInputTestCases => new[]
    {
        new object[] { new Input { Number = 2, Type = (InputType)1000}, CommandFactory }
    };
    
    public static IEnumerable<object[]> SupportedGetInputsTestCases => new[]
    {
        new object[] { InputType.AnalogInput, "/api/xdevices.json?Get=A", CommandFactory },
        new object[] { InputType.DigitalInput, "/api/xdevices.json?Get=D", CommandFactory },
        new object[] { InputType.VirtualAnalogInput, "/api/xdevices.json?Get=VA", CommandFactory },
        new object[] { InputType.VirtualDigitalInput, "/api/xdevices.json?Get=VI", CommandFactory },
    };
    
    public static IEnumerable<object[]> UnsupportedGetInputsTestCases => new[]
    {
        new object[] { (InputType)1000, CommandFactory }
    };
    
    public static IEnumerable<object[]> SupportedGetOutputTestCases => new[]
    {
        new object[] { new Output { Number = 2, Type = OutputType.Output}, "/api/xdevices.json?Get=R", CommandFactory },
        new object[] { new Output { Number = 2, Type = OutputType.VirtualOutput}, "/api/xdevices.json?Get=VO", CommandFactory },
    };
    
    public static IEnumerable<object[]> UnsupportedGetOutputTestCases => new[]
    {
        new object[] { new Output { Number = 2, Type = (OutputType)1000}, CommandFactory }
    };
    
    public static IEnumerable<object[]> SupportedGetOutputsTestCases => new[]
    {
        new object[] { OutputType.Output, "/api/xdevices.json?Get=R", CommandFactory },
        new object[] { OutputType.VirtualOutput, "/api/xdevices.json?Get=VO", CommandFactory }
    }; 
    
    public static IEnumerable<object[]> UnsupportedGetOutputsTestCases => new[]
    {
        new object[] { (OutputType)1000, CommandFactory }
    }; 
    
    public static IEnumerable<object[]> SupportedSetOutputTestCases => new[]
    {
        new object[] { new Output {Type = OutputType.Output, Number = 2, State = OutputState.Active, IsDelayed = false }, "/api/xdevices.json?SetR=02", CommandFactory },
        new object[] { new Output {Type = OutputType.Output, Number = 2, State = OutputState.Active, IsDelayed = true }, "/api/xdevices.json?SetR=02", CommandFactory },
        new object[] { new Output {Type = OutputType.Output, Number = 2, State = OutputState.Inactive, IsDelayed = false }, "/api/xdevices.json?ClearR=02", CommandFactory },
        new object[] { new Output {Type = OutputType.Output, Number = 2, State = OutputState.Inactive, IsDelayed = true }, "/api/xdevices.json?ClearR=02", CommandFactory },
        new object[] { new Output {Type = OutputType.VirtualOutput, Number = 2, State = OutputState.Active, IsDelayed = false }, "/api/xdevices.json?SetVO=02", CommandFactory },
        new object[] { new Output {Type = OutputType.VirtualOutput, Number = 2, State = OutputState.Active, IsDelayed = true }, "/api/xdevices.json?SetVO=02", CommandFactory },
        new object[] { new Output {Type = OutputType.VirtualOutput, Number = 2, State = OutputState.Inactive, IsDelayed = false }, "/api/xdevices.json?ClearVO=02", CommandFactory },
        new object[] { new Output {Type = OutputType.VirtualOutput, Number = 2, State = OutputState.Inactive, IsDelayed = true }, "/api/xdevices.json?ClearVO=02", CommandFactory }
    };
    
    public static IEnumerable<object[]> UnsupportedSetOutputTestCases => new[]
    {
        new object[] { new Output { Number = 2, Type = (OutputType)1000}, CommandFactory }
    }; 
}