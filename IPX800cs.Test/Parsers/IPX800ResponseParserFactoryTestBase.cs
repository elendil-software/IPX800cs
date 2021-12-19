using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers;
using Xunit;

namespace IPX800cs.Test.Parsers;

public abstract class IPX800ResponseParserFactoryTestBase
{
    protected readonly IResponseParserFactoryNew _responseParserFactory;

    protected IPX800ResponseParserFactoryTestBase(IResponseParserFactoryNew responseParserFactory)
    {
        _responseParserFactory = responseParserFactory;
    }

    [Fact]
    public void GivenNotSupportedProtocol_GetAnalogInputParser_ThrowsIPX800NotSupportedCommandException()
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => _responseParserFactory.GetAnalogInputParser((IPX800Protocol)1000, InputType.DigitalInput));
    }
    
    [Theory]
    [InlineData(IPX800Protocol.Http, (InputType)1000)]
    [InlineData(IPX800Protocol.M2M, (InputType)1000)]
    public virtual void GivenNotSupportedInputType_GetAnalogInputParser_ThrowsIPX800NotSupportedCommandException(IPX800Protocol protocol, InputType inputType)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => _responseParserFactory.GetAnalogInputParser(protocol, inputType));
    }
    
    [Fact]
    public void GivenNotSupportedProtocol_GetAnalogInputsParser_ThrowsIPX800NotSupportedCommandException()
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => _responseParserFactory.GetAnalogInputsParser((IPX800Protocol)1000, InputType.AnalogInput));
    }
    
    [Theory]
    [InlineData(IPX800Protocol.Http, (InputType)1000)]
    [InlineData(IPX800Protocol.M2M, (InputType)1000)]
    public virtual void GivenNotSupportedInputType_GetAnalogInputsParser_ThrowsIPX800NotSupportedCommandException(IPX800Protocol protocol, InputType inputType)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => _responseParserFactory.GetAnalogInputsParser(protocol, inputType));
    }
    
    [Fact]
    public void GivenNotSupportedProtocol_GetInputParser_ThrowsIPX800NotSupportedCommandException()
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => _responseParserFactory.GetInputParser((IPX800Protocol)1000, InputType.DigitalInput));
    }
    
    [Theory]
    [InlineData(IPX800Protocol.Http, (InputType)1000)]
    [InlineData(IPX800Protocol.M2M, (InputType)1000)]
    public virtual void GivenNotSupportedInputType_GetInputParser_ThrowsIPX800NotSupportedCommandException(IPX800Protocol protocol, InputType inputType)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => _responseParserFactory.GetInputParser(protocol, inputType));
    }
        
    [Fact]
    public void GivenNotSupportedProtocol_GetInputsParser_ThrowsIPX800NotSupportedCommandException()
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => _responseParserFactory.GetInputsParser((IPX800Protocol)1000, InputType.DigitalInput));
    }
    
    [Theory]
    [InlineData(IPX800Protocol.Http, (InputType)1000)]
    [InlineData(IPX800Protocol.M2M, (InputType)1000)]
    public virtual void GivenNotSupportedInputType_GetInputsParser_ThrowsIPX800NotSupportedCommandException(IPX800Protocol protocol, InputType inputType)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => _responseParserFactory.GetInputsParser(protocol, inputType));
    }
    
    [Fact]
    public void GivenNotSupportedProtocol_GetOutputParser_ThrowsIPX800NotSupportedCommandException()
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => _responseParserFactory.GetOutputParser((IPX800Protocol)1000, OutputType.Output));
    }
    
    [Theory]
    [InlineData(IPX800Protocol.Http, (OutputType)1000)]
    [InlineData(IPX800Protocol.M2M, (OutputType)1000)]
    public virtual void GivenNotSupportedInputType_GetOutputParser_ThrowsIPX800NotSupportedCommandException(IPX800Protocol protocol, OutputType outputType)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => _responseParserFactory.GetOutputParser(protocol, outputType));
    }
        
    [Fact]
    public void GivenNotSupportedProtocol_GetOutputsParser_ThrowsIPX800NotSupportedCommandException()
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => _responseParserFactory.GetOutputsParser((IPX800Protocol)1000, OutputType.Output));
    }
    
    [Theory]
    [InlineData(IPX800Protocol.Http, (OutputType)1000)]
    [InlineData(IPX800Protocol.M2M, (OutputType)1000)]
    public virtual void GivenNotSupportedInputType_GetOutputsParser_ThrowsIPX800NotSupportedCommandException(IPX800Protocol protocol, OutputType outputType)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => _responseParserFactory.GetOutputsParser(protocol, outputType));
    }
        
    [Fact]
    public void GivenNotSupportedProtocol_GetSetOutputParser_ThrowsIPX800NotSupportedCommandException()
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => _responseParserFactory.GetSetOutputParser((IPX800Protocol)1000));
    }
}