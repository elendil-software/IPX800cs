using System.Collections.Generic;
using IPX800cs.Commands;
using IPX800cs.Commands.Builders.v4;
using IPX800cs.IO;

namespace IPX800cs.Test.Commands.Builders;

public class IPX800v4HttpCommandFactoryTestCases
{
    private static readonly IPX800V4HttpCommandFactory CommandFactory = new();
    
    public static IEnumerable<object[]> SupportedGetInputTestCases => new[]
    {
        new object[] { new Input { Number = 2, Type = InputType.DigitalInput}, Command.CreateGet("/api/xdevices.json?Get=D"), CommandFactory },
        new object[] { new Input { Number = 2, Type = InputType.VirtualDigitalInput}, Command.CreateGet("/api/xdevices.json?Get=VI"), CommandFactory },
    };
    
    public static IEnumerable<object[]> UnsupportedGetInputTestCases => new[]
    {
        new object[] { new Input { Number = 2, Type = InputType.OptoInput}, CommandFactory },
        new object[] { new Input { Number = 2, Type = (InputType)1000}, CommandFactory }
    };
    
    public static IEnumerable<object[]> SupportedGetInputsTestCases => new[]
    {
        new object[] { InputType.DigitalInput, Command.CreateGet("/api/xdevices.json?Get=D"), CommandFactory },
        new object[] { InputType.VirtualDigitalInput, Command.CreateGet("/api/xdevices.json?Get=VI"), CommandFactory },
    };
    
    public static IEnumerable<object[]> UnsupportedGetInputsTestCases => new[]
    {
        new object[] { InputType.OptoInput, CommandFactory },
        new object[] { (InputType)1000, CommandFactory }
    };
    
    public static IEnumerable<object[]> SupportedGetAnalogInputTestCases => new[]
    {
        new object[] { new AnalogInput { Number = 2, Type = AnalogInputType.AnalogInput}, Command.CreateGet("/api/xdevices.json?Get=A"), CommandFactory },
        new object[] { new AnalogInput { Number = 2, Type = AnalogInputType.VirtualAnalogInput}, Command.CreateGet("/api/xdevices.json?Get=VA"), CommandFactory },
    };
    
    public static IEnumerable<object[]> UnsupportedGetAnalogInputTestCases => new[]
    {
        new object[] { new AnalogInput { Number = 2, Type = (AnalogInputType)1000}, CommandFactory }
    };
    
    public static IEnumerable<object[]> SupportedGetAnalogInputsTestCases => new[]
    {
        new object[] { AnalogInputType.AnalogInput, Command.CreateGet("/api/xdevices.json?Get=A"), CommandFactory },
        new object[] { AnalogInputType.VirtualAnalogInput, Command.CreateGet("/api/xdevices.json?Get=VA"), CommandFactory },
    };
    
    public static IEnumerable<object[]> UnsupportedGetAnalogInputsTestCases => new[]
    {
        new object[] { (InputType)1000, CommandFactory }
    };
    
    public static IEnumerable<object[]> SupportedGetOutputTestCases => new[]
    {
        new object[] { new Output { Number = 2, Type = OutputType.Output}, Command.CreateGet("/api/xdevices.json?Get=R"), CommandFactory },
        new object[] { new Output { Number = 2, Type = OutputType.DelayedOutput}, Command.CreateGet("/api/xdevices.json?Get=R"), CommandFactory },
        new object[] { new Output { Number = 2, Type = OutputType.VirtualOutput}, Command.CreateGet("/api/xdevices.json?Get=VO"), CommandFactory },
        new object[] { new Output { Number = 2, Type = OutputType.DelayedVirtualOutput}, Command.CreateGet("/api/xdevices.json?Get=VO"), CommandFactory }
    };
    
    public static IEnumerable<object[]> UnsupportedGetOutputTestCases => new[]
    {
        new object[] { new Output { Number = 2, Type = OutputType.OpenCollectorOutput}, CommandFactory },
        new object[] { new Output { Number = 2, Type = (OutputType)1000}, CommandFactory }
    };
    
    public static IEnumerable<object[]> SupportedGetOutputsTestCases => new[]
    {
        new object[] { OutputType.Output, Command.CreateGet("/api/xdevices.json?Get=R"), CommandFactory },
        new object[] { OutputType.DelayedOutput, Command.CreateGet("/api/xdevices.json?Get=R"), CommandFactory },
        new object[] { OutputType.VirtualOutput, Command.CreateGet("/api/xdevices.json?Get=VO"), CommandFactory },
        new object[] { OutputType.DelayedVirtualOutput, Command.CreateGet("/api/xdevices.json?Get=VO"), CommandFactory }
    }; 
    
    public static IEnumerable<object[]> UnsupportedGetOutputsTestCases => new[]
    {
        new object[] { OutputType.OpenCollectorOutput, CommandFactory },
        new object[] { (OutputType)1000, CommandFactory }
    }; 
    
    public static IEnumerable<object[]> SupportedSetOutputTestCases => new[]
    {
        new object[] { new Output {Type = OutputType.Output, Number = 2, State = OutputState.Active }, Command.CreateGet("/api/xdevices.json?SetR=02"), CommandFactory },
        new object[] { new Output {Type = OutputType.DelayedOutput, Number = 2, State = OutputState.Active }, Command.CreateGet("/api/xdevices.json?SetR=02"), CommandFactory },
        new object[] { new Output {Type = OutputType.Output, Number = 2, State = OutputState.Inactive }, Command.CreateGet("/api/xdevices.json?ClearR=02"), CommandFactory },
        new object[] { new Output {Type = OutputType.DelayedOutput, Number = 2, State = OutputState.Inactive }, Command.CreateGet("/api/xdevices.json?ClearR=02"), CommandFactory },
        new object[] { new Output {Type = OutputType.VirtualOutput, Number = 2, State = OutputState.Active }, Command.CreateGet("/api/xdevices.json?SetVO=02"), CommandFactory },
        new object[] { new Output {Type = OutputType.DelayedVirtualOutput, Number = 2, State = OutputState.Active }, Command.CreateGet("/api/xdevices.json?SetVO=02"), CommandFactory },
        new object[] { new Output {Type = OutputType.VirtualOutput, Number = 2, State = OutputState.Inactive }, Command.CreateGet("/api/xdevices.json?ClearVO=02"), CommandFactory },
        new object[] { new Output {Type = OutputType.DelayedVirtualOutput, Number = 2, State = OutputState.Inactive }, Command.CreateGet("/api/xdevices.json?ClearVO=02"), CommandFactory }
    };
    
    public static IEnumerable<object[]> UnsupportedSetOutputTestCases => new[]
    {
        new object[] { new Output { Number = 2, Type = OutputType.OpenCollectorOutput}, CommandFactory },
        new object[] { new Output { Number = 2, Type = (OutputType)1000}, CommandFactory }
    }; 
}