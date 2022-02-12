using System.Diagnostics.CodeAnalysis;
using IPX800cs.Commands;
using IPX800cs.Commands.Builders;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using Xunit;

namespace IPX800cs.Test.Commands.Builders;

public class CommandFactoryTest
{
    [SuppressMessage("Usage", "xUnit1013:Public method should be marked as test")]
    public static void AssertCommandAreEqual(Command expected, Command actual)
    {
        Assert.Equal(expected.Body, actual.Body);
        Assert.Equal(expected.Method, actual.Method);
        Assert.Equal(expected.ContentType, actual.ContentType);
        Assert.Equal(expected.QueryString, actual.QueryString);
    }
    
    #region GetInputCommand
    
    [Theory]
    [MemberData(nameof(IPX800V2HttpCommandFactoryTestCases.SupportedGetInputTestCases), MemberType = typeof(IPX800V2HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800V2M2MCommandFactoryTestCases.SupportedGetInputTestCases), MemberType = typeof(IPX800V2M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800V3HttpCommandFactoryTestCases.SupportedGetInputTestCases), MemberType = typeof(IPX800V3HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v3M2MCommandFactoryTestCases.SupportedGetInputTestCases), MemberType = typeof(IPX800v3M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4HttpCommandFactoryTestCases.SupportedGetInputTestCases), MemberType = typeof(IPX800v4HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4M2MCommandFactoryTestCases.SupportedGetInputTestCases), MemberType = typeof(IPX800v4M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800V5HttpCommandFactoryTestCases.SupportedGetInputTestCases), MemberType = typeof(IPX800V5HttpCommandFactoryTestCases))]
    public void GivenSupportedInput_CreateGetInputCommand_ReturnsMatchingCommand(Input input, Command expectedCommand, ICommandFactory commandFactory)
    {
        var command = commandFactory.CreateGetInputCommand(input);
        AssertCommandAreEqual(expectedCommand, command);
    }
    
