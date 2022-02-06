using System.Collections.Generic;
using System.Linq;
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
       _ipx800V5ResponseParserFactory.Setup(_ => _.CreateGetOutputsParser(It.IsAny<IPX800Protocol>(), It.IsAny<OutputType>())).Returns(Mock.Of<IGetOutputsResponseParser>());
       _ipx800V5ResponseParserFactory.Setup(_ => _.CreateGetTimersParser()).Returns(_getTimersResponseParser.Object);
       _ipx800 = new IPX800V5(IPX800Protocol.Http, _ipx800V5CommandFactory.Object, _commandSender.Object, _ipx800V5ResponseParserFactory.Object);
    }
    
    [Fact]
    public virtual void GetOutputsTest()
    {
        //Arrange
        var outputType = OutputType.Output;
            
        //Act
        _ipx800.GetOutputs(outputType);
            
        //Assert
        _ipx800V5CommandFactory.Verify(_ => _.CreateGetOutputsCommand(outputType), Times.Once);
        _commandSender.Verify(_ => _.ExecuteCommand(It.IsAny<Command>()), Times.Once);
        _ipx800V5ResponseParserFactory.Verify(_ => _.CreateGetOutputsParser(It.IsAny<IPX800Protocol>(), It.IsAny<OutputType>()), Times.Once);
    }
    
    [Fact]
    public virtual void GetOutputsWithDelayedOutputAndNoTimerTest()
    {
        //Arrange
        var outputType = OutputType.DelayedOutput;
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
    
    [Fact]
    public virtual void GetOutputsWithDelayedOutputAndTimerTest()
    {
        //Arrange
        var outputType = OutputType.DelayedOutput;
        var ipx800 = new IPX800V5(IPX800Protocol.Http, _ipx800V5CommandFactory.Object, _commandSender.Object, new IPX800V5ResponseParserFactory());

        _commandSender.SetupSequence(_ => _.ExecuteCommand(It.IsAny<Command>())).Returns(IPX800V5Response.IOJson).Returns(IPX800V5Response.Timers);
        
        //Act
        List<OutputResponse> result = ipx800.GetOutputs(outputType).ToList();
            
        //Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Equal(65576, result[0].Number);
        Assert.Equal(65581, result[1].Number);
    }
}