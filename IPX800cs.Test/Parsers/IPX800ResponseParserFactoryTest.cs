﻿using System;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers;
using IPX800cs.Test.Parsers.v2;
using IPX800cs.Test.Parsers.v3;
using IPX800cs.Test.Parsers.v4;
using IPX800cs.Test.Parsers.v5;
using Xunit;

namespace IPX800cs.Test.Parsers;

public class IPX800ResponseParserFactoryTest
{
    #region CreateGetInputParser
    
    [Theory]
    [MemberData(nameof(IPX800V2ResponseParserFactoryTestCases.SupportedGetInputTestCases), MemberType = typeof(IPX800V2ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V3ResponseParserFactoryTestCases.SupportedGetInputTestCases), MemberType = typeof(IPX800V3ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V4ResponseParserFactoryTestCases.SupportedGetInputTestCases), MemberType = typeof(IPX800V4ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V5ResponseParserFactoryTestCases.SupportedGetInputTestCases), MemberType = typeof(IPX800V5ResponseParserFactoryTestCases))]
    public void GetInputParser_ReturnsParserCorrespondingToContext(IPX800Protocol protocol, InputType inputType, Type expectedType, IResponseParserFactory responseParserFactory)
    {
        var parser = responseParserFactory.CreateGetInputParser(protocol, inputType);
        Assert.Equal(expectedType, parser.GetType());
    }
    
