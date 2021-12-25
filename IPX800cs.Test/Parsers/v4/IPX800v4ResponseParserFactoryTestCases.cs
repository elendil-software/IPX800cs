using System.Collections.Generic;
using IPX800cs.IO;
using IPX800cs.Parsers.v4;
using IPX800cs.Parsers.v4.Http;
using IPX800cs.Parsers.v4.M2M;

namespace IPX800cs.Test.Parsers.v4;

public class IPX800v4ResponseParserFactoryTestCases
{
    private static readonly IPX800V4ResponseParserFactory CommandFactory = new();
    
    public static IEnumerable<object[]> UnsupportedProtocolTestCases => new[]
    {
        new object[] { (IPX800Protocol)1000, CommandFactory}
    };
    
    public static IEnumerable<object[]> UnsupportedInputTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, (InputType)1000, CommandFactory},
        new object[] { IPX800Protocol.M2M, (InputType)1000, CommandFactory}
    };
    
    public static IEnumerable<object[]> SupportedGetInputTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, InputType.DigitalInput, typeof(IPX800v4GetInputHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, InputType.DigitalInput, typeof(IPX800v4GetInputM2MResponseParser), CommandFactory },
        new object[] { IPX800Protocol.Http, InputType.VirtualDigitalInput, typeof(IPX800v4GetVirtualInputHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, InputType.VirtualDigitalInput, typeof(IPX800v4GetVirtualInputM2MResponseParser), CommandFactory }
    };
    
    public static IEnumerable<object[]> SupportedGetInputsTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, InputType.DigitalInput, typeof(IPX800v4GetInputsHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, InputType.DigitalInput, typeof(IPX800v4GetInputsM2MResponseParser), CommandFactory },
        new object[] { IPX800Protocol.Http, InputType.VirtualDigitalInput, typeof(IPX800v4GetVirtualInputsHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, InputType.VirtualDigitalInput, typeof(IPX800v4GetVirtualInputsM2MResponseParser), CommandFactory }
    };
    

    public static IEnumerable<object[]> UnsupportedAnalogInputTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, (InputType)1000, CommandFactory},
        new object[] { IPX800Protocol.M2M, (InputType)1000, CommandFactory}
    };
    
    public static IEnumerable<object[]> SupportedGetAnalogInputTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, AnalogInputType.AnalogInput, typeof(IPX800v4GetAnalogInputHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, AnalogInputType.AnalogInput, typeof(IPX800v4GetAnalogInputM2MResponseParser), CommandFactory },
        new object[] { IPX800Protocol.Http, AnalogInputType.VirtualAnalogInput, typeof(IPX800v4GetVirtualAnalogInputHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, AnalogInputType.VirtualAnalogInput, typeof(IPX800v4GetVirtualAnalogInputM2MResponseParser), CommandFactory }
    };

    public static IEnumerable<object[]> SupportedGetAnalogInputsTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, AnalogInputType.AnalogInput, typeof(IPX800v4GetAnalogInputsHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, AnalogInputType.AnalogInput, typeof(IPX800v4GetAnalogInputsM2MResponseParser), CommandFactory },
        new object[] { IPX800Protocol.Http, AnalogInputType.VirtualAnalogInput, typeof(IPX800v4GetVirtualAnalogInputsHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, AnalogInputType.VirtualAnalogInput, typeof(IPX800v4GetVirtualAnalogInputsM2MResponseParser), CommandFactory }
    };
    
    
    
    public static IEnumerable<object[]> UnsupportedOutputTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, (OutputType)1000, CommandFactory},
        new object[] { IPX800Protocol.M2M, (OutputType)1000, CommandFactory}
    };
    
    public static IEnumerable<object[]> SupportedGetOutputTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, OutputType.Output, typeof(IPX800v4GetOutputHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, OutputType.Output, typeof(IPX800v4GetOutputM2MResponseParser), CommandFactory },
        new object[] { IPX800Protocol.Http, OutputType.VirtualOutput, typeof(IPX800v4GetVirtualOutputHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, OutputType.VirtualOutput, typeof(IPX800v4GetVirtualOutputM2MResponseParser), CommandFactory }
    };
    
    public static IEnumerable<object[]> SupportedGetOutputsTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, OutputType.Output, typeof(IPX800v4GetOutputsHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, OutputType.Output, typeof(IPX800v4GetOutputsM2MResponseParser), CommandFactory },
        new object[] { IPX800Protocol.Http, OutputType.VirtualOutput, typeof(IPX800v4GetVirtualOutputsHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, OutputType.VirtualOutput, typeof(IPX800v4GetVirtualOutputsM2MResponseParser), CommandFactory }
    };



    public static IEnumerable<object[]> SupportedSetOutputTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, typeof(IPX800v4SetOutputHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, typeof(IPX800v4SetOutputM2MResponseParser), CommandFactory }
    };
}