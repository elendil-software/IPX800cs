using System;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers;
using IPX800cs.Test.Parsers.v2;
using IPX800cs.Test.Parsers.v3;
using IPX800cs.Test.Parsers.v4;
using Xunit;

namespace IPX800cs.Test.Parsers;

public class IPX800ResponseParserFactoryTest
{
    #region GetInputParser
    
    [Theory]
    [MemberData(nameof(IPX800v2ResponseParserFactoryTestCases.SupportedGetInputTestCases), MemberType = typeof(IPX800v2ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800v3ResponseParserFactoryTestCases.SupportedGetInputTestCases), MemberType = typeof(IPX800v3ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800v4ResponseParserFactoryTestCases.SupportedGetInputTestCases), MemberType = typeof(IPX800v4ResponseParserFactoryTestCases))]
    public void GetInputParser_ReturnsParserCorrespondingToContext(IPX800Protocol protocol, InputType inputType, Type expectedType, IResponseParserFactory responseParserFactory)
    {
        var parser = responseParserFactory.GetInputParser(protocol, inputType);
        Assert.Equal(expectedType, parser.GetType());
    }
    
    [Theory]
    [MemberData(nameof(IPX800v2ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800v2ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800v3ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800v3ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800v4ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800v4ResponseParserFactoryTestCases))]
    public void GivenNotSupportedProtocol_GetInputParser_ThrowsIPX800NotSupportedCommandException(IPX800Protocol protocol, IResponseParserFactory responseParserFactory)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => responseParserFactory.GetInputParser(protocol, InputType.DigitalInput));
    }
    
    [Theory]
    [MemberData(nameof(IPX800v2ResponseParserFactoryTestCases.UnsupportedInputTestCases), MemberType = typeof(IPX800v2ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800v3ResponseParserFactoryTestCases.UnsupportedInputTestCases), MemberType = typeof(IPX800v3ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800v4ResponseParserFactoryTestCases.UnsupportedInputTestCases), MemberType = typeof(IPX800v4ResponseParserFactoryTestCases))]
    public virtual void GivenNotSupportedInputType_GetInputParser_ThrowsIPX800NotSupportedCommandException(IPX800Protocol protocol, InputType inputType, IResponseParserFactory responseParserFactory)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => responseParserFactory.GetInputParser(protocol, inputType));
    }
    
    #endregion
        
    #region GetInputsParser
    
    [Theory]
    //TODO to be implemented
    //[MemberData(nameof(IPX800v2ResponseParserFactoryTestCases.SupportedGetInputsTestCases), MemberType = typeof(IPX800v2ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800v3ResponseParserFactoryTestCases.SupportedGetInputsTestCases), MemberType = typeof(IPX800v3ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800v4ResponseParserFactoryTestCases.SupportedGetInputsTestCases), MemberType = typeof(IPX800v4ResponseParserFactoryTestCases))]
    public void GetInputsParser_ReturnsParserCorrespondingToContext(IPX800Protocol protocol, InputType inputType, Type expectedType, IResponseParserFactory responseParserFactory)
    {
        var parser = responseParserFactory.GetInputsParser(protocol, inputType);
        Assert.Equal(expectedType, parser.GetType());
    }
    
    [Theory]
    [MemberData(nameof(IPX800v2ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800v2ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800v3ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800v3ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800v4ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800v4ResponseParserFactoryTestCases))]
    public void GivenNotSupportedProtocol_GetInputsParser_ThrowsIPX800NotSupportedCommandException(IPX800Protocol protocol, IResponseParserFactory responseParserFactory)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => responseParserFactory.GetInputsParser(protocol, InputType.DigitalInput));
    }
    
    [Theory]
    [MemberData(nameof(IPX800v2ResponseParserFactoryTestCases.UnsupportedInputTestCases), MemberType = typeof(IPX800v2ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800v3ResponseParserFactoryTestCases.UnsupportedInputTestCases), MemberType = typeof(IPX800v3ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800v4ResponseParserFactoryTestCases.UnsupportedInputTestCases), MemberType = typeof(IPX800v4ResponseParserFactoryTestCases))]
    public virtual void GivenNotSupportedInputType_GetInputsParser_ThrowsIPX800NotSupportedCommandException(IPX800Protocol protocol, InputType inputType, IResponseParserFactory responseParserFactory)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => responseParserFactory.GetInputsParser(protocol, inputType));
    }
    
    #endregion

    #region GetAnalogInputParser

    [Theory]
    [MemberData(nameof(IPX800v2ResponseParserFactoryTestCases.SupportedGetAnalogInputTestCases), MemberType = typeof(IPX800v2ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800v3ResponseParserFactoryTestCases.SupportedGetAnalogInputTestCases), MemberType = typeof(IPX800v3ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800v4ResponseParserFactoryTestCases.SupportedGetAnalogInputTestCases), MemberType = typeof(IPX800v4ResponseParserFactoryTestCases))]
    public void GetAnalogInputParser_ReturnsParserCorrespondingToContext(IPX800Protocol protocol, InputType inputType, Type expectedType, IResponseParserFactory responseParserFactory)
    {
        var parser = responseParserFactory.GetAnalogInputParser(protocol, inputType);
        Assert.Equal(expectedType, parser.GetType());
    }
    
    [Theory]
    [MemberData(nameof(IPX800v2ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800v2ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800v3ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800v3ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800v4ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800v4ResponseParserFactoryTestCases))]
    public void GivenNotSupportedProtocol_GetAnalogInputParser_ThrowsIPX800NotSupportedCommandException(IPX800Protocol protocol, IResponseParserFactory responseParserFactory)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => responseParserFactory.GetAnalogInputParser(protocol, InputType.DigitalInput));
    }
    
    [Theory]
    [MemberData(nameof(IPX800v2ResponseParserFactoryTestCases.UnsupportedAnalogInputTestCases), MemberType = typeof(IPX800v2ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800v3ResponseParserFactoryTestCases.UnsupportedAnalogInputTestCases), MemberType = typeof(IPX800v3ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800v4ResponseParserFactoryTestCases.UnsupportedAnalogInputTestCases), MemberType = typeof(IPX800v4ResponseParserFactoryTestCases))]
    public virtual void GivenNotSupportedInputType_GetAnalogInputParser_ThrowsIPX800NotSupportedCommandException(IPX800Protocol protocol, InputType inputType, IResponseParserFactory responseParserFactory)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => responseParserFactory.GetAnalogInputParser(protocol, inputType));
    }
    
    #endregion
    
    #region GetAnalogInputsParser
    
    [Theory]
    //TODO to be implented
    //[MemberData(nameof(IPX800v2ResponseParserFactoryTestCases.SupportedGetAnalogInputsTestCases), MemberType = typeof(IPX800v2ResponseParserFactoryTestCases))]
    //[MemberData(nameof(IPX800v3ResponseParserFactoryTestCases.SupportedGetAnalogInputsTestCases), MemberType = typeof(IPX800v3ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800v4ResponseParserFactoryTestCases.SupportedGetAnalogInputsTestCases), MemberType = typeof(IPX800v4ResponseParserFactoryTestCases))]
    public void GetAnalogInputsParser_ReturnsParserCorrespondingToContext(IPX800Protocol protocol, InputType inputType, Type expectedType, IResponseParserFactory responseParserFactory)
    {
        var parser = responseParserFactory.GetAnalogInputsParser(protocol, inputType);
        Assert.Equal(expectedType, parser.GetType());
    }
    
    [Theory]
    [MemberData(nameof(IPX800v2ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800v2ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800v3ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800v3ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800v4ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800v4ResponseParserFactoryTestCases))]
    public void GivenNotSupportedProtocol_GetAnalogInputsParser_ThrowsIPX800NotSupportedCommandException(IPX800Protocol protocol, IResponseParserFactory responseParserFactory)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => responseParserFactory.GetAnalogInputsParser(protocol, InputType.AnalogInput));
    }
    
    [Theory]
    [MemberData(nameof(IPX800v2ResponseParserFactoryTestCases.UnsupportedAnalogInputTestCases), MemberType = typeof(IPX800v2ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800v3ResponseParserFactoryTestCases.UnsupportedAnalogInputTestCases), MemberType = typeof(IPX800v3ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800v4ResponseParserFactoryTestCases.UnsupportedAnalogInputTestCases), MemberType = typeof(IPX800v4ResponseParserFactoryTestCases))]
    public virtual void GivenNotSupportedInputType_GetAnalogInputsParser_ThrowsIPX800NotSupportedCommandException(IPX800Protocol protocol, InputType inputType, IResponseParserFactory responseParserFactory)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => responseParserFactory.GetAnalogInputsParser(protocol, inputType));
    }
    
    #endregion
    
    #region GetOutputParser
    
    [Theory]
    [MemberData(nameof(IPX800v2ResponseParserFactoryTestCases.SupportedGetOutputTestCases), MemberType = typeof(IPX800v2ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800v3ResponseParserFactoryTestCases.SupportedGetOutputTestCases), MemberType = typeof(IPX800v3ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800v4ResponseParserFactoryTestCases.SupportedGetOutputTestCases), MemberType = typeof(IPX800v4ResponseParserFactoryTestCases))]
    public void GetOutputParser_ReturnsParserCorrespondingToContext(IPX800Protocol protocol, OutputType outputType, Type expectedType, IResponseParserFactory responseParserFactory)
    {
        var parser = responseParserFactory.GetOutputParser(protocol, outputType);
        Assert.Equal(expectedType, parser.GetType());
    }
    
    [Theory]
    [MemberData(nameof(IPX800v2ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800v2ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800v3ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800v3ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800v4ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800v4ResponseParserFactoryTestCases))]
    public void GivenNotSupportedProtocol_GetOutputParser_ThrowsIPX800NotSupportedCommandException(IPX800Protocol protocol, IResponseParserFactory responseParserFactory)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => responseParserFactory.GetOutputParser(protocol, OutputType.Output));
    }
    
    [Theory]
    [MemberData(nameof(IPX800v2ResponseParserFactoryTestCases.UnsupportedOutputTestCases), MemberType = typeof(IPX800v2ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800v3ResponseParserFactoryTestCases.UnsupportedOutputTestCases), MemberType = typeof(IPX800v3ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800v4ResponseParserFactoryTestCases.UnsupportedOutputTestCases), MemberType = typeof(IPX800v4ResponseParserFactoryTestCases))]
    public virtual void GivenNotSupportedInputType_GetOutputParser_ThrowsIPX800NotSupportedCommandException(IPX800Protocol protocol, OutputType outputType, IResponseParserFactory responseParserFactory)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => responseParserFactory.GetOutputParser(protocol, outputType));
    }
    
    #endregion
    
    #region GetOutputsParser
    
    [Theory]
    //TODO to be implemented
    //[MemberData(nameof(IPX800v2ResponseParserFactoryTestCases.SupportedGetOutputsTestCases), MemberType = typeof(IPX800v2ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800v3ResponseParserFactoryTestCases.SupportedGetOutputsTestCases), MemberType = typeof(IPX800v3ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800v4ResponseParserFactoryTestCases.SupportedGetOutputsTestCases), MemberType = typeof(IPX800v4ResponseParserFactoryTestCases))]
    public void GetOutputsParser_ReturnsParserCorrespondingToContext(IPX800Protocol protocol, OutputType outputType, Type expectedType, IResponseParserFactory responseParserFactory)
    {
        var parser = responseParserFactory.GetOutputsParser(protocol, outputType);
        Assert.Equal(expectedType, parser.GetType());
    }
    
    [Theory]
    [MemberData(nameof(IPX800v2ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800v2ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800v3ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800v3ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800v4ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800v4ResponseParserFactoryTestCases))]
    public void GivenNotSupportedProtocol_GetOutputsParser_ThrowsIPX800NotSupportedCommandException(IPX800Protocol protocol, IResponseParserFactory responseParserFactory)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => responseParserFactory.GetOutputsParser(protocol, OutputType.Output));
    }
    
    [Theory]
    [MemberData(nameof(IPX800v2ResponseParserFactoryTestCases.UnsupportedOutputTestCases), MemberType = typeof(IPX800v2ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800v3ResponseParserFactoryTestCases.UnsupportedOutputTestCases), MemberType = typeof(IPX800v3ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800v4ResponseParserFactoryTestCases.UnsupportedOutputTestCases), MemberType = typeof(IPX800v4ResponseParserFactoryTestCases))]
    public virtual void GivenNotSupportedInputType_GetOutputsParser_ThrowsIPX800NotSupportedCommandException(IPX800Protocol protocol, OutputType outputType, IResponseParserFactory responseParserFactory)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => responseParserFactory.GetOutputsParser(protocol, outputType));
    }
    
    #endregion
    
    #region GetSetOutputParser
        
    [Theory]
    [MemberData(nameof(IPX800v2ResponseParserFactoryTestCases.SupportedSetOutputTestCases), MemberType = typeof(IPX800v2ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800v3ResponseParserFactoryTestCases.SupportedSetOutputTestCases), MemberType = typeof(IPX800v3ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800v4ResponseParserFactoryTestCases.SupportedSetOutputTestCases), MemberType = typeof(IPX800v4ResponseParserFactoryTestCases))]
    public void GetSetOutputParser_ReturnsParserCorrespondingToContext(IPX800Protocol protocol, Type expectedType, IResponseParserFactory responseParserFactory)
    {
        var parser = responseParserFactory.GetSetOutputParser(protocol);
        Assert.Equal(expectedType, parser.GetType());
    }
    
    [Theory]
    [MemberData(nameof(IPX800v2ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800v2ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800v3ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800v3ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800v4ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800v4ResponseParserFactoryTestCases))]
    public void GivenNotSupportedProtocol_GetSetOutputParser_ThrowsIPX800NotSupportedCommandException(IPX800Protocol protocol, IResponseParserFactory responseParserFactory)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => responseParserFactory.GetSetOutputParser(protocol));
    }
    
    #endregion
}