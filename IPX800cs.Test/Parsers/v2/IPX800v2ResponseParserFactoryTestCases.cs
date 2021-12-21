using System.Collections.Generic;
using IPX800cs.IO;
using IPX800cs.Parsers.v2;
using IPX800cs.Parsers.v2.Http;
using IPX800cs.Parsers.v2.M2M;
using IPX800cs.Parsers.v3;
using IPX800cs.Parsers.v3.Http;
using IPX800cs.Parsers.v3.M2M;

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
        new object[] { IPX800Protocol.M2M, InputType.VirtualAnalogInput, CommandFactory},
        new object[] { IPX800Protocol.Http, (InputType)1000, CommandFactory},
        new object[] { IPX800Protocol.M2M, (InputType)1000, CommandFactory}
    };
    
    public static IEnumerable<object[]> SupportedGetInputTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, InputType.DigitalInput, typeof(IPX800v2GetInputHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, InputType.DigitalInput, typeof(IPX800v2GetInputM2MResponseParser), CommandFactory }
    };
    
    // TODO to be implemented
    //public static IEnumerable<object[]> SupportedGetInputsTestCases => new[]
    //{
    //    new object[] { IPX800Protocol.Http, InputType.DigitalInput, typeof(IPX800v2GetInputsHttpResponseParser), CommandFactory },
    //    new object[] { IPX800Protocol.M2M, InputType.DigitalInput, typeof(IPX800v2GetInputsM2MResponseParser), CommandFactory }
    //};
    
    
    public static IEnumerable<object[]> UnsupportedAnalogInputTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, InputType.VirtualAnalogInput, CommandFactory},
        new object[] { IPX800Protocol.M2M, InputType.VirtualAnalogInput, CommandFactory},
        new object[] { IPX800Protocol.Http, (InputType)1000, CommandFactory},
        new object[] { IPX800Protocol.M2M, (InputType)1000, CommandFactory}
    };
    
    public static IEnumerable<object[]> SupportedGetAnalogInputTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, InputType.AnalogInput, typeof(IPX800v2GetAnalogInputHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, InputType.AnalogInput, typeof(IPX800v2GetAnalogInputM2MResponseParser), CommandFactory }
    };

    // TODO to be implemented
    // public static IEnumerable<object[]> SupportedGetAnalogInputsTestCases => new[]
    // {
    //     new object[] { IPX800Protocol.Http, InputType.AnalogInput, typeof(IPX800v2GetAnalogInputsHttpResponseParser), CommandFactory },
    //     new object[] { IPX800Protocol.M2M, InputType.AnalogInput, typeof(IPX800v2GetAnalogInputsM2MResponseParser), CommandFactory }
    // };
    
    
    
    public static IEnumerable<object[]> UnsupportedOutputTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, OutputType.VirtualOutput, CommandFactory},
        new object[] { IPX800Protocol.M2M, OutputType.VirtualOutput, CommandFactory},
        new object[] { IPX800Protocol.Http, (OutputType)1000, CommandFactory},
        new object[] { IPX800Protocol.M2M, (OutputType)1000, CommandFactory}
    };
    
    public static IEnumerable<object[]> SupportedGetOutputTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, OutputType.Output, typeof(IPX800v2GetOutputHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, OutputType.Output, typeof(IPX800v2GetOutputM2MResponseParser), CommandFactory }
    };
    
    // TODO to be implemented
    // public static IEnumerable<object[]> SupportedGetOutputsTestCases => new[]
    // {
    //     new object[] { IPX800Protocol.Http, OutputType.Output, typeof(IPX800v2GetOutputsHttpResponseParser), CommandFactory },
    //     new object[] { IPX800Protocol.M2M, OutputType.Output, typeof(IPX800v2GetOutputsM2MResponseParser), CommandFactory }
    // };



    public static IEnumerable<object[]> SupportedSetOutputTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, typeof(IPX800v2SetOutputHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, typeof(IPX800v2SetOutputM2MResponseParser), CommandFactory }
    };
}