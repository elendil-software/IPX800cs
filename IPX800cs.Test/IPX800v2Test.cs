using IPX800cs.Exceptions;
using IPX800cs.IO;
using Moq;
using Xunit;

namespace IPX800cs.Test;

public class IPX800v2Test : IPX800BaseTest
{
    public IPX800v2Test()
    {
        SetupMocks();
        _ipx800 = new IPX800V2(IPX800Protocol.Http, _commandFactory.Object, _commandSender.Object, _responseParserFactory.Object);
    }

    public override void GetInputsTest()
    {
        //Arrange
        _ipx800 = new IPX800V2(IPX800Protocol.Http, _commandFactory.Object, _commandSender.Object, _responseParserFactory.Object);
        var inputType = InputType.DigitalInput;
            
        //Act
        _ipx800.GetInputs(inputType);
            
        //Assert
        _commandFactory.Verify(_ => _.CreateGetInputsCommand(It.IsAny<InputType>()), Times.Once());
        _commandSender.Verify(_ => _.ExecuteCommand(It.IsAny<string>()), Times.Once);
        _responseParserFactory.Verify(_ => _.GetInputsParser(It.IsAny<IPX800Protocol>(), It.IsAny<InputType>()), Times.Once);
    }
    
    [Fact]
    public void GetM2MInputsTest()
    {
        //Arrange
        _ipx800 = new IPX800V2(IPX800Protocol.M2M, _commandFactory.Object, _commandSender.Object, _responseParserFactory.Object);
        var inputType = InputType.DigitalInput;
            
        //Act
        _ipx800.GetInputs(inputType);
            
        //Assert
        _commandFactory.Verify(_ => _.CreateGetInputCommand(It.IsAny<Input>()), Times.Exactly(4));
        _commandSender.Verify(_ => _.ExecuteCommand(It.IsAny<string>()), Times.Exactly(4));
        _responseParserFactory.Verify(_ => _.GetInputParser(IPX800Protocol.M2M, It.IsAny<InputType>()), Times.Once);
    }

    public override void GetAnalogInputsTest()
    {
        //Arrange
        _ipx800 = new IPX800V2(IPX800Protocol.Http, _commandFactory.Object, _commandSender.Object, _responseParserFactory.Object);
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
        _ipx800 = new IPX800V2(IPX800Protocol.M2M, _commandFactory.Object, _commandSender.Object, _responseParserFactory.Object);
        var analogInputType = AnalogInputType.AnalogInput;
            
        //Act
        _ipx800.GetAnalogInputs(analogInputType);
            
        //Assert
        _commandFactory.Verify(_ => _.CreateGetAnalogInputCommand(It.IsAny<AnalogInput>()), Times.Exactly(2));
        _commandSender.Verify(_ => _.ExecuteCommand(It.IsAny<string>()), Times.Exactly(2));
        _responseParserFactory.Verify(_ => _.GetAnalogInputParser(IPX800Protocol.M2M, It.IsAny<AnalogInputType>()), Times.Once);
    }

    public override void GetOutputsTest()
    {
        //Arrange
        _ipx800 = new IPX800V2(IPX800Protocol.Http, _commandFactory.Object, _commandSender.Object, _responseParserFactory.Object);
        var inputType = OutputType.Output;
            
        //Act
        _ipx800.GetOutputs(inputType);
            
        //Assert
        _commandFactory.Verify(_ => _.CreateGetOutputsCommand(It.IsAny<OutputType>()), Times.Once());
        _commandSender.Verify(_ => _.ExecuteCommand(It.IsAny<string>()), Times.Once);
        _responseParserFactory.Verify(_ => _.GetOutputsParser(It.IsAny<IPX800Protocol>(), It.IsAny<OutputType>()), Times.Once);
    }
    
    [Fact]
    public void GetM2MOutputsTest()
    {
        //Arrange
        _ipx800 = new IPX800V2(IPX800Protocol.M2M, _commandFactory.Object, _commandSender.Object, _responseParserFactory.Object);
        var inputType = OutputType.Output;
            
        //Act
        _ipx800.GetOutputs(inputType);
            
        //Assert
        _commandFactory.Verify(_ => _.CreateGetOutputCommand(It.IsAny<Output>()), Times.Exactly(8));
        _commandSender.Verify(_ => _.ExecuteCommand(It.IsAny<string>()), Times.Exactly(8));
        _responseParserFactory.Verify(_ => _.GetOutputParser(IPX800Protocol.M2M, It.IsAny<OutputType>()), Times.Once);
    }
}