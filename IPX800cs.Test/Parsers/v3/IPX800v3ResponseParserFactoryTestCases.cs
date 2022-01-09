using System.Collections.Generic;
using IPX800cs.IO;
using IPX800cs.Parsers.v3;
using IPX800cs.Parsers.v3.Http;
using IPX800cs.Parsers.v3.M2M;

namespace IPX800cs.Test.Parsers.v3;

public class IPX800v3ResponseParserFactoryTestCases
{
    private static readonly IPX800V3ResponseParserFactory CommandFactory = new();
    
    public static IEnumerable<object[]> UnsupportedProtocolTestCases => new[]
    {
        new object[] { (IPX800Protocol)1000, CommandFactory}
    };
    
    public static IEnumerable<object[]> UnsupportedInputTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, InputType.VirtualDigitalInput, CommandFactory},
        new object[] { IPX800Protocol.M2M, InputType.VirtualDigitalInput, CommandFactory},
        new object[] { IPX800Protocol.Http, (InputType)1000, CommandFactory},
        new object[] { IPX800Protocol.M2M, (InputType)1000, CommandFactory}
    };
    
    public static IEnumerable<object[]> SupportedGetInputTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, InputType.DigitalInput, typeof(IPX800V3GetGetInputHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, InputType.DigitalInput, typeof(IPX800V3GetGetInputM2MResponseParser), CommandFactory }
    };
    
    public static IEnumerable<object[]> SupportedGetInputsTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, InputType.DigitalInput, typeof(IPX800V3GetGetInputsHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, InputType.DigitalInput, typeof(IPX800V3GetGetInputsM2MResponseParser), CommandFactory }
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
        new object[] { IPX800Protocol.Http, AnalogInputType.AnalogInput, typeof(IPX800V3GetGetAnalogInputHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, AnalogInputType.AnalogInput, typeof(IPX800V3GetGetAnalogInputM2MResponseParser), CommandFactory }
    };

  
     public static IEnumerable<object[]> SupportedGetAnalogInputsTestCases => new[]
     {
         new object[] { IPX800Protocol.Http, AnalogInputType.AnalogInput, typeof(IPX800v3GetAnalogInputsHttpResponseParser), CommandFactory }
     };
    
    public static IEnumerable<object[]> UnsupportedOutputTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, OutputType.VirtualOutput, CommandFactory},
        new object[] { IPX800Protocol.M2M, OutputType.VirtualOutput, CommandFactory},
        new object[] { IPX800Protocol.Http, (OutputType)1000, CommandFactory},
        new object[] { IPX800Protocol.M2M, (OutputType)1000, CommandFactory}
    };
    
    public static IEnumerable<object[]> SupportedGetOutputTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, OutputType.Output, typeof(IPX800v3GetOutputHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, OutputType.Output, typeof(IPX800v3GetOutputM2MResponseParser), CommandFactory }
    };
    
    public static IEnumerable<object[]> SupportedGetOutputsTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, OutputType.Output, typeof(IPX800v3GetOutputsHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, OutputType.Output, typeof(IPX800v3GetOutputsM2MResponseParser), CommandFactory }
    };



    public static IEnumerable<object[]> SupportedSetOutputTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, typeof(IPX800v3SetOutputHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, typeof(IPX800v3SetOutputM2MResponseParser), CommandFactory }
    };
}