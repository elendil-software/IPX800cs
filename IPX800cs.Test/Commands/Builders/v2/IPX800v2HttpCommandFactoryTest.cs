using System.Collections.Generic;
using IPX800cs.Commands.Builders.v2;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v2;

public class IPX800v2HttpCommandFactoryTest
{
    private readonly IPX800v2HttpCommandFactory _commandFactory = new();
    
    #region GetInputCommand
    
    public static IEnumerable<object[]> SupportedGetInputTestCases => new[]
    {
        new object[] { new Input { Number = 2, Type = InputType.DigitalInput}, IPX800TestConst.StatusXml },
        new object[] { new Input { Number = 2, Type = InputType.AnalogInput}, IPX800TestConst.StatusXml },
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
        new object[] { new Input { Number = 2, Type = InputType.VirtualAnalogInput} },
        new object[] { new Input { Number = 2, Type = InputType.VirtualDigitalInput} },
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
    [InlineData(InputType.AnalogInput)]
    [InlineData(InputType.DigitalInput)]
    [InlineData(InputType.VirtualAnalogInput)]
    [InlineData(InputType.VirtualDigitalInput)]
    public void GivenUnsupportedInput_CreateGetInputsCommand_ThrowsException(InputType inputType)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => _commandFactory.CreateGetInputsCommand(inputType));
    }
    
    #endregion

    #region GetOutputCommand
    
    public static IEnumerable<object[]> SupportedGetOutputTestCases => new[]
    {
        new object[] { new Output { Number = 2, Type = OutputType.Output}, IPX800TestConst.StatusXml },
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
        new object[] { new Output { Number = 2, Type = OutputType.VirtualOutput} }
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
    [InlineData(OutputType.Output)]
    [InlineData(OutputType.VirtualOutput)]
    public void GivenUnsupportedOutput_CreateGetOutputsCommand_ThrowsException(OutputType inputType)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => _commandFactory.CreateGetOutputsCommand(inputType));
    }

    #endregion
    
    #region SetOutputCommand
    
    public static IEnumerable<object[]> SupportedSetOutputTestCases => new[]
    {
        new object[] { new Output {Type = OutputType.Output, Number = 2, State = OutputState.Active, IsDelayed = false }, "preset.htm?led2=1" },
        new object[] { new Output {Type = OutputType.Output, Number = 2, State = OutputState.Active, IsDelayed = true }, "preset.htm?RLY2=1" },
        new object[] { new Output {Type = OutputType.Output, Number = 2, State = OutputState.Inactive, IsDelayed = false }, "preset.htm?led2=0" },
        new object[] { new Output {Type = OutputType.Output, Number = 2, State = OutputState.Inactive, IsDelayed = true }, "preset.htm?led2=0" },
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
        new object[] { new Output { Number = 2, Type = OutputType.VirtualOutput} }
    };
    
    [Theory]
    [MemberData(nameof(UnsupportedSetOutputTestCases))]
    public void GivenUnsupportedOutput_CreateSetOutputCommand_ThrowsException(Output output)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => _commandFactory.CreateSetOutputCommand(output));
    }
    
    #endregion
}