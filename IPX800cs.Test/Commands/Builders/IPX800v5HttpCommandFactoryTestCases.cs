using System.Collections.Generic;
using IPX800cs.Commands;
using IPX800cs.Commands.Builders.v5;
using IPX800cs.IO;

namespace IPX800cs.Test.Commands.Builders;

public class IPX800V5HttpCommandFactoryTestCases
{
    private static readonly IPX800V5HttpCommandFactory CommandFactory = new();
    private const string GetIO = "/api/core/io";
    private const string GetAna = "/api/core/ana";
    
    public static IEnumerable<object[]> SupportedGetInputTestCases => new[]
    {
        new object[] { new Input { Number = 2, Type = InputType.DigitalInput}, Command.CreateGet($"{GetIO}/2"), CommandFactory },
        new object[] { new Input { Number = 2, Type = InputType.OptoInput}, Command.CreateGet($"{GetIO}/2"), CommandFactory }
    };
    
    public static IEnumerable<object[]> UnsupportedGetInputTestCases => new[]
    {
        new object[] { new Input { Number = 2, Type = InputType.VirtualDigitalInput}, CommandFactory },
        new object[] { new Input { Number = 2, Type = (InputType)1000}, CommandFactory }
    };
    
    public static IEnumerable<object[]> SupportedGetInputsTestCases => new[]
    {
        new object[] { InputType.DigitalInput, Command.CreateGet(GetIO), CommandFactory },
        new object[] { InputType.OptoInput, Command.CreateGet(GetIO), CommandFactory }
    };
    
    public static IEnumerable<object[]> UnsupportedGetInputsTestCases => new[]
    {
        new object[] { InputType.VirtualDigitalInput, CommandFactory },
        new object[] { (InputType)1000, CommandFactory }
    };
    
    public static IEnumerable<object[]> SupportedGetAnalogInputTestCases => new[]
    {
        new object[] { new AnalogInput { Number = 2, Type = AnalogInputType.AnalogInput}, Command.CreateGet($"{GetAna}/2"), CommandFactory }
    };
    
    public static IEnumerable<object[]> UnsupportedGetAnalogInputTestCases => new[]
    {
        new object[] { new AnalogInput { Number = 2, Type = AnalogInputType.VirtualAnalogInput}, CommandFactory },
        new object[] { new AnalogInput { Number = 2, Type = (AnalogInputType)1000}, CommandFactory }
    };
    
    public static IEnumerable<object[]> SupportedGetAnalogInputsTestCases => new[]
    {
        new object[] { AnalogInputType.AnalogInput, Command.CreateGet(GetAna), CommandFactory }
    };
    
    public static IEnumerable<object[]> UnsupportedGetAnalogInputsTestCases => new[]
    {
        new object[] { AnalogInputType.VirtualAnalogInput, CommandFactory },
        new object[] { (InputType)1000, CommandFactory }
    };
    
    public static IEnumerable<object[]> SupportedGetOutputTestCases => new[]
    {
        new object[] { new Output { Number = 2, Type = OutputType.Output}, Command.CreateGet($"{GetIO}/2"), CommandFactory },
        new object[] { new Output { Number = 2, Type = OutputType.OpenCollectorOutput}, Command.CreateGet($"{GetIO}/2"), CommandFactory }
    };
    
    public static IEnumerable<object[]> UnsupportedGetOutputTestCases => new[]
    {
        new object[] { new Output { Number = 2, Type = OutputType.VirtualOutput}, CommandFactory },
        new object[] { new Output { Number = 2, Type = (OutputType)1000}, CommandFactory }
    };
    
    public static IEnumerable<object[]> SupportedGetOutputsTestCases => new[]
    {
        new object[] { OutputType.Output, Command.CreateGet(GetIO), CommandFactory },
        new object[] { OutputType.OpenCollectorOutput, Command.CreateGet(GetIO), CommandFactory }
    }; 
    
    public static IEnumerable<object[]> UnsupportedGetOutputsTestCases => new[]
    {
        new object[] { OutputType.VirtualOutput, CommandFactory },
        new object[] { (OutputType)1000, CommandFactory }
    }; 
    
    public static IEnumerable<object[]> SupportedSetOutputTestCases => new[]
    {
        new object[] { new Output {Type = OutputType.Output, Number = 65536, State = OutputState.Active }, Command.CreatePut($"{GetIO}/65536", "{on: true}"), CommandFactory },
        new object[] { new Output {Type = OutputType.Output, Number = 65536, State = OutputState.Inactive }, Command.CreatePut($"{GetIO}/65536", "{on: false}"), CommandFactory },
        new object[] { new Output {Type = OutputType.OpenCollectorOutput, Number = 65536, State = OutputState.Active }, Command.CreatePut($"{GetIO}/65536", "{on: true}"), CommandFactory },
        new object[] { new Output {Type = OutputType.OpenCollectorOutput, Number = 65536, State = OutputState.Inactive }, Command.CreatePut($"{GetIO}/65536", "{on: false}"), CommandFactory }
    };
    
    public static IEnumerable<object[]> UnsupportedSetOutputTestCases => new[]
    {
        new object[] { new Output { Number = 2, Type = OutputType.VirtualOutput}, CommandFactory },
        new object[] { new Output { Number = 2, Type = (OutputType)1000}, CommandFactory }
    }; 
}