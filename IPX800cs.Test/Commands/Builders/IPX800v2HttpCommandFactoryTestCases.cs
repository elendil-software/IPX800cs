using System.Collections.Generic;
using IPX800cs.Commands;
using IPX800cs.Commands.Builders.v2;
using IPX800cs.IO;

namespace IPX800cs.Test.Commands.Builders;

public class IPX800V2HttpCommandFactoryTestCases
{
    private static readonly IPX800v2HttpCommandFactory CommandFactory = new();
    
    public static IEnumerable<object[]> SupportedGetInputTestCases => new[]
    {
        new object[] { new Input { Number = 2, Type = InputType.DigitalInput}, Command.CreateGet(IPX800TestConst.StatusXml), CommandFactory },
    };
    
    public static IEnumerable<object[]> UnsupportedGetInputTestCases => new[]
    {
        new object[] { new Input { Number = 2, Type = InputType.VirtualDigitalInput}, CommandFactory },
        new object[] { new Input { Number = 2, Type = InputType.OptoInput}, CommandFactory }
    };

    
    public static IEnumerable<object[]> SupportedGetInputsTestCases => new[]
    {
         new object[] { InputType.DigitalInput, Command.CreateGet(IPX800TestConst.StatusXml), CommandFactory }
    };
    
    public static IEnumerable<object[]> UnsupportedGetInputsTestCases => new[]
    {
        new object[] { InputType.VirtualDigitalInput, CommandFactory },
        new object[] { InputType.OptoInput, CommandFactory },
        new object[] { (InputType)1000, CommandFactory }
    };
    
    public static IEnumerable<object[]> SupportedGetAnalogInputTestCases => new[]
    {
        new object[] { new AnalogInput { Number = 2, Type = AnalogInputType.AnalogInput}, Command.CreateGet(IPX800TestConst.StatusXml), CommandFactory },
    };
    
    public static IEnumerable<object[]> UnsupportedGetAnalogInputTestCases => new[]
    {
        new object[] { new AnalogInput { Number = 2, Type = AnalogInputType.VirtualAnalogInput}, CommandFactory },
    };
    
    public static IEnumerable<object[]> SupportedGetAnalogInputsTestCases => new[]
    {
         new object[] { AnalogInputType.AnalogInput, Command.CreateGet(IPX800TestConst.StatusXml), CommandFactory }
    };
    
    public static IEnumerable<object[]> UnsupportedGetAnalogInputsTestCases => new[]
    {
        new object[] { AnalogInputType.VirtualAnalogInput, CommandFactory },
        new object[] { (AnalogInputType)1000, CommandFactory }
    };
    
    public static IEnumerable<object[]> SupportedGetOutputTestCases => new[]
    {
        new object[] { new Output { Number = 2, Type = OutputType.Output}, Command.CreateGet(IPX800TestConst.StatusXml), CommandFactory },
        new object[] { new Output { Number = 2, Type = OutputType.DelayedOutput}, Command.CreateGet(IPX800TestConst.StatusXml), CommandFactory }
    };
    
    public static IEnumerable<object[]> UnsupportedGetOutputTestCases => new[]
    {
        new object[] { new Output { Number = 2, Type = OutputType.VirtualOutput}, CommandFactory },
        new object[] { new Output { Number = 2, Type = OutputType.DelayedVirtualOutput}, CommandFactory },
        new object[] { new Output { Number = 2, Type = OutputType.OpenCollectorOutput}, CommandFactory },
        new object[] { new Output { Number = 2, Type = (OutputType)1000}, CommandFactory }
    };
    
     public static IEnumerable<object[]> SupportedGetOutputsTestCases => new[]
     {
         new object[] { OutputType.Output, Command.CreateGet(IPX800TestConst.StatusXml), CommandFactory },
         new object[] { OutputType.DelayedOutput, Command.CreateGet(IPX800TestConst.StatusXml), CommandFactory }
     }; 
    
    public static IEnumerable<object[]> UnsupportedGetOutputsTestCases => new[]
    {
        new object[] { OutputType.VirtualOutput, CommandFactory },
        new object[] { OutputType.DelayedVirtualOutput, CommandFactory },
        new object[] { OutputType.OpenCollectorOutput, CommandFactory },
        new object[] { (OutputType)1000, CommandFactory }
    }; 
    
    public static IEnumerable<object[]> SupportedSetOutputTestCases => new[]
    {
        new object[] { new Output {Type = OutputType.Output, Number = 2, State = OutputState.Active }, Command.CreateGet("preset.htm?led2=1"), CommandFactory },
        new object[] { new Output {Type = OutputType.DelayedOutput, Number = 2, State = OutputState.Active }, Command.CreateGet("preset.htm?RLY2=1"), CommandFactory },
        new object[] { new Output {Type = OutputType.Output, Number = 2, State = OutputState.Inactive }, Command.CreateGet("preset.htm?led2=0"), CommandFactory },
        new object[] { new Output {Type = OutputType.DelayedOutput, Number = 2, State = OutputState.Inactive }, Command.CreateGet("preset.htm?led2=0"), CommandFactory }
    };
    
    public static IEnumerable<object[]> UnsupportedSetOutputTestCases => new[]
    {
        new object[] { new Output { Number = 2, Type = OutputType.VirtualOutput}, CommandFactory },
        new object[] { new Output { Number = 2, Type = OutputType.OpenCollectorOutput}, CommandFactory }
    }; 
}