    [Theory]
    [MemberData(nameof(IPX800V2HttpCommandFactoryTestCases.UnsupportedGetInputTestCases), MemberType = typeof(IPX800V2HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800V2M2MCommandFactoryTestCases.UnsupportedGetInputTestCases), MemberType = typeof(IPX800V2M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800V3HttpCommandFactoryTestCases.UnsupportedGetInputTestCases), MemberType = typeof(IPX800V3HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v3M2MCommandFactoryTestCases.UnsupportedGetInputTestCases), MemberType = typeof(IPX800v3M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4HttpCommandFactoryTestCases.UnsupportedGetInputTestCases), MemberType = typeof(IPX800v4HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4M2MCommandFactoryTestCases.UnsupportedGetInputTestCases), MemberType = typeof(IPX800v4M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800V5HttpCommandFactoryTestCases.UnsupportedGetInputTestCases), MemberType = typeof(IPX800V5HttpCommandFactoryTestCases))]
    public void GivenUnsupportedInput_CreateGetInputCommand_ThrowsException(Input input, ICommandFactory commandFactory)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => commandFactory.CreateGetInputCommand(input));
    }
    
    #endregion
    
    #region GetInputsCommand
    
    [Theory]
    [MemberData(nameof(IPX800V2HttpCommandFactoryTestCases.SupportedGetInputsTestCases), MemberType = typeof(IPX800V2HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800V3HttpCommandFactoryTestCases.SupportedGetInputsTestCases), MemberType = typeof(IPX800V3HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v3M2MCommandFactoryTestCases.SupportedGetInputsTestCases), MemberType = typeof(IPX800v3M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4HttpCommandFactoryTestCases.SupportedGetInputsTestCases), MemberType = typeof(IPX800v4HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4M2MCommandFactoryTestCases.SupportedGetInputsTestCases), MemberType = typeof(IPX800v4M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800V5HttpCommandFactoryTestCases.SupportedGetInputsTestCases), MemberType = typeof(IPX800V5HttpCommandFactoryTestCases))]
    public void GivenSupportedInput_CreateGetInputsCommand_ReturnsMatchingCommand(InputType inputType, Command expectedCommand, ICommandFactory commandFactory)
    {
        var command = commandFactory.CreateGetInputsCommand(inputType);
        AssertCommandAreEqual(expectedCommand, command);
    }
    
    [Theory]
    [MemberData(nameof(IPX800V2HttpCommandFactoryTestCases.UnsupportedGetInputsTestCases), MemberType = typeof(IPX800V2HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800V2M2MCommandFactoryTestCases.UnsupportedGetInputsTestCases), MemberType = typeof(IPX800V2M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800V3HttpCommandFactoryTestCases.UnsupportedGetInputsTestCases), MemberType = typeof(IPX800V3HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v3M2MCommandFactoryTestCases.UnsupportedGetInputsTestCases), MemberType = typeof(IPX800v3M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4HttpCommandFactoryTestCases.UnsupportedGetInputsTestCases), MemberType = typeof(IPX800v4HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4M2MCommandFactoryTestCases.UnsupportedGetInputsTestCases), MemberType = typeof(IPX800v4M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800V5HttpCommandFactoryTestCases.UnsupportedGetInputsTestCases), MemberType = typeof(IPX800V5HttpCommandFactoryTestCases))]
    public void GivenUnsupportedInput_CreateGetInputsCommand_ThrowsException(InputType inputType, ICommandFactory commandFactory)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => commandFactory.CreateGetInputsCommand(inputType));
    }
    
    #endregion
    
    #region GetAnalogInputCommand
    
    [Theory]
    [MemberData(nameof(IPX800V2HttpCommandFactoryTestCases.SupportedGetAnalogInputTestCases), MemberType = typeof(IPX800V2HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800V2M2MCommandFactoryTestCases.SupportedGetAnalogInputTestCases), MemberType = typeof(IPX800V2M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800V3HttpCommandFactoryTestCases.SupportedGetAnalogInputTestCases), MemberType = typeof(IPX800V3HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v3M2MCommandFactoryTestCases.SupportedGetAnalogInputTestCases), MemberType = typeof(IPX800v3M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4HttpCommandFactoryTestCases.SupportedGetAnalogInputTestCases), MemberType = typeof(IPX800v4HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4M2MCommandFactoryTestCases.SupportedGetAnalogInputTestCases), MemberType = typeof(IPX800v4M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800V5HttpCommandFactoryTestCases.SupportedGetAnalogInputTestCases), MemberType = typeof(IPX800V5HttpCommandFactoryTestCases))]
    public void GivenSupportedAnalogInput_CreateGetAnalogInputCommand_ReturnsMatchingCommand(AnalogInput input, Command expectedCommand, ICommandFactory commandFactory)
    {
        var command = commandFactory.CreateGetAnalogInputCommand(input);
        AssertCommandAreEqual(expectedCommand, command);
    }
    
    [Theory]
    [MemberData(nameof(IPX800V2HttpCommandFactoryTestCases.UnsupportedGetAnalogInputTestCases), MemberType = typeof(IPX800V2HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800V2M2MCommandFactoryTestCases.UnsupportedGetAnalogInputTestCases), MemberType = typeof(IPX800V2M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800V3HttpCommandFactoryTestCases.UnsupportedGetAnalogInputTestCases), MemberType = typeof(IPX800V3HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v3M2MCommandFactoryTestCases.UnsupportedGetAnalogInputTestCases), MemberType = typeof(IPX800v3M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4HttpCommandFactoryTestCases.UnsupportedGetAnalogInputTestCases), MemberType = typeof(IPX800v4HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4M2MCommandFactoryTestCases.UnsupportedGetAnalogInputTestCases), MemberType = typeof(IPX800v4M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800V5HttpCommandFactoryTestCases.UnsupportedGetAnalogInputTestCases), MemberType = typeof(IPX800V5HttpCommandFactoryTestCases))]
    public void GivenUnsupportedAnalogInput_CreateGetAnalogInputCommand_ThrowsException(AnalogInput input, ICommandFactory commandFactory)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => commandFactory.CreateGetAnalogInputCommand(input));
    }
    
    #endregion
    
    #region GetAnalogInputsCommand
    
    [Theory]
    [MemberData(nameof(IPX800V2HttpCommandFactoryTestCases.SupportedGetAnalogInputsTestCases), MemberType = typeof(IPX800V2HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800V3HttpCommandFactoryTestCases.SupportedGetAnalogInputsTestCases), MemberType = typeof(IPX800V3HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4HttpCommandFactoryTestCases.SupportedGetAnalogInputsTestCases), MemberType = typeof(IPX800v4HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4M2MCommandFactoryTestCases.SupportedGetAnalogInputsTestCases), MemberType = typeof(IPX800v4M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800V5HttpCommandFactoryTestCases.SupportedGetAnalogInputsTestCases), MemberType = typeof(IPX800V5HttpCommandFactoryTestCases))]
    public void GivenSupportedAnalogInput_CreateGetAnalogInputsCommand_ReturnsMatchingCommand(AnalogInputType inputType, Command expectedCommand, ICommandFactory commandFactory)
    {
        var command = commandFactory.CreateGetAnalogInputsCommand(inputType);
        AssertCommandAreEqual(expectedCommand, command);
    }
    
    [Theory]
    [MemberData(nameof(IPX800V2HttpCommandFactoryTestCases.UnsupportedGetAnalogInputsTestCases), MemberType = typeof(IPX800V2HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800V2M2MCommandFactoryTestCases.UnsupportedGetAnalogInputsTestCases), MemberType = typeof(IPX800V2M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800V3HttpCommandFactoryTestCases.UnsupportedGetAnalogInputsTestCases), MemberType = typeof(IPX800V3HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v3M2MCommandFactoryTestCases.UnsupportedGetAnalogInputsTestCases), MemberType = typeof(IPX800v3M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4HttpCommandFactoryTestCases.UnsupportedGetAnalogInputsTestCases), MemberType = typeof(IPX800v4HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4M2MCommandFactoryTestCases.UnsupportedGetAnalogInputsTestCases), MemberType = typeof(IPX800v4M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800V5HttpCommandFactoryTestCases.UnsupportedGetAnalogInputsTestCases), MemberType = typeof(IPX800V5HttpCommandFactoryTestCases))]
    public void GivenUnsupportedAnalogInput_CreateGetAnalogInputsCommand_ThrowsException(AnalogInputType inputType, ICommandFactory commandFactory)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => commandFactory.CreateGetAnalogInputsCommand(inputType));
    }
    
    #endregion

    #region GetOutputCommand
    
    [Theory]
    [MemberData(nameof(IPX800V2HttpCommandFactoryTestCases.SupportedGetOutputTestCases), MemberType = typeof(IPX800V2HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800V2M2MCommandFactoryTestCases.SupportedGetOutputTestCases), MemberType = typeof(IPX800V2M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800V3HttpCommandFactoryTestCases.SupportedGetOutputTestCases), MemberType = typeof(IPX800V3HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v3M2MCommandFactoryTestCases.SupportedGetOutputTestCases), MemberType = typeof(IPX800v3M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4HttpCommandFactoryTestCases.SupportedGetOutputTestCases), MemberType = typeof(IPX800v4HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4M2MCommandFactoryTestCases.SupportedGetOutputTestCases), MemberType = typeof(IPX800v4M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800V5HttpCommandFactoryTestCases.SupportedGetOutputTestCases), MemberType = typeof(IPX800V5HttpCommandFactoryTestCases))]
    public void GivenSupportedOutput_CreateGetOutputCommand_ReturnsMatchingCommand(Output output, Command expectedCommand, ICommandFactory commandFactory)
    {
        var command = commandFactory.CreateGetOutputCommand(output);
        AssertCommandAreEqual(expectedCommand, command);
    }

    [Theory]
    [MemberData(nameof(IPX800V2HttpCommandFactoryTestCases.UnsupportedGetOutputTestCases), MemberType = typeof(IPX800V2HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800V2M2MCommandFactoryTestCases.UnsupportedGetOutputTestCases), MemberType = typeof(IPX800V2M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800V3HttpCommandFactoryTestCases.UnsupportedGetOutputTestCases), MemberType = typeof(IPX800V3HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v3M2MCommandFactoryTestCases.UnsupportedGetOutputTestCases), MemberType = typeof(IPX800v3M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4HttpCommandFactoryTestCases.UnsupportedGetOutputTestCases), MemberType = typeof(IPX800v4HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4M2MCommandFactoryTestCases.UnsupportedGetOutputTestCases), MemberType = typeof(IPX800v4M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800V5HttpCommandFactoryTestCases.UnsupportedGetOutputTestCases), MemberType = typeof(IPX800V5HttpCommandFactoryTestCases))]
    public void GivenUnsupportedOutput_CreateGetOutputCommand_ThrowsException(Output output, ICommandFactory commandFactory)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => commandFactory.CreateGetOutputCommand(output));
    }
    
    #endregion
    
    #region GetOutputsCommand
    
    [Theory]
    [MemberData(nameof(IPX800V2HttpCommandFactoryTestCases.SupportedGetOutputsTestCases), MemberType = typeof(IPX800V2HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800V3HttpCommandFactoryTestCases.SupportedGetOutputsTestCases), MemberType = typeof(IPX800V3HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v3M2MCommandFactoryTestCases.SupportedGetOutputsTestCases), MemberType = typeof(IPX800v3M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4HttpCommandFactoryTestCases.SupportedGetOutputsTestCases), MemberType = typeof(IPX800v4HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4M2MCommandFactoryTestCases.SupportedGetOutputsTestCases), MemberType = typeof(IPX800v4M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800V5HttpCommandFactoryTestCases.SupportedGetOutputsTestCases), MemberType = typeof(IPX800V5HttpCommandFactoryTestCases))]
    public void GivenSupportedOutput_CreateGetOutputsCommand_ReturnsMatchingCommand(OutputType inputType, Command expectedCommand, ICommandFactory commandFactory)
    {
        var command = commandFactory.CreateGetOutputsCommand(inputType);
        AssertCommandAreEqual(expectedCommand, command);
    }
    
    [Theory]
    [MemberData(nameof(IPX800V2HttpCommandFactoryTestCases.UnsupportedGetOutputsTestCases), MemberType = typeof(IPX800V2HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800V2M2MCommandFactoryTestCases.UnsupportedGetOutputsTestCases), MemberType = typeof(IPX800V2M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800V3HttpCommandFactoryTestCases.UnsupportedGetOutputsTestCases), MemberType = typeof(IPX800V3HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v3M2MCommandFactoryTestCases.UnsupportedGetOutputsTestCases), MemberType = typeof(IPX800v3M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4HttpCommandFactoryTestCases.UnsupportedGetOutputsTestCases), MemberType = typeof(IPX800v4HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4M2MCommandFactoryTestCases.UnsupportedGetOutputsTestCases), MemberType = typeof(IPX800v4M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800V5HttpCommandFactoryTestCases.UnsupportedGetOutputsTestCases), MemberType = typeof(IPX800V5HttpCommandFactoryTestCases))]
    public void GivenUnsupportedOutput_CreateGetOutputsCommand_ThrowsException(OutputType inputType, ICommandFactory commandFactory)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => commandFactory.CreateGetOutputsCommand(inputType));
    }
    
    #endregion
    
    #region SetOutputCommand

    [Theory]
    [MemberData(nameof(IPX800V2HttpCommandFactoryTestCases.SupportedSetOutputTestCases), MemberType = typeof(IPX800V2HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800V2M2MCommandFactoryTestCases.SupportedSetOutputTestCases), MemberType = typeof(IPX800V2M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800V3HttpCommandFactoryTestCases.SupportedSetOutputTestCases), MemberType = typeof(IPX800V3HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v3M2MCommandFactoryTestCases.SupportedSetOutputTestCases), MemberType = typeof(IPX800v3M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4HttpCommandFactoryTestCases.SupportedSetOutputTestCases), MemberType = typeof(IPX800v4HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4M2MCommandFactoryTestCases.SupportedSetOutputTestCases), MemberType = typeof(IPX800v4M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800V5HttpCommandFactoryTestCases.SupportedSetOutputTestCases), MemberType = typeof(IPX800V5HttpCommandFactoryTestCases))]
    public void GivenSupportedOutput_CreateSetOutputCommand_ReturnsMatchingCommand(Output output, Command expectedCommand, ICommandFactory commandFactory)
    {
        var command = commandFactory.CreateSetOutputCommand(output);
        AssertCommandAreEqual(expectedCommand, command);
    }
    
    [Theory]
    [MemberData(nameof(IPX800V2HttpCommandFactoryTestCases.UnsupportedSetOutputTestCases), MemberType = typeof(IPX800V2HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800V2M2MCommandFactoryTestCases.UnsupportedSetOutputTestCases), MemberType = typeof(IPX800V2M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800V3HttpCommandFactoryTestCases.UnsupportedSetOutputTestCases), MemberType = typeof(IPX800V3HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v3M2MCommandFactoryTestCases.UnsupportedSetOutputTestCases), MemberType = typeof(IPX800v3M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4HttpCommandFactoryTestCases.UnsupportedSetOutputTestCases), MemberType = typeof(IPX800v4HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4M2MCommandFactoryTestCases.UnsupportedSetOutputTestCases), MemberType = typeof(IPX800v4M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800V5HttpCommandFactoryTestCases.UnsupportedSetOutputTestCases), MemberType = typeof(IPX800V5HttpCommandFactoryTestCases))]
    public void GivenUnsupportedOutput_CreateSetOutputCommand_ThrowsException(Output output, ICommandFactory commandFactory)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => commandFactory.CreateSetOutputCommand(output));
    }
    
    #endregion
}