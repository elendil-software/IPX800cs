using IPX800cs.Commands;
using IPX800cs.IO;
using Moq;
using Xunit;

namespace IPX800cs.Test;

public class IPX800v3Test : IPX800BaseTest
{
    public IPX800v3Test()
    {
        SetupMocks();
    }
        
    [Fact]
    public override void GetAnalogInputsTest()
    {
        //Arrange
        _ipx800 = new IPX800V3(IPX800Protocol.Http, _commandFactory.Object, _commandSender.Object, _responseParserFactory.Object);
        var analogInputType = AnalogInputType.AnalogInput;
            
        //Act
        _ipx800.GetAnalogInputs(analogInputType);
            
        //Assert
        _commandFactory.Verify(_ => _.CreateGetAnalogInputsCommand(It.IsAny<AnalogInputType>()), Times.Once());
        _commandSender.Verify(_ => _.ExecuteCommand(It.IsAny<Command>()), Times.Once);
        _responseParserFactory.Verify(_ => _.CreateGetAnalogInputsParser(It.IsAny<IPX800Protocol>(), It.IsAny<AnalogInputType>()), Times.Once);
    }
    
    [Fact]
    public void GetM2MAnalogInputsTest()
    {
        //Arrange
        _ipx800 = new IPX800V3(IPX800Protocol.M2M, _commandFactory.Object, _commandSender.Object, _responseParserFactory.Object);
        var analogInputType = AnalogInputType.AnalogInput;
            
        //Act
        _ipx800.GetAnalogInputs(analogInputType);
            
        //Assert
        _commandFactory.Verify(_ => _.CreateGetAnalogInputCommand(It.IsAny<AnalogInput>()), Times.Exactly(16));
        _commandSender.Verify(_ => _.ExecuteCommand(It.IsAny<Command>()), Times.Exactly(16));
        _responseParserFactory.Verify(_ => _.CreateGetAnalogInputParser(IPX800Protocol.M2M, It.IsAny<AnalogInputType>()), Times.Once);
    }
}