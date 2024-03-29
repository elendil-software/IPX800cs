﻿using System.Collections.Generic;
using IPX800cs.IO;
using IPX800cs.Parsers.v4;
using IPX800cs.Parsers.v4.Http;
using IPX800cs.Parsers.v4.M2M;

namespace IPX800cs.Test.Parsers.v4;

public class IPX800V4ResponseParserFactoryTestCases
{
    private static readonly IPX800V4ResponseParserFactory CommandFactory = new();
    
    public static IEnumerable<object[]> UnsupportedProtocolTestCases => new[]
    {
        new object[] { (IPX800Protocol)1000, CommandFactory}
    };
    
    public static IEnumerable<object[]> UnsupportedInputTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, InputType.OptoInput, CommandFactory},
        new object[] { IPX800Protocol.M2M, InputType.OptoInput, CommandFactory},
        new object[] { IPX800Protocol.Http, (InputType)1000, CommandFactory},
        new object[] { IPX800Protocol.M2M, (InputType)1000, CommandFactory}
    };
    
    public static IEnumerable<object[]> SupportedGetInputTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, InputType.DigitalInput, typeof(IPX800V4GetGetInputHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, InputType.DigitalInput, typeof(IPX800V4GetGetInputM2MResponseParser), CommandFactory },
        new object[] { IPX800Protocol.Http, InputType.VirtualDigitalInput, typeof(IPX800V4GetVirtualGetInputHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, InputType.VirtualDigitalInput, typeof(IPX800V4GetVirtualGetInputM2MResponseParser), CommandFactory }
    };
    
    public static IEnumerable<object[]> SupportedGetInputsTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, InputType.DigitalInput, typeof(IPX800V4GetGetInputsHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, InputType.DigitalInput, typeof(IPX800V4GetGetInputsM2MResponseParser), CommandFactory },
        new object[] { IPX800Protocol.Http, InputType.VirtualDigitalInput, typeof(IPX800V4GetVirtualGetInputsHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, InputType.VirtualDigitalInput, typeof(IPX800V4GetVirtualGetInputsM2MResponseParser), CommandFactory }
    };
    

    public static IEnumerable<object[]> UnsupportedAnalogInputTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, (InputType)1000, CommandFactory},
        new object[] { IPX800Protocol.M2M, (InputType)1000, CommandFactory}
    };
    
    public static IEnumerable<object[]> SupportedGetAnalogInputTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, AnalogInputType.AnalogInput, typeof(IPX800V4GetGetAnalogInputHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, AnalogInputType.AnalogInput, typeof(IPX800V4GetGetAnalogInputM2MResponseParser), CommandFactory },
        new object[] { IPX800Protocol.Http, AnalogInputType.VirtualAnalogInput, typeof(IPX800V4GetVirtualGetAnalogInputHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, AnalogInputType.VirtualAnalogInput, typeof(IPX800V4GetVirtualGetAnalogInputM2MResponseParser), CommandFactory }
    };

    public static IEnumerable<object[]> SupportedGetAnalogInputsTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, AnalogInputType.AnalogInput, typeof(IPX800V4GetAnalogInputsHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, AnalogInputType.AnalogInput, typeof(IPX800V4GetAnalogInputsM2MResponseParser), CommandFactory },
        new object[] { IPX800Protocol.Http, AnalogInputType.VirtualAnalogInput, typeof(IPX800V4GetVirtualAnalogInputsHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, AnalogInputType.VirtualAnalogInput, typeof(IPX800V4GetVirtualAnalogInputsM2MResponseParser), CommandFactory }
    };
    
    
    
    public static IEnumerable<object[]> UnsupportedOutputTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, OutputType.OpenCollectorOutput, CommandFactory},
        new object[] { IPX800Protocol.M2M, OutputType.OpenCollectorOutput, CommandFactory},
        new object[] { IPX800Protocol.Http, OutputType.DelayedOpenCollectorOutput, CommandFactory},
        new object[] { IPX800Protocol.M2M, OutputType.DelayedOpenCollectorOutput, CommandFactory},
        new object[] { IPX800Protocol.Http, (OutputType)1000, CommandFactory},
        new object[] { IPX800Protocol.M2M, (OutputType)1000, CommandFactory}
    };
    
    public static IEnumerable<object[]> SupportedGetOutputTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, OutputType.Output, typeof(IPX800V4GetOutputHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, OutputType.Output, typeof(IPX800V4GetOutputM2MResponseParser), CommandFactory },
        new object[] { IPX800Protocol.Http, OutputType.DelayedOutput, typeof(IPX800V4GetOutputHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, OutputType.DelayedOutput, typeof(IPX800V4GetOutputM2MResponseParser), CommandFactory },
        new object[] { IPX800Protocol.Http, OutputType.VirtualOutput, typeof(IPX800V4GetVirtualOutputHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, OutputType.VirtualOutput, typeof(IPX800V4GetVirtualOutputM2MResponseParser), CommandFactory },
        new object[] { IPX800Protocol.Http, OutputType.DelayedVirtualOutput, typeof(IPX800V4GetVirtualOutputHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, OutputType.DelayedVirtualOutput, typeof(IPX800V4GetVirtualOutputM2MResponseParser), CommandFactory }
    };
    
    public static IEnumerable<object[]> SupportedGetOutputsTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, OutputType.Output, typeof(IPX800V4GetOutputsHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, OutputType.Output, typeof(IPX800V4GetOutputsM2MResponseParser), CommandFactory },
        new object[] { IPX800Protocol.Http, OutputType.DelayedOutput, typeof(IPX800V4GetOutputsHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, OutputType.DelayedOutput, typeof(IPX800V4GetOutputsM2MResponseParser), CommandFactory },
        new object[] { IPX800Protocol.Http, OutputType.VirtualOutput, typeof(IPX800V4GetVirtualOutputsHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, OutputType.VirtualOutput, typeof(IPX800V4GetVirtualOutputsM2MResponseParser), CommandFactory },
        new object[] { IPX800Protocol.Http, OutputType.DelayedVirtualOutput, typeof(IPX800V4GetVirtualOutputsHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, OutputType.DelayedVirtualOutput, typeof(IPX800V4GetVirtualOutputsM2MResponseParser), CommandFactory },
    };



    public static IEnumerable<object[]> SupportedSetOutputTestCases => new[]
    {
        new object[] { IPX800Protocol.Http, typeof(IPX800V4SetOutputHttpResponseParser), CommandFactory },
        new object[] { IPX800Protocol.M2M, typeof(IPX800V4SetOutputM2MResponseParser), CommandFactory }
    };
}