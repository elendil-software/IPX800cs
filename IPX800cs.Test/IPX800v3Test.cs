using IPX800cs.Exceptions;
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
        
    public override void GetAnalogInputsTest()
    {
        //Arrange
        _ipx800 = new IPX800V3(IPX800Protocol.Http, _commandFactory.Object, _commandSender.Object, _responseParserFactory.Object);
        var analogInputType = AnalogInputType.AnalogInput;
            
        //Act
        _ipx800.GetAnalogInputs(analogInputType);
            
        //Assert
        _commandFactory.Verify(_ => _.CreateGetAnalogInputsCommand(It.IsAny<AnalogInputType>()), Times.Once());
        _commandSender.Verify(_ => _.ExecuteCommand(It.IsAny<string>()), Times.Once);
        _responseParserFactory.Verify(_ => _.GetAnalogInputsParser(It.IsAny<IPX800Protocol>(), It.IsAny<AnalogInputType>()), Times.Once);
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
        _commandSender.Verify(_ => _.ExecuteCommand(It.IsAny<string>()), Times.Exactly(16));
        _responseParserFactory.Verify(_ => _.GetAnalogInputParser(IPX800Protocol.M2M, It.IsAny<AnalogInputType>()), Times.Once);
    }
}