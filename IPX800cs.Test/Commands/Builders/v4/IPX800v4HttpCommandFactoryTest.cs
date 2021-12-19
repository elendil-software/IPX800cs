using System.Collections.Generic;
using IPX800cs.Commands.Builders.v4;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v4;

public class IPX800v4HttpCommandFactoryTest
{
    private readonly IPX800v4HttpCommandFactory _commandFactory = new();
    
    #region GetInputCommand
    
    public static IEnumerable<object[]> SupportedGetInputTestCases => new[]
    {
        new object[] { new Input { Number = 2, Type = InputType.DigitalInput}, "/api/xdevices.json?Get=D" },
        new object[] { new Input { Number = 2, Type = InputType.AnalogInput}, "/api/xdevices.json?Get=A" },
        new object[] { new Input { Number = 2, Type = InputType.VirtualAnalogInput}, "/api/xdevices.json?Get=VA" },
        new object[] { new Input { Number = 2, Type = InputType.VirtualDigitalInput}, "/api/xdevices.json?Get=VI" },
    };
    
    [Theory]
    [MemberData(nameof(SupportedGetInputTestCases))]
    public void GivenSupportedInput_CreateGetInputCommand_ReturnsMatchingCommand(Input input, string expectedCommand)
    {
        var command = _commandFactory.CreateGetInputCommand(input);
        Assert.Equal(expectedCommand, command);
    }
    
    public static IEnumerable<object[]> UnsupportedGetInputTestCases => new[]
    {
        new object[] { new Input { Number = 2, Type = (InputType)1000} }
    };
    
    [Theory]
    [MemberData(nameof(UnsupportedGetInputTestCases))]
    public void GivenUnsupportedInput_CreateGetInputCommand_ThrowsException(Input input)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => _commandFactory.CreateGetInputCommand(input));
    }
    
    #endregion
    
    #region GetInputsCommand
    
    [Theory]
    [InlineData(InputType.AnalogInput, "/api/xdevices.json?Get=A")]
    [InlineData(InputType.DigitalInput, "/api/xdevices.json?Get=D")]
    [InlineData(InputType.VirtualAnalogInput, "/api/xdevices.json?Get=VA")]
    [InlineData(InputType.VirtualDigitalInput, "/api/xdevices.json?Get=VI")]
    public void GivenSupportedInput_CreateGetInputsCommand_ReturnsMatchingCommand(InputType inputType, string expectedCommand)
    {
        var command = _commandFactory.CreateGetInputsCommand(inputType);
        Assert.Equal(expectedCommand, command);
    }
    
    [Theory]
    [InlineData((InputType)1000)]
    public void GivenUnsupportedInput_CreateGetInputsCommand_ThrowsException(InputType inputType)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => _commandFactory.CreateGetInputsCommand(inputType));
    }
    
    #endregion

    #region GetOutputCommand
    
    public static IEnumerable<object[]> SupportedGetOutputTestCases => new[]
    {
        new object[] { new Output { Number = 2, Type = OutputType.Output}, "/api/xdevices.json?Get=R" },
        new object[] { new Output { Number = 2, Type = OutputType.VirtualOutput}, "/api/xdevices.json?Get=VO" },
    };
    
    [Theory]
    [MemberData(nameof(SupportedGetOutputTestCases))]
    public void GivenSupportedOutput_CreateGetOutputCommand_ReturnsMatchingCommand(Output output, string expectedCommand)
    {
        var command = _commandFactory.CreateGetOutputCommand(output);
        Assert.Equal(expectedCommand, command);
    }
    
    public static IEnumerable<object[]> UnsupportedGetOutputTestCases => new[]
    {
        new object[] { new Output { Number = 2, Type = (OutputType)1000} }
    };
    
    [Theory]
    [MemberData(nameof(UnsupportedGetOutputTestCases))]
    public void GivenUnsupportedOutput_CreateGetOutputCommand_ThrowsException(Output output)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => _commandFactory.CreateGetOutputCommand(output));
    }
    
    #endregion
    
    #region GetOutputsCommand
    
    [Theory]
    [InlineData(OutputType.Output, "/api/xdevices.json?Get=R")]
    [InlineData(OutputType.VirtualOutput, "/api/xdevices.json?Get=VO")]
    public void GivenSupportedOutput_CreateGetOutputsCommand_ReturnsMatchingCommand(OutputType inputType, string expectedCommand)
    {
        var command = _commandFactory.CreateGetOutputsCommand(inputType);
        Assert.Equal(expectedCommand, command);
    }
    
    [Theory]
    [InlineData((OutputType)1000)]
    public void GivenUnsupportedOutput_CreateGetOutputsCommand_ThrowsException(OutputType inputType)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => _commandFactory.CreateGetOutputsCommand(inputType));
    }
    
    #endregion
    
    #region SetOutputCommand
    
    public static IEnumerable<object[]> SupportedSetOutputTestCases => new[]
    {
        new object[] { new Output {Type = OutputType.Output, Number = 2, State = OutputState.Active, IsDelayed = false }, "/api/xdevices.json?SetR=02" },
        new object[] { new Output {Type = OutputType.Output, Number = 2, State = OutputState.Active, IsDelayed = true }, "/api/xdevices.json?SetR=02" },
        new object[] { new Output {Type = OutputType.Output, Number = 2, State = OutputState.Inactive, IsDelayed = false }, "/api/xdevices.json?ClearR=02" },
        new object[] { new Output {Type = OutputType.Output, Number = 2, State = OutputState.Inactive, IsDelayed = true }, "/api/xdevices.json?ClearR=02" },
        new object[] { new Output {Type = OutputType.VirtualOutput, Number = 2, State = OutputState.Active, IsDelayed = false }, "/api/xdevices.json?SetVO=02" },
        new object[] { new Output {Type = OutputType.VirtualOutput, Number = 2, State = OutputState.Active, IsDelayed = true }, "/api/xdevices.json?SetVO=02" },
        new object[] { new Output {Type = OutputType.VirtualOutput, Number = 2, State = OutputState.Inactive, IsDelayed = false }, "/api/xdevices.json?ClearVO=02" },
        new object[] { new Output {Type = OutputType.VirtualOutput, Number = 2, State = OutputState.Inactive, IsDelayed = true }, "/api/xdevices.json?ClearVO=02" }
    };
    
    [Theory]
    [MemberData(nameof(SupportedSetOutputTestCases))]
    public void GivenSupportedOutput_CreateSetOutputCommand_ReturnsMatchingCommand(Output output, string expectedCommand)
    {
        var command = _commandFactory.CreateSetOutputCommand(output);
        Assert.Equal(expectedCommand, command);
    }
    
    public static IEnumerable<object[]> UnsupportedSetOutputTestCases => new[]
    {
        new object[] { new Output { Number = 2, Type = (OutputType)1000} }
    };
    
    [Theory]
    [MemberData(nameof(UnsupportedSetOutputTestCases))]
    public void GivenUnsupportedOutput_CreateSetOutputCommand_ThrowsException(Output output)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => _commandFactory.CreateSetOutputCommand(output));
    }
    
    #endregion
}