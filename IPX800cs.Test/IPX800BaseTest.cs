using IPX800cs.Commands;
using IPX800cs.Commands.Builders;
using IPX800cs.Commands.Senders;
using IPX800cs.IO;
using IPX800cs.Parsers;
using Moq;
using Xunit;

namespace IPX800cs.Test;

public class IPX800BaseTest
{
    protected readonly Mock<ICommandFactory> _commandFactory = new();
    protected readonly Mock<ICommandSender> _commandSender = new();
    protected readonly Mock<IResponseParserFactory> _responseParserFactory = new();
    protected IIPX800 _ipx800;

    private class IPX800BaseImpl : IPX800Base
    {
        public IPX800BaseImpl(ICommandFactory commandFactory, ICommandSender commandSender, IResponseParserFactory responseParserFactory) : 
            base(IPX800Protocol.Http, commandFactory, commandSender, responseParserFactory)
        {
        }
    }
        
    public IPX800BaseTest()
    {
        SetupMocks();
        _ipx800 = new IPX800BaseImpl(_commandFactory.Object, _commandSender.Object, _responseParserFactory.Object);
    }

    protected void SetupMocks()
    {
        _responseParserFactory.Setup(_ => _.CreateGetInputParser(It.IsAny<IPX800Protocol>(), It.IsAny<InputType>())).Returns(Mock.Of<IGetInputResponseParser>());
        _responseParserFactory.Setup(_ => _.CreateGetInputsParser(It.IsAny<IPX800Protocol>(), It.IsAny<InputType>())).Returns(Mock.Of<IGetInputsResponseParser>());
        _responseParserFactory.Setup(_ => _.CreateGetAnalogInputParser(It.IsAny<IPX800Protocol>(), It.IsAny<AnalogInputType>())).Returns(Mock.Of<IGetAnalogInputResponseParser>());
        _responseParserFactory.Setup(_ => _.CreateGetAnalogInputsParser(It.IsAny<IPX800Protocol>(), It.IsAny<AnalogInputType>())).Returns(Mock.Of<IAnalogInputsResponseParser>());
        _responseParserFactory.Setup(_ => _.CreateGetOutputParser(It.IsAny<IPX800Protocol>(), It.IsAny<OutputType>())).Returns(Mock.Of<IGetOutputResponseParser>());
        _responseParserFactory.Setup(_ => _.CreateGetOutputsParser(It.IsAny<IPX800Protocol>(), It.IsAny<OutputType>())).Returns(Mock.Of<IGetOutputsResponseParser>());
        _responseParserFactory.Setup(_ => _.CreateSetOutputParser(It.IsAny<IPX800Protocol>())).Returns(Mock.Of<ISetOutputResponseParser>());
    }

    [Fact]
    public virtual void GetInputTest()
    {
        //Arrange
        var input = new Input { Type = InputType.DigitalInput, Number = 1 };
            
        //Act
        _ipx800.GetInput(input);
            
        //Assert
        _commandFactory.Verify(_ => _.CreateGetInputCommand(input), Times.Once);
        _commandSender.Verify(_ => _.ExecuteCommand(It.IsAny<Command>()), Times.Once);
        _responseParserFactory.Verify(_ => _.CreateGetInputParser(It.IsAny<IPX800Protocol>(), It.IsAny<InputType>()), Times.Once);
    }

    [Fact]
    public virtual void GetInputsTest()
    {
        //Arrange
        var input = InputType.DigitalInput;
            
        //Act
        _ipx800.GetInputs(input);
            
        //Assert
        _commandFactory.Verify(_ => _.CreateGetInputsCommand(input), Times.Once);
        _commandSender.Verify(_ => _.ExecuteCommand(It.IsAny<Command>()), Times.Once);
        _responseParserFactory.Verify(_ => _.CreateGetInputsParser(It.IsAny<IPX800Protocol>(), It.IsAny<InputType>()), Times.Once);
    }

    [Fact]
    public virtual void GetAnalogInputTest()
    {
        //Arrange
        var analogInput = new AnalogInput { Type = AnalogInputType.AnalogInput, Number = 1 };
            
        //Act
        _ipx800.GetAnalogInput(analogInput);
            
        //Assert
        _commandFactory.Verify(_ => _.CreateGetAnalogInputCommand(analogInput), Times.Once);
        _commandSender.Verify(_ => _.ExecuteCommand(It.IsAny<Command>()), Times.Once);
        _responseParserFactory.Verify(_ => _.CreateGetAnalogInputParser(It.IsAny<IPX800Protocol>(), It.IsAny<AnalogInputType>()), Times.Once);
    }
        
    [Fact]
    public virtual void GetAnalogInputsTest()
    {
        //Arrange
        var analogInputType = AnalogInputType.AnalogInput;
            
        //Act
        _ipx800.GetAnalogInputs(analogInputType);
            
        //Assert
        _commandFactory.Verify(_ => _.CreateGetAnalogInputsCommand(analogInputType), Times.Once);
        _commandSender.Verify(_ => _.ExecuteCommand(It.IsAny<Command>()), Times.Once);
        _responseParserFactory.Verify(_ => _.CreateGetAnalogInputsParser(It.IsAny<IPX800Protocol>(), It.IsAny<AnalogInputType>()), Times.Once);
    }

    [Fact]
    public virtual void GetOutputTest()
    {
        //Arrange
        var output = new Output { Type = OutputType.Output, Number = 1 };
            
        //Act
        _ipx800.GetOutput(output);
            
        //Assert
        _commandFactory.Verify(_ => _.CreateGetOutputCommand(output), Times.Once);
        _commandSender.Verify(_ => _.ExecuteCommand(It.IsAny<Command>()), Times.Once);
        _responseParserFactory.Verify(_ => _.CreateGetOutputParser(It.IsAny<IPX800Protocol>(), It.IsAny<OutputType>()), Times.Once);
    }
        
    [Fact]
    public virtual void GetOutputsTest()
    {
        //Arrange
        var input = OutputType.Output;
            
        //Act
        _ipx800.GetOutputs(input);
            
        //Assert
        _commandFactory.Verify(_ => _.CreateGetOutputsCommand(input), Times.Once);
        _commandSender.Verify(_ => _.ExecuteCommand(It.IsAny<Command>()), Times.Once);
        _responseParserFactory.Verify(_ => _.CreateGetOutputsParser(It.IsAny<IPX800Protocol>(), It.IsAny<OutputType>()), Times.Once);
    }

    [Fact]
    public virtual void SetOutputTest()
    {
        //Arrange
        var output = new Output { Type = OutputType.Output, Number = 1 };
            
        //Act
        _ipx800.SetOutput(output);
            
        //Assert
        _commandFactory.Verify(_ => _.CreateSetOutputCommand(output), Times.Once);
        _commandSender.Verify(_ => _.ExecuteCommand(It.IsAny<Command>()), Times.Once);
        _responseParserFactory.Verify(_ => _.CreateSetOutputParser(It.IsAny<IPX800Protocol>()), Times.Once);
    }
}