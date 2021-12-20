using System;
using IPX800cs.IO;
using IPX800cs.Parsers.v3;
using IPX800cs.Parsers.v3.Http;
using IPX800cs.Parsers.v3.M2M;
using Xunit;

namespace IPX800cs.Test.Parsers.v3;

public class IPX800v3ResponseParserFactoryTest : IPX800ResponseParserFactoryTestBase
{
    public IPX800v3ResponseParserFactoryTest() : base(new IPX800v3ResponseParserFactoryNew())
    {
    }

    [Theory]
    [InlineData(IPX800Protocol.Http, InputType.AnalogInput, typeof(IPX800v3GetAnalogInputHttpResponseParser))]
    [InlineData(IPX800Protocol.M2M, InputType.AnalogInput, typeof(IPX800v3GetAnalogInputM2MResponseParser))]
    public void GetAnalogInputParser_ReturnsParserCorrespondingToContext(IPX800Protocol protocol, InputType inputType, Type expectedType)
    {
        var parser = _responseParserFactory.GetAnalogInputParser(protocol, inputType);
        Assert.Equal(expectedType, parser.GetType());
    }
        
    [Theory]
    [InlineData(IPX800Protocol.Http, InputType.VirtualAnalogInput)]
    [InlineData(IPX800Protocol.M2M, InputType.VirtualAnalogInput)]
    public override void GivenNotSupportedInputType_GetAnalogInputParser_ThrowsIPX800NotSupportedCommandException(IPX800Protocol protocol, InputType inputType)
    {
        base.GivenNotSupportedInputType_GetAnalogInputParser_ThrowsIPX800NotSupportedCommandException(protocol, inputType);
    }
        
    [Theory]
    [InlineData(IPX800Protocol.Http, (InputType)1000)]
    [InlineData(IPX800Protocol.M2M, (InputType)1000)]
    public override void GivenNotSupportedInputType_GetAnalogInputsParser_ThrowsIPX800NotSupportedCommandException(IPX800Protocol protocol, InputType inputType)
    {
        base.GivenNotSupportedInputType_GetAnalogInputsParser_ThrowsIPX800NotSupportedCommandException(protocol, inputType);
    }
        
        
    [Theory]
    [InlineData(IPX800Protocol.Http, InputType.DigitalInput, typeof(IPX800v3GetInputHttpResponseParser))]
    [InlineData(IPX800Protocol.M2M, InputType.DigitalInput, typeof(IPX800v3GetInputM2MResponseParser))]
    public void GetInputParser_ReturnsParserCorrespondingToContext(IPX800Protocol protocol, InputType inputType, Type expectedType)
    {
        var parser = _responseParserFactory.GetInputParser(protocol, inputType);
        Assert.Equal(expectedType, parser.GetType());
    }
        
    [Theory]
    [InlineData(IPX800Protocol.Http, InputType.VirtualDigitalInput)]
    [InlineData(IPX800Protocol.M2M, InputType.VirtualDigitalInput)]
    public override void GivenNotSupportedInputType_GetInputParser_ThrowsIPX800NotSupportedCommandException(IPX800Protocol protocol, InputType inputType)
    {
        base.GivenNotSupportedInputType_GetInputParser_ThrowsIPX800NotSupportedCommandException(protocol, inputType);
    }

    [Theory]
    [InlineData(IPX800Protocol.Http, InputType.DigitalInput, typeof(IPX800v3GetInputsHttpResponseParser))]
    [InlineData(IPX800Protocol.M2M, InputType.DigitalInput, typeof(IPX800v3GetInputsM2MResponseParser))]
    public void GetInputsParser_ReturnsParserCorrespondingToContext(IPX800Protocol protocol, InputType inputType, Type expectedType)
    {
        var parser = _responseParserFactory.GetInputsParser(protocol, inputType);
        Assert.Equal(expectedType, parser.GetType());
    }
        
    [Theory]
    [InlineData(IPX800Protocol.Http, InputType.VirtualDigitalInput)]
    [InlineData(IPX800Protocol.M2M, InputType.VirtualDigitalInput)]
    public override void GivenNotSupportedInputType_GetInputsParser_ThrowsIPX800NotSupportedCommandException(IPX800Protocol protocol, InputType inputType)
    {
        base.GivenNotSupportedInputType_GetInputsParser_ThrowsIPX800NotSupportedCommandException(protocol, inputType);
    }

    [Theory]
    [InlineData(IPX800Protocol.Http, OutputType.Output, typeof(IPX800v3GetOutputHttpResponseParser))]
    [InlineData(IPX800Protocol.M2M, OutputType.Output, typeof(IPX800v3GetOutputM2MResponseParser))]
    public void GetOutputParser_ReturnsParserCorrespondingToContext(IPX800Protocol protocol, OutputType outputType, Type expectedType)
    {
        var parser = _responseParserFactory.GetOutputParser(protocol, outputType);
        Assert.Equal(expectedType, parser.GetType());
    }
        
    [Theory]
    [InlineData(IPX800Protocol.Http, OutputType.VirtualOutput)]
    [InlineData(IPX800Protocol.M2M, OutputType.VirtualOutput)]
    public override void GivenNotSupportedInputType_GetOutputParser_ThrowsIPX800NotSupportedCommandException(IPX800Protocol protocol, OutputType outputType)
    {
        base.GivenNotSupportedInputType_GetOutputParser_ThrowsIPX800NotSupportedCommandException(protocol, outputType);
    }
        
    [Theory]
    [InlineData(IPX800Protocol.Http, OutputType.Output, typeof(IPX800v3GetOutputsHttpResponseParser))]
    [InlineData(IPX800Protocol.M2M, OutputType.Output, typeof(IPX800v3GetOutputsM2MResponseParser))]
    public void GetOutputsParser_ReturnsParserCorrespondingToContext(IPX800Protocol protocol, OutputType outputType, Type expectedType)
    {
        var parser = _responseParserFactory.GetOutputsParser(protocol, outputType);
        Assert.Equal(expectedType, parser.GetType());
    }
        
    [Theory]
    [InlineData(IPX800Protocol.Http, (OutputType)1000)]
    [InlineData(IPX800Protocol.M2M, (OutputType)1000)]
    public override void GivenNotSupportedInputType_GetOutputsParser_ThrowsIPX800NotSupportedCommandException(IPX800Protocol protocol, OutputType outputType)
    {
        base.GivenNotSupportedInputType_GetOutputsParser_ThrowsIPX800NotSupportedCommandException(protocol, outputType);
    }
        
    [Theory]
    [InlineData(IPX800Protocol.Http, typeof(IPX800v3SetOutputHttpResponseParser))]
    [InlineData(IPX800Protocol.M2M, typeof(IPX800v3SetOutputM2MResponseParser))]
    public void SetOutputParser_ReturnsParserCorrespondingToContext(IPX800Protocol protocol, Type expectedType)
    {
        var parser = _responseParserFactory.GetSetOutputParser(protocol);
        Assert.Equal(expectedType, parser.GetType());
    }
}