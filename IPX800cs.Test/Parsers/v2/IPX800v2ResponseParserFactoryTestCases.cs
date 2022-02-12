using System.Collections.Generic;
using IPX800cs.IO;
using IPX800cs.Parsers.v2;
using IPX800cs.Parsers.v2.Http;
using IPX800cs.Parsers.v2.M2M;

namespace IPX800cs.Test.Parsers.v2;

public class IPX800v2ResponseParserFactoryTestCases
{
    private static readonly IPX800v2ResponseParserFactory CommandFactory = new();
    
    public static IEnumerable<object[]> UnsupportedProtocolTestCases => new[]
    {
        new object[] { (IPX800Protocol)1000, CommandFactory}
    };
    
    public static IEnumerable<object[]> UnsupportedInputTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, InputType.VirtualDigitalInput, CommandFactory},
        new object[] { IPX800Protocol.M2M, InputType.VirtualDigitalInput, CommandFactory},
        new object[] { IPX800Protocol.Http, InputType.OptoInput, CommandFactory},
        new object[] { IPX800Protocol.M2M, InputType.OptoInput, CommandFactory},
        new object[] { IPX800Protocol.Http, (InputType)1000, CommandFactory},
        new object[] { IPX800Protocol.M2M, (InputType)1000, CommandFactory}
    };
    
    public static IEnumerable<object[]> UnsupportedInputsTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, InputType.VirtualDigitalInput, CommandFactory},
        new object[] { IPX800Protocol.M2M, InputType.VirtualDigitalInput, CommandFactory},
        new object[] { IPX800Protocol.Http, InputType.OptoInput, CommandFactory},
        new object[] { IPX800Protocol.M2M, InputType.OptoInput, CommandFactory},
        new object[] { IPX800Protocol.M2M, InputType.DigitalInput, CommandFactory},
        new object[] { IPX800Protocol.Http, (InputType)1000, CommandFactory},
        new object[] { IPX800Protocol.M2M, (InputType)1000, CommandFactory}
    };
    
    public static IEnumerable<object[]> SupportedGetInputTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, InputType.DigitalInput, typeof(IPX800V2GetGetInputHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, InputType.DigitalInput, typeof(IPX800V2GetGetInputM2MResponseParser), CommandFactory }
    };

    public static IEnumerable<object[]> SupportedGetInputsTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, InputType.DigitalInput, typeof(IPX800V2GetGetInputsHttpResponseParser), CommandFactory },
    };
    
    
    public static IEnumerable<object[]> UnsupportedAnalogInputTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, AnalogInputType.VirtualAnalogInput, CommandFactory},
        new object[] { IPX800Protocol.M2M, AnalogInputType.VirtualAnalogInput, CommandFactory},
        new object[] { IPX800Protocol.Http, (AnalogInputType)1000, CommandFactory},
        new object[] { IPX800Protocol.M2M, (AnalogInputType)1000, CommandFactory}
    };
    
    public static IEnumerable<object[]> UnsupportedAnalogInputsTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, AnalogInputType.VirtualAnalogInput, CommandFactory},
        new object[] { IPX800Protocol.M2M, AnalogInputType.VirtualAnalogInput, CommandFactory},
        new object[] { IPX800Protocol.M2M, AnalogInputType.AnalogInput, CommandFactory},
        new object[] { IPX800Protocol.Http, (AnalogInputType)1000, CommandFactory},
        new object[] { IPX800Protocol.M2M, (AnalogInputType)1000, CommandFactory}
    };
    
    public static IEnumerable<object[]> SupportedGetAnalogInputTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, AnalogInputType.AnalogInput, typeof(IPX800V2GetGetAnalogInputHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, AnalogInputType.AnalogInput, typeof(IPX800V2GetGetAnalogInputM2MResponseParser), CommandFactory }
    };

    public static IEnumerable<object[]> SupportedGetAnalogInputsTestCases => new[]
    {
         new object[] { IPX800Protocol.Http, AnalogInputType.AnalogInput, typeof(IPX800v2GetAnalogInputsHttpResponseParser), CommandFactory },
    };
    
    
    
    public static IEnumerable<object[]> UnsupportedOutputTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, OutputType.VirtualOutput, CommandFactory},
        new object[] { IPX800Protocol.M2M, OutputType.VirtualOutput, CommandFactory},
        new object[] { IPX800Protocol.Http, OutputType.DelayedVirtualOutput, CommandFactory},
        new object[] { IPX800Protocol.M2M, OutputType.DelayedVirtualOutput, CommandFactory},
        new object[] { IPX800Protocol.Http, OutputType.OpenCollectorOutput, CommandFactory},
        new object[] { IPX800Protocol.M2M, OutputType.OpenCollectorOutput, CommandFactory},
        new object[] { IPX800Protocol.Http, OutputType.DelayedOpenCollectorOutput, CommandFactory},
        new object[] { IPX800Protocol.M2M, OutputType.DelayedOpenCollectorOutput, CommandFactory},
        new object[] { IPX800Protocol.Http, (OutputType)1000, CommandFactory},
        new object[] { IPX800Protocol.M2M, (OutputType)1000, CommandFactory}
    };
    
    public static IEnumerable<object[]> UnsupportedOutputsTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, OutputType.VirtualOutput, CommandFactory},
        new object[] { IPX800Protocol.M2M, OutputType.VirtualOutput, CommandFactory},
        new object[] { IPX800Protocol.Http, OutputType.DelayedVirtualOutput, CommandFactory},
        new object[] { IPX800Protocol.M2M, OutputType.DelayedVirtualOutput, CommandFactory},
        new object[] { IPX800Protocol.Http, OutputType.OpenCollectorOutput, CommandFactory},
        new object[] { IPX800Protocol.M2M, OutputType.OpenCollectorOutput, CommandFactory},
        new object[] { IPX800Protocol.M2M, OutputType.Output, CommandFactory},
        new object[] { IPX800Protocol.Http, (OutputType)1000, CommandFactory},
        new object[] { IPX800Protocol.M2M, (OutputType)1000, CommandFactory}
    };
    
    public static IEnumerable<object[]> SupportedGetOutputTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, OutputType.Output, typeof(IPX800v2GetOutputHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, OutputType.Output, typeof(IPX800v2GetOutputM2MResponseParser), CommandFactory },
        new object[] { IPX800Protocol.Http, OutputType.DelayedOutput, typeof(IPX800v2GetOutputHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, OutputType.DelayedOutput, typeof(IPX800v2GetOutputM2MResponseParser), CommandFactory }
    };
    
    
    public static IEnumerable<object[]> SupportedGetOutputsTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, OutputType.Output, typeof(IPX800v2GetOutputsHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.Http, OutputType.DelayedOutput, typeof(IPX800v2GetOutputsHttpResponseParser), CommandFactory }
    };

    
    public static IEnumerable<object[]> SupportedSetOutputTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, typeof(IPX800v2SetOutputHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, typeof(IPX800v2SetOutputM2MResponseParser), CommandFactory }
    };
}