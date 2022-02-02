using System.Collections.Generic;
using IPX800cs.IO;
using IPX800cs.Parsers.v5;

namespace IPX800cs.Test.Parsers.v5;

public class IPX800V5ResponseParserFactoryTestCases
{
    private static readonly IPX800V5ResponseParserFactory CommandFactory = new();
    
    public static IEnumerable<object[]> UnsupportedProtocolTestCases => new[]
    {
        new object[] { IPX800Protocol.M2M, CommandFactory},
        new object[] { (IPX800Protocol)1000, CommandFactory}
    };
    
    public static IEnumerable<object[]> UnsupportedInputTestCases => new[]
    {
        new object[] { IPX800Protocol.M2M, InputType.DigitalInput, CommandFactory},
        new object[] { IPX800Protocol.M2M, InputType.OptoInput, CommandFactory},
        new object[] { IPX800Protocol.Http, InputType.VirtualDigitalInput, CommandFactory},
        new object[] { IPX800Protocol.M2M, InputType.VirtualDigitalInput, CommandFactory},
        new object[] { IPX800Protocol.Http, (InputType)1000, CommandFactory},
        new object[] { IPX800Protocol.M2M, (InputType)1000, CommandFactory}
    };
    
    public static IEnumerable<object[]> SupportedGetInputTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, InputType.DigitalInput, typeof(IPX800V5GetInputResponseParser), CommandFactory },
        new object[] { IPX800Protocol.Http, InputType.OptoInput, typeof(IPX800V5GetInputResponseParser), CommandFactory }
    };
    
    public static IEnumerable<object[]> SupportedGetInputsTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, InputType.DigitalInput, typeof(IPX800V5GetInputsResponseParser), CommandFactory },
        new object[] { IPX800Protocol.Http, InputType.OptoInput, typeof(IPX800V5GetOptoInputsResponseParser), CommandFactory }
    };
    

    public static IEnumerable<object[]> UnsupportedAnalogInputTestCases => new[]
    {
        new object[] { IPX800Protocol.M2M, AnalogInputType.AnalogInput, CommandFactory},
        new object[] { IPX800Protocol.Http, AnalogInputType.VirtualAnalogInput, CommandFactory},
        new object[] { IPX800Protocol.M2M, AnalogInputType.VirtualAnalogInput, CommandFactory},
        new object[] { IPX800Protocol.Http, (InputType)1000, CommandFactory},
        new object[] { IPX800Protocol.M2M, (InputType)1000, CommandFactory}
    };
    
    public static IEnumerable<object[]> SupportedGetAnalogInputTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, AnalogInputType.AnalogInput, typeof(IPX800V5GetAnalogInputResponseParser), CommandFactory }
    };

    public static IEnumerable<object[]> SupportedGetAnalogInputsTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, AnalogInputType.AnalogInput, typeof(IPX800V5GetAnalogInputsResponseParser), CommandFactory }
    };
    
    
    
    public static IEnumerable<object[]> UnsupportedOutputTestCases => new[]
    {
        new object[] { IPX800Protocol.M2M, OutputType.Output, CommandFactory},
        new object[] { IPX800Protocol.Http, OutputType.VirtualOutput, CommandFactory},
        new object[] { IPX800Protocol.M2M, OutputType.VirtualOutput, CommandFactory},
        new object[] { IPX800Protocol.Http, (OutputType)1000, CommandFactory},
        new object[] { IPX800Protocol.M2M, (OutputType)1000, CommandFactory}
    };
    
    public static IEnumerable<object[]> SupportedGetOutputTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, OutputType.Output, typeof(IPX800V5GetOutputResponseParser), CommandFactory }
    };
    
    public static IEnumerable<object[]> SupportedGetOutputsTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, OutputType.Output, typeof(IPX800V5GetOutputsResponseParser), CommandFactory }
    };
    
    public static IEnumerable<object[]> SupportedSetOutputTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, typeof(IPX800V5SetOutputResponseParser), CommandFactory }
    };
}