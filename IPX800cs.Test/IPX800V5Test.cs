using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using IPX800cs.Commands;
using IPX800cs.Commands.Builders.v5;
using IPX800cs.Commands.Senders;
using IPX800cs.IO;
using IPX800cs.Parsers;
using IPX800cs.Parsers.v5;
using IPX800cs.Test.Parsers.v5;
using Moq;
using Xunit;

namespace IPX800cs.Test;

public class IPX800V5Test
{
    private readonly Mock<IIPX800V5CommandFactory> _ipx800V5CommandFactory = new();
    private readonly Mock<ICommandSender> _commandSender = new();
    private readonly Mock<IIPX800V5ResponseParserFactory> _ipx800V5ResponseParserFactory = new();
    private readonly Mock<IGetTimersResponseParser> _getTimersResponseParser = new();
    private readonly IIPX800 _ipx800;
    
    public IPX800V5Test()
    {
       _ipx800V5ResponseParserFactory.Setup(_ => _.CreateGetOutputParser(It.IsAny<IPX800Protocol>(), It.IsAny<OutputType>())).Returns(Mock.Of<IGetOutputResponseParser>());
       _ipx800V5ResponseParserFactory.Setup(_ => _.CreateGetOutputsParser(It.IsAny<IPX800Protocol>(), It.IsAny<OutputType>())).Returns(Mock.Of<IGetOutputsResponseParser>());
       _ipx800V5ResponseParserFactory.Setup(_ => _.CreateGetTimersParser()).Returns(_getTimersResponseParser.Object);
       _ipx800 = new IPX800V5(IPX800Protocol.Http, _ipx800V5CommandFactory.Object, _commandSender.Object, _ipx800V5ResponseParserFactory.Object);
    }
    
    [Theory]
    [InlineData(OutputType.Output)]
    [InlineData(OutputType.OpenCollectorOutput)]
    public virtual void GetOutputsTest(OutputType outputType)
    {
        //Act
        _ipx800.GetOutputs(outputType);
            
        //Assert
        _ipx800V5CommandFactory.Verify(_ => _.CreateGetOutputsCommand(outputType), Times.Once);
        _commandSender.Verify(_ => _.ExecuteCommand(It.IsAny<Command>()), Times.Once);
        _ipx800V5ResponseParserFactory.Verify(_ => _.CreateGetOutputsParser(It.IsAny<IPX800Protocol>(), It.IsAny<OutputType>()), Times.Once);
    }
    
    [Theory]
    [InlineData(OutputType.DelayedOutput)]
    [InlineData(OutputType.DelayedOpenCollectorOutput)]
    public virtual void GetOutputsWithDelayedOutputAndNoTimerTest(OutputType outputType)
    {
        //Arrange
        _getTimersResponseParser.Setup(_ => _.ParseResponse(It.IsAny<string>())).Returns(new List<TimerResponse>());
            
        //Act
        var result = _ipx800.GetOutputs(outputType);
            
        //Assert
        Assert.NotNull(result);
        Assert.Empty(result);
        
        _ipx800V5CommandFactory.Verify(_ => _.CreateGetOutputsCommand(outputType), Times.Once);
        _ipx800V5CommandFactory.Verify(_ => _.CreateGetTimersCommand(), Times.Once);
        _commandSender.Verify(_ => _.ExecuteCommand(It.IsAny<Command>()), Times.Exactly(2));
        _ipx800V5ResponseParserFactory.Verify(_ => _.CreateGetOutputsParser(It.IsAny<IPX800Protocol>(), It.IsAny<OutputType>()), Times.Once);
        _ipx800V5ResponseParserFactory.Verify(_ => _.CreateGetTimersParser(), Times.Once);
    }
    
    [Theory]
    [InlineData(OutputType.DelayedOutput, new[] { 65576, 65581 })]
    [InlineData(OutputType.DelayedOpenCollectorOutput, new[] { 65596 })]
    public virtual void GetOutputsWithDelayedOutputAndTimerTest(OutputType outputType, int[] outputs)
    {
        //Arrange
        var ipx800 = new IPX800V5(IPX800Protocol.Http, _ipx800V5CommandFactory.Object, _commandSender.Object, new IPX800V5ResponseParserFactory());

        _commandSender.SetupSequence(_ => _.ExecuteCommand(It.IsAny<Command>())).Returns(IPX800V5Response.IOJson).Returns(IPX800V5Response.Timers);
        
        //Act
        List<OutputResponse> result = ipx800.GetOutputs(outputType).ToList();
            
        //Assert
        Assert.NotNull(result);
        Assert.Equal(outputs.Length, result.Count);
        for(int i=0; i < outputs.Length; i++)
        {
            Assert.Equal(outputs[i], result[i].Number);
        }
    }
    
    [Theory]
    [InlineData(OutputType.Output, 65576)]
    [InlineData(OutputType.OpenCollectorOutput, 65576)]
    public virtual void GetOutputTest(OutputType outputType, int number)
    {
        //Arrange
        var output = new Output
        {
            Type = outputType,
            Number = number
        };

        //Act
        _ipx800.GetOutput(output);
            
        //Assert
        _ipx800V5CommandFactory.Verify(_ => _.CreateGetOutputCommand(output), Times.Once);
        _commandSender.Verify(_ => _.ExecuteCommand(It.IsAny<Command>()), Times.Once);
        _ipx800V5ResponseParserFactory.Verify(_ => _.CreateGetOutputParser(It.IsAny<IPX800Protocol>(), outputType), Times.Once);
    }
    
    [Theory]
    [InlineData(OutputType.DelayedOutput, 65576, OutputState.Active)]
    [InlineData(OutputType.DelayedOpenCollectorOutput, 65596, OutputState.Active)]
    public virtual void GetOutputWithDelayedOutputAndTimerTest(OutputType outputType, int number, OutputState expectedState)
    {
        //Arrange
        var ipx800 = new IPX800V5(IPX800Protocol.Http, _ipx800V5CommandFactory.Object, _commandSender.Object, new IPX800V5ResponseParserFactory());
        var output = new Output
        {
            Type = outputType,
            Number = number
        };
        _getTimersResponseParser.Setup(_ => _.ParseResponse(It.IsAny<string>())).Returns(new List<TimerResponse>());
        _commandSender.Setup(_ => _.ExecuteCommand(It.IsAny<Command>())).Returns(IPX800V5Response.IOJson);
            
        //Act
        OutputState state = ipx800.GetOutput(output);
            
        //Assert
        Assert.Equal(expectedState, state);
    }
}