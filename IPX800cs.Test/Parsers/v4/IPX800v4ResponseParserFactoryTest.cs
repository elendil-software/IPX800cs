using System;
using IPX800cs.IO;
using IPX800cs.Parsers.v4;
using IPX800cs.Parsers.v4.Http;
using IPX800cs.Parsers.v4.M2M;
using Xunit;

namespace IPX800cs.Test.Parsers.v4;

public class IPX800v4ResponseParserFactoryTest : IPX800ResponseParserFactoryTestBase
{
    public IPX800v4ResponseParserFactoryTest() : base(new IPX800v4ResponseParserFactoryNew())
    {
    }

    [Theory]
    [InlineData(IPX800Protocol.Http, InputType.AnalogInput, typeof(IPX800v4GetAnalogInputHttpResponseParser))]
    [InlineData(IPX800Protocol.M2M, InputType.AnalogInput, typeof(IPX800v4GetAnalogInputM2MResponseParser))]
    [InlineData(IPX800Protocol.Http, InputType.VirtualAnalogInput, typeof(IPX800v4GetVirtualAnalogInputHttpResponseParser))]
    [InlineData(IPX800Protocol.M2M, InputType.VirtualAnalogInput, typeof(IPX800v4GetVirtualAnalogInputM2MResponseParser))]
    public void GetAnalogInputParser_ReturnsParserCorrespondingToContext(IPX800Protocol protocol, InputType inputType, Type expectedType)
    {
        var parser = _responseParserFactory.GetAnalogInputParser(protocol, inputType);
        Assert.Equal(expectedType, parser.GetType());
    }

    [Theory]
    [InlineData(IPX800Protocol.Http, InputType.DigitalInput, typeof(IPX800v4GetInputHttpResponseParser))]
    [InlineData(IPX800Protocol.M2M, InputType.DigitalInput, typeof(IPX800v4GetInputM2MResponseParser))]
    [InlineData(IPX800Protocol.Http, InputType.VirtualDigitalInput, typeof(IPX800v4GetVirtualInputHttpResponseParser))]
    [InlineData(IPX800Protocol.M2M, InputType.VirtualDigitalInput, typeof(IPX800v4GetVirtualInputM2MResponseParser))]
    public void GetInputParser_ReturnsParserCorrespondingToContext(IPX800Protocol protocol, InputType inputType, Type expectedType)
    {
        var parser = _responseParserFactory.GetInputParser(protocol, inputType);
        Assert.Equal(expectedType, parser.GetType());
    }

    [Theory]
    [InlineData(IPX800Protocol.Http, InputType.DigitalInput, typeof(IPX800v4GetInputsHttpResponseParser))]
    [InlineData(IPX800Protocol.M2M, InputType.DigitalInput, typeof(IPX800v4GetInputsM2MResponseParser))]
    [InlineData(IPX800Protocol.Http, InputType.VirtualDigitalInput, typeof(IPX800v4GetVirtualInputsHttpResponseParser))]
    [InlineData(IPX800Protocol.M2M, InputType.VirtualDigitalInput, typeof(IPX800v4GetVirtualInputsM2MResponseParser))]
    public void GetInputsParser_ReturnsParserCorrespondingToContext(IPX800Protocol protocol, InputType inputType, Type expectedType)
    {
        var parser = _responseParserFactory.GetInputsParser(protocol, inputType);
        Assert.Equal(expectedType, parser.GetType());
    }
        
    [Theory]
    [InlineData(IPX800Protocol.Http, InputType.AnalogInput, typeof(IPX800v4GetAnalogInputsHttpResponseParser))]
    [InlineData(IPX800Protocol.M2M, InputType.AnalogInput, typeof(IPX800v4GetAnalogInputsM2MResponseParser))]
    [InlineData(IPX800Protocol.Http, InputType.VirtualAnalogInput, typeof(IPX800v4GetVirtualAnalogInputsHttpResponseParser))]
    [InlineData(IPX800Protocol.M2M, InputType.VirtualAnalogInput, typeof(IPX800v4GetVirtualAnalogInputsM2MResponseParser))]
    public void GetAnalogInputsParser_ReturnsParserCorrespondingToContext(IPX800Protocol protocol, InputType inputType, Type expectedType)
    {
        var parser = _responseParserFactory.GetAnalogInputsParser(protocol, inputType);
        Assert.Equal(expectedType, parser.GetType());
    }

    [Theory]
    [InlineData(IPX800Protocol.Http, OutputType.Output, typeof(IPX800v4GetOutputHttpResponseParser))]
    [InlineData(IPX800Protocol.M2M, OutputType.Output, typeof(IPX800v4GetOutputM2MResponseParser))]
    [InlineData(IPX800Protocol.Http, OutputType.VirtualOutput, typeof(IPX800v4GetVirtualOutputHttpResponseParser))]
    [InlineData(IPX800Protocol.M2M, OutputType.VirtualOutput, typeof(IPX800v4GetVirtualOutputM2MResponseParser))]
    public void GetOutputParser_ReturnsParserCorrespondingToContext(IPX800Protocol protocol, OutputType outputType, Type expectedType)
    {
        var parser = _responseParserFactory.GetOutputParser(protocol, outputType);
        Assert.Equal(expectedType, parser.GetType());
    }
        
    [Theory]
    [InlineData(IPX800Protocol.Http, OutputType.Output, typeof(IPX800v4GetOutputsHttpResponseParser))]
    [InlineData(IPX800Protocol.M2M, OutputType.Output, typeof(IPX800v4GetOutputsM2MResponseParser))]
    [InlineData(IPX800Protocol.Http, OutputType.VirtualOutput, typeof(IPX800v4GetVirtualOutputsHttpResponseParser))]
    [InlineData(IPX800Protocol.M2M, OutputType.VirtualOutput, typeof(IPX800v4GetVirtualOutputsM2MResponseParser))]
    public void GetOutputsParser_ReturnsParserCorrespondingToContext(IPX800Protocol protocol, OutputType outputType, Type expectedType)
    {
        var parser = _responseParserFactory.GetOutputsParser(protocol, outputType);
        Assert.Equal(expectedType, parser.GetType());
    }
        
    [Theory]
    [InlineData(IPX800Protocol.Http, typeof(IPX800v4SetOutputHttpResponseParser))]
    [InlineData(IPX800Protocol.M2M, typeof(IPX800v4SetOutputM2MResponseParser))]
    public void GetSetOutputParser_ReturnsParserCorrespondingToContext(IPX800Protocol protocol, Type expectedType)
    {
        var parser = _responseParserFactory.GetSetOutputParser(protocol);
        Assert.Equal(expectedType, parser.GetType());
    }
}