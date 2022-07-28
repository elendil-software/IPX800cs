using IPX800cs.Commands;
using IPX800cs.IO;
using Moq;
using Xunit;

namespace IPX800cs.Test;

public class IPX800V2Test : IPX800BaseTest
{
    public IPX800V2Test()
    {
        SetupMocks();
        _ipx800 = new IPX800V2(IPX800Protocol.Http, _commandFactory.Object, _commandSender.Object, _responseParserFactory.Object);
    }

    [Fact]
    public override void GetInputsTest()
    {
        //Arrange
        _ipx800 = new IPX800V2(IPX800Protocol.Http, _commandFactory.Object, _commandSender.Object, _responseParserFactory.Object);
        var inputType = InputType.DigitalInput;
            
        //Act
        _ipx800.GetInputs(inputType);
            
        //Assert
        _commandFactory.Verify(_ => _.CreateGetInputsCommand(It.IsAny<InputType>()), Times.Once());
        _commandSender.Verify(_ => _.ExecuteCommand(It.IsAny<Command>()), Times.Once);
        _responseParserFactory.Verify(_ => _.CreateGetInputsParser(It.IsAny<IPX800Protocol>(), It.IsAny<InputType>()), Times.Once);
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
        _commandSender.Verify(_ => _.ExecuteCommand(It.IsAny<Command>()), Times.Exactly(4));
        _responseParserFactory.Verify(_ => _.CreateGetInputParser(IPX800Protocol.M2M, It.IsAny<InputType>()), Times.Once);
    }

    [Fact]
    public override void GetAnalogInputsTest()
    {
        //Arrange
        _ipx800 = new IPX800V2(IPX800Protocol.Http, _commandFactory.Object, _commandSender.Object, _responseParserFactory.Object);
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
        _ipx800 = new IPX800V2(IPX800Protocol.M2M, _commandFactory.Object, _commandSender.Object, _responseParserFactory.Object);
        var analogInputType = AnalogInputType.AnalogInput;
            
        //Act
        _ipx800.GetAnalogInputs(analogInputType);
            
        //Assert
        _commandFactory.Verify(_ => _.CreateGetAnalogInputCommand(It.IsAny<AnalogInput>()), Times.Exactly(2));
        _commandSender.Verify(_ => _.ExecuteCommand(It.IsAny<Command>()), Times.Exactly(2));
        _responseParserFactory.Verify(_ => _.CreateGetAnalogInputParser(IPX800Protocol.M2M, It.IsAny<AnalogInputType>()), Times.Once);
    }

    [Fact]
    public override void GetOutputsTest()
    {
        //Arrange
        _ipx800 = new IPX800V2(IPX800Protocol.Http, _commandFactory.Object, _commandSender.Object, _responseParserFactory.Object);
        var inputType = OutputType.Output;
            
        //Act
        _ipx800.GetOutputs(inputType);
            
        //Assert
        _commandFactory.Verify(_ => _.CreateGetOutputsCommand(It.IsAny<OutputType>()), Times.Once());
        _commandSender.Verify(_ => _.ExecuteCommand(It.IsAny<Command>()), Times.Once);
        _responseParserFactory.Verify(_ => _.CreateGetOutputsParser(It.IsAny<IPX800Protocol>(), It.IsAny<OutputType>()), Times.Once);
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
        _commandSender.Verify(_ => _.ExecuteCommand(It.IsAny<Command>()), Times.Exactly(8));
        _responseParserFactory.Verify(_ => _.CreateGetOutputParser(IPX800Protocol.M2M, It.IsAny<OutputType>()), Times.Once);
    }
}