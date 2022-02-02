using System.Collections.Generic;
using IPX800cs.Commands;
using IPX800cs.Commands.Builders.v4;
using IPX800cs.IO;

namespace IPX800cs.Test.Commands.Builders;

public class IPX800v4M2MCommandFactoryTestCases
{
    private static readonly IPX800V4M2MCommandFactory CommandFactory = new();
    
    public static IEnumerable<object[]> SupportedGetInputTestCases => new[]
    {
        new object[] { new Input { Number = 2, Type = InputType.DigitalInput}, Command.CreateM2M("Get=D"), CommandFactory },
        new object[] { new Input { Number = 2, Type = InputType.VirtualDigitalInput}, Command.CreateM2M("Get=VI"), CommandFactory },
    };
    
    public static IEnumerable<object[]> UnsupportedGetInputTestCases => new[]
    {
        new object[] { new Input { Number = 2, Type = InputType.OptoInput}, CommandFactory },
        new object[] { new Input { Number = 2, Type = (InputType)1000}, CommandFactory }
    };
    
    public static IEnumerable<object[]> SupportedGetInputsTestCases => new[]
    {
        new object[] { InputType.DigitalInput, Command.CreateM2M("Get=D"), CommandFactory },
        new object[] { InputType.VirtualDigitalInput, Command.CreateM2M("Get=VI"), CommandFactory },
    };
    
    public static IEnumerable<object[]> UnsupportedGetInputsTestCases => new[]
    {
        new object[] { InputType.OptoInput, CommandFactory },
        new object[] { (InputType)1000, CommandFactory }
    };
    
    public static IEnumerable<object[]> SupportedGetAnalogInputTestCases => new[]
    {
        new object[] { new AnalogInput { Number = 2, Type = AnalogInputType.AnalogInput}, Command.CreateM2M("Get=A"), CommandFactory },
        new object[] { new AnalogInput { Number = 2, Type = AnalogInputType.VirtualAnalogInput}, Command.CreateM2M("Get=VA"), CommandFactory },
    };
    
    public static IEnumerable<object[]> UnsupportedGetAnalogInputTestCases => new[]
    {
        new object[] { new AnalogInput { Number = 2, Type = (AnalogInputType)1000}, CommandFactory }
    };
    
    public static IEnumerable<object[]> SupportedGetAnalogInputsTestCases => new[]
    {
        new object[] { AnalogInputType.AnalogInput, Command.CreateM2M("Get=A"), CommandFactory },
        new object[] { AnalogInputType.VirtualAnalogInput, Command.CreateM2M("Get=VA"), CommandFactory },
    };
    
    public static IEnumerable<object[]> UnsupportedGetAnalogInputsTestCases => new[]
    {
        new object[] { (InputType)1000, CommandFactory }
    };
    
    public static IEnumerable<object[]> SupportedGetOutputTestCases => new[]
    {
        new object[] { new Output { Number = 2, Type = OutputType.Output}, Command.CreateM2M("Get=R"), CommandFactory },
        new object[] { new Output { Number = 2, Type = OutputType.VirtualOutput}, Command.CreateM2M("Get=VO"), CommandFactory },
    };
    
    public static IEnumerable<object[]> UnsupportedGetOutputTestCases => new[]
    {
        new object[] { new Output { Number = 2, Type = OutputType.OpenCollectorOutput}, CommandFactory },
        new object[] { new Output { Number = 2, Type = (OutputType)1000}, CommandFactory }
    };
    
    public static IEnumerable<object[]> SupportedGetOutputsTestCases => new[]
    {
        new object[] { OutputType.Output, Command.CreateM2M("Get=R"), CommandFactory },
        new object[] { OutputType.VirtualOutput, Command.CreateM2M("Get=VO"), CommandFactory }
    }; 
    
    public static IEnumerable<object[]> UnsupportedGetOutputsTestCases => new[]
    {
        new object[] { OutputType.OpenCollectorOutput, CommandFactory },
        new object[] { (OutputType)1000, CommandFactory }
    }; 
    
    public static IEnumerable<object[]> SupportedSetOutputTestCases => new[]
    {
        new object[] { new Output {Type = OutputType.Output, Number = 2, State = OutputState.Active, IsDelayed = false }, Command.CreateM2M("SetR=02"), CommandFactory },
        new object[] { new Output {Type = OutputType.Output, Number = 2, State = OutputState.Active, IsDelayed = true }, Command.CreateM2M("SetR=02"), CommandFactory },
        new object[] { new Output {Type = OutputType.Output, Number = 2, State = OutputState.Inactive, IsDelayed = false }, Command.CreateM2M("ClearR=02"), CommandFactory },
        new object[] { new Output {Type = OutputType.Output, Number = 2, State = OutputState.Inactive, IsDelayed = true }, Command.CreateM2M("ClearR=02"), CommandFactory },
        new object[] { new Output {Type = OutputType.VirtualOutput, Number = 2, State = OutputState.Active, IsDelayed = false }, Command.CreateM2M("SetVO=02"), CommandFactory },
        new object[] { new Output {Type = OutputType.VirtualOutput, Number = 2, State = OutputState.Active, IsDelayed = true }, Command.CreateM2M("SetVO=02"), CommandFactory },
        new object[] { new Output {Type = OutputType.VirtualOutput, Number = 2, State = OutputState.Inactive, IsDelayed = false }, Command.CreateM2M("ClearVO=02"), CommandFactory },
        new object[] { new Output {Type = OutputType.VirtualOutput, Number = 2, State = OutputState.Inactive, IsDelayed = true }, Command.CreateM2M("ClearVO=02"), CommandFactory }
    };
    
    public static IEnumerable<object[]> UnsupportedSetOutputTestCases => new[]
    {
        new object[] { new Output { Number = 2, Type = OutputType.OpenCollectorOutput}, CommandFactory },
        new object[] { new Output { Number = 2, Type = (OutputType)1000}, CommandFactory }
    }; 
}