    [Theory]
    [MemberData(nameof(IPX800V2ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800V2ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V3ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800V3ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V4ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800V4ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V5ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800V5ResponseParserFactoryTestCases))]
    public void GivenNotSupportedProtocol_CreateGetInputParser_ThrowsIPX800NotSupportedCommandException(IPX800Protocol protocol, IResponseParserFactory responseParserFactory)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => responseParserFactory.CreateGetInputParser(protocol, InputType.DigitalInput));
    }
    
    [Theory]
    [MemberData(nameof(IPX800V2ResponseParserFactoryTestCases.UnsupportedInputTestCases), MemberType = typeof(IPX800V2ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V3ResponseParserFactoryTestCases.UnsupportedInputTestCases), MemberType = typeof(IPX800V3ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V4ResponseParserFactoryTestCases.UnsupportedInputTestCases), MemberType = typeof(IPX800V4ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V5ResponseParserFactoryTestCases.UnsupportedInputTestCases), MemberType = typeof(IPX800V5ResponseParserFactoryTestCases))]
    public virtual void GivenNotSupportedInputType_CreateGetInputParser_ThrowsIPX800NotSupportedCommandException(IPX800Protocol protocol, InputType inputType, IResponseParserFactory responseParserFactory)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => responseParserFactory.CreateGetInputParser(protocol, inputType));
    }
    
    #endregion
        
    #region CreateGetInputsParser
    
    [Theory]
    [MemberData(nameof(IPX800V2ResponseParserFactoryTestCases.SupportedGetInputsTestCases), MemberType = typeof(IPX800V2ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V3ResponseParserFactoryTestCases.SupportedGetInputsTestCases), MemberType = typeof(IPX800V3ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V4ResponseParserFactoryTestCases.SupportedGetInputsTestCases), MemberType = typeof(IPX800V4ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V5ResponseParserFactoryTestCases.SupportedGetInputsTestCases), MemberType = typeof(IPX800V5ResponseParserFactoryTestCases))]
    public void GetInputsParser_ReturnsParserCorrespondingToContext(IPX800Protocol protocol, InputType inputType, Type expectedType, IResponseParserFactory responseParserFactory)
    {
        var parser = responseParserFactory.CreateGetInputsParser(protocol, inputType);
        Assert.Equal(expectedType, parser.GetType());
    }
    
    [Theory]
    [MemberData(nameof(IPX800V2ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800V2ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V3ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800V3ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V4ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800V4ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V5ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800V5ResponseParserFactoryTestCases))]
    public void GivenNotSupportedProtocol_CreateGetInputsParser_ThrowsIPX800NotSupportedCommandException(IPX800Protocol protocol, IResponseParserFactory responseParserFactory)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => responseParserFactory.CreateGetInputsParser(protocol, InputType.DigitalInput));
    }
    
    [Theory]
    [MemberData(nameof(IPX800V2ResponseParserFactoryTestCases.UnsupportedInputsTestCases), MemberType = typeof(IPX800V2ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V3ResponseParserFactoryTestCases.UnsupportedInputTestCases), MemberType = typeof(IPX800V3ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V4ResponseParserFactoryTestCases.UnsupportedInputTestCases), MemberType = typeof(IPX800V4ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V5ResponseParserFactoryTestCases.UnsupportedInputTestCases), MemberType = typeof(IPX800V5ResponseParserFactoryTestCases))]
    public virtual void GivenNotSupportedInputType_CreateGetInputsParser_ThrowsIPX800NotSupportedCommandException(IPX800Protocol protocol, InputType inputType, IResponseParserFactory responseParserFactory)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => responseParserFactory.CreateGetInputsParser(protocol, inputType));
    }
    
    #endregion

    #region CreateGetAnalogInputParser

    [Theory]
    [MemberData(nameof(IPX800V2ResponseParserFactoryTestCases.SupportedGetAnalogInputTestCases), MemberType = typeof(IPX800V2ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V3ResponseParserFactoryTestCases.SupportedGetAnalogInputTestCases), MemberType = typeof(IPX800V3ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V4ResponseParserFactoryTestCases.SupportedGetAnalogInputTestCases), MemberType = typeof(IPX800V4ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V5ResponseParserFactoryTestCases.SupportedGetAnalogInputTestCases), MemberType = typeof(IPX800V5ResponseParserFactoryTestCases))]
    public void GetAnalogInputParser_ReturnsParserCorrespondingToContext(IPX800Protocol protocol, AnalogInputType analogInputType, Type expectedType, IResponseParserFactory responseParserFactory)
    {
        var parser = responseParserFactory.CreateGetAnalogInputParser(protocol, analogInputType);
        Assert.Equal(expectedType, parser.GetType());
    }
    
    [Theory]
    [MemberData(nameof(IPX800V2ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800V2ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V3ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800V3ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V4ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800V4ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V5ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800V5ResponseParserFactoryTestCases))]
    public void GivenNotSupportedProtocol_CreateGetAnalogInputParser_ThrowsIPX800NotSupportedCommandException(IPX800Protocol protocol, IResponseParserFactory responseParserFactory)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => responseParserFactory.CreateGetAnalogInputParser(protocol, AnalogInputType.AnalogInput));
    }
    
    [Theory]
    [MemberData(nameof(IPX800V2ResponseParserFactoryTestCases.UnsupportedAnalogInputTestCases), MemberType = typeof(IPX800V2ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V3ResponseParserFactoryTestCases.UnsupportedAnalogInputTestCases), MemberType = typeof(IPX800V3ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V4ResponseParserFactoryTestCases.UnsupportedAnalogInputTestCases), MemberType = typeof(IPX800V4ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V5ResponseParserFactoryTestCases.UnsupportedAnalogInputTestCases), MemberType = typeof(IPX800V5ResponseParserFactoryTestCases))]
    public virtual void GivenNotSupportedInputType_CreateGetAnalogInputParser_ThrowsIPX800NotSupportedCommandException(IPX800Protocol protocol, AnalogInputType analogInputType, IResponseParserFactory responseParserFactory)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => responseParserFactory.CreateGetAnalogInputParser(protocol, analogInputType));
    }
    
    #endregion
    
    #region CreateGetAnalogInputsParser
    
    [Theory]
    [MemberData(nameof(IPX800V2ResponseParserFactoryTestCases.SupportedGetAnalogInputsTestCases), MemberType = typeof(IPX800V2ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V3ResponseParserFactoryTestCases.SupportedGetAnalogInputsTestCases), MemberType = typeof(IPX800V3ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V4ResponseParserFactoryTestCases.SupportedGetAnalogInputsTestCases), MemberType = typeof(IPX800V4ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V5ResponseParserFactoryTestCases.SupportedGetAnalogInputsTestCases), MemberType = typeof(IPX800V5ResponseParserFactoryTestCases))]
    public void GetAnalogInputsParser_ReturnsParserCorrespondingToContext(IPX800Protocol protocol, AnalogInputType analogInputType, Type expectedType, IResponseParserFactory responseParserFactory)
    {
        var parser = responseParserFactory.CreateGetAnalogInputsParser(protocol, analogInputType);
        Assert.Equal(expectedType, parser.GetType());
    }
    
    [Theory]
    [MemberData(nameof(IPX800V2ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800V2ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V3ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800V3ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V4ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800V4ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V5ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800V5ResponseParserFactoryTestCases))]
    public void GivenNotSupportedProtocol_CreateGetAnalogInputsParser_ThrowsIPX800NotSupportedCommandException(IPX800Protocol protocol, IResponseParserFactory responseParserFactory)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => responseParserFactory.CreateGetAnalogInputsParser(protocol, AnalogInputType.AnalogInput));
    }
    
    [Theory]
    [MemberData(nameof(IPX800V2ResponseParserFactoryTestCases.UnsupportedAnalogInputsTestCases), MemberType = typeof(IPX800V2ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V3ResponseParserFactoryTestCases.UnsupportedAnalogInputsTestCases), MemberType = typeof(IPX800V3ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V4ResponseParserFactoryTestCases.UnsupportedAnalogInputTestCases), MemberType = typeof(IPX800V4ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V5ResponseParserFactoryTestCases.UnsupportedAnalogInputTestCases), MemberType = typeof(IPX800V5ResponseParserFactoryTestCases))]
    public virtual void GivenNotSupportedInputType_CreateGetAnalogInputsParser_ThrowsIPX800NotSupportedCommandException(IPX800Protocol protocol, AnalogInputType analogInputType, IResponseParserFactory responseParserFactory)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => responseParserFactory.CreateGetAnalogInputsParser(protocol, analogInputType));
    }
    
    #endregion
    
    #region CreateGetOutputParser
    
    [Theory]
    [MemberData(nameof(IPX800V2ResponseParserFactoryTestCases.SupportedGetOutputTestCases), MemberType = typeof(IPX800V2ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V3ResponseParserFactoryTestCases.SupportedGetOutputTestCases), MemberType = typeof(IPX800V3ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V4ResponseParserFactoryTestCases.SupportedGetOutputTestCases), MemberType = typeof(IPX800V4ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V5ResponseParserFactoryTestCases.SupportedGetOutputTestCases), MemberType = typeof(IPX800V5ResponseParserFactoryTestCases))]
    public void GetOutputParser_ReturnsParserCorrespondingToContext(IPX800Protocol protocol, OutputType outputType, Type expectedType, IResponseParserFactory responseParserFactory)
    {
        var parser = responseParserFactory.CreateGetOutputParser(protocol, outputType);
        Assert.Equal(expectedType, parser.GetType());
    }
    
    [Theory]
    [MemberData(nameof(IPX800V2ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800V2ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V3ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800V3ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V4ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800V4ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V5ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800V5ResponseParserFactoryTestCases))]
    public void GivenNotSupportedProtocol_CreateGetOutputParser_ThrowsIPX800NotSupportedCommandException(IPX800Protocol protocol, IResponseParserFactory responseParserFactory)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => responseParserFactory.CreateGetOutputParser(protocol, OutputType.Output));
    }
    
    [Theory]
    [MemberData(nameof(IPX800V2ResponseParserFactoryTestCases.UnsupportedOutputTestCases), MemberType = typeof(IPX800V2ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V3ResponseParserFactoryTestCases.UnsupportedOutputTestCases), MemberType = typeof(IPX800V3ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V4ResponseParserFactoryTestCases.UnsupportedOutputTestCases), MemberType = typeof(IPX800V4ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V5ResponseParserFactoryTestCases.UnsupportedOutputTestCases), MemberType = typeof(IPX800V5ResponseParserFactoryTestCases))]
    public virtual void GivenNotSupportedOutputType_CreateGetOutputParser_ThrowsIPX800NotSupportedCommandException(IPX800Protocol protocol, OutputType outputType, IResponseParserFactory responseParserFactory)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => responseParserFactory.CreateGetOutputParser(protocol, outputType));
    }
    
    #endregion
    
    #region CreateGetOutputsParser
    
    [Theory]
    [MemberData(nameof(IPX800V2ResponseParserFactoryTestCases.SupportedGetOutputsTestCases), MemberType = typeof(IPX800V2ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V3ResponseParserFactoryTestCases.SupportedGetOutputsTestCases), MemberType = typeof(IPX800V3ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V4ResponseParserFactoryTestCases.SupportedGetOutputsTestCases), MemberType = typeof(IPX800V4ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V5ResponseParserFactoryTestCases.SupportedGetOutputsTestCases), MemberType = typeof(IPX800V5ResponseParserFactoryTestCases))]
    public void GetOutputsParser_ReturnsParserCorrespondingToContext(IPX800Protocol protocol, OutputType outputType, Type expectedType, IResponseParserFactory responseParserFactory)
    {
        var parser = responseParserFactory.CreateGetOutputsParser(protocol, outputType);
        Assert.Equal(expectedType, parser.GetType());
    }
    
    [Theory]
    [MemberData(nameof(IPX800V2ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800V2ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V3ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800V3ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V4ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800V4ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V5ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800V5ResponseParserFactoryTestCases))]
    public void GivenNotSupportedProtocol_CreateGetOutputsParser_ThrowsIPX800NotSupportedCommandException(IPX800Protocol protocol, IResponseParserFactory responseParserFactory)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => responseParserFactory.CreateGetOutputsParser(protocol, OutputType.Output));
    }
    
    [Theory]
    [MemberData(nameof(IPX800V2ResponseParserFactoryTestCases.UnsupportedOutputsTestCases), MemberType = typeof(IPX800V2ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V3ResponseParserFactoryTestCases.UnsupportedOutputTestCases), MemberType = typeof(IPX800V3ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V4ResponseParserFactoryTestCases.UnsupportedOutputTestCases), MemberType = typeof(IPX800V4ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V5ResponseParserFactoryTestCases.UnsupportedOutputTestCases), MemberType = typeof(IPX800V5ResponseParserFactoryTestCases))]
    public virtual void GivenNotSupportedInputType_CreateGetOutputsParser_ThrowsIPX800NotSupportedCommandException(IPX800Protocol protocol, OutputType outputType, IResponseParserFactory responseParserFactory)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => responseParserFactory.CreateGetOutputsParser(protocol, outputType));
    }
    
    #endregion
    
    #region CreateSetOutputParser
        
    [Theory]
    [MemberData(nameof(IPX800V2ResponseParserFactoryTestCases.SupportedSetOutputTestCases), MemberType = typeof(IPX800V2ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V3ResponseParserFactoryTestCases.SupportedSetOutputTestCases), MemberType = typeof(IPX800V3ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V4ResponseParserFactoryTestCases.SupportedSetOutputTestCases), MemberType = typeof(IPX800V4ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V5ResponseParserFactoryTestCases.SupportedSetOutputTestCases), MemberType = typeof(IPX800V5ResponseParserFactoryTestCases))]
    public void CreateSetOutputParser_ReturnsParserCorrespondingToContext(IPX800Protocol protocol, Type expectedType, IResponseParserFactory responseParserFactory)
    {
        var parser = responseParserFactory.CreateSetOutputParser(protocol);
        Assert.Equal(expectedType, parser.GetType());
    }
    
    [Theory]
    [MemberData(nameof(IPX800V2ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800V2ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V3ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800V3ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V4ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800V4ResponseParserFactoryTestCases))]
    [MemberData(nameof(IPX800V5ResponseParserFactoryTestCases.UnsupportedProtocolTestCases), MemberType = typeof(IPX800V5ResponseParserFactoryTestCases))]
    public void GivenNotSupportedProtocol_CreateSetOutputParser_ThrowsIPX800NotSupportedCommandException(IPX800Protocol protocol, IResponseParserFactory responseParserFactory)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => responseParserFactory.CreateSetOutputParser(protocol));
    }
    
    #endregion
}