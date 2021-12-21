using IPX800cs.Commands.Builders;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using Xunit;

namespace IPX800cs.Test.Commands.Builders;

public class CommandFactoryTest
{
    #region GetInputCommand
    
    [Theory]
    [MemberData(nameof(IPX800v2HttpCommandFactoryTestCases.SupportedGetInputTestCases), MemberType = typeof(IPX800v2HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v2M2MCommandFactoryTestCases.SupportedGetInputTestCases), MemberType = typeof(IPX800v2M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v3HttpCommandFactoryTestCases.SupportedGetInputTestCases), MemberType = typeof(IPX800v3HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v3M2MCommandFactoryTestCases.SupportedGetInputTestCases), MemberType = typeof(IPX800v3M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4HttpCommandFactoryTestCases.SupportedGetInputTestCases), MemberType = typeof(IPX800v4HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4M2MCommandFactoryTestCases.SupportedGetInputTestCases), MemberType = typeof(IPX800v4M2MCommandFactoryTestCases))]
    public void GivenSupportedInput_CreateGetInputCommand_ReturnsMatchingCommand(Input input, string expectedCommand, ICommandFactory commandFactory)
    {
        var command = commandFactory.CreateGetInputCommand(input);
        Assert.Equal(expectedCommand, command);
    }
    
    [Theory]
    [MemberData(nameof(IPX800v2HttpCommandFactoryTestCases.UnsupportedGetInputTestCases), MemberType = typeof(IPX800v2HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v2M2MCommandFactoryTestCases.UnsupportedGetInputTestCases), MemberType = typeof(IPX800v2M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v3HttpCommandFactoryTestCases.UnsupportedGetInputTestCases), MemberType = typeof(IPX800v3HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v3M2MCommandFactoryTestCases.UnsupportedGetInputTestCases), MemberType = typeof(IPX800v3M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4HttpCommandFactoryTestCases.UnsupportedGetInputTestCases), MemberType = typeof(IPX800v4HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4M2MCommandFactoryTestCases.UnsupportedGetInputTestCases), MemberType = typeof(IPX800v4M2MCommandFactoryTestCases))]
    public void GivenUnsupportedInput_CreateGetInputCommand_ThrowsException(Input input, ICommandFactory commandFactory)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => commandFactory.CreateGetInputCommand(input));
    }
    
    #endregion
    
    #region GetInputsCommand
    
    [Theory]
    //[MemberData(nameof(IPX800v2HttpCommandFactoryTestCases.SupportedGetInputsTestCases), MemberType = typeof(IPX800v2HttpCommandFactoryTestCases))]
    //[MemberData(nameof(IPX800v2M2MCommandFactoryTestCases.SupportedGetInputsTestCases), MemberType = typeof(IPX800v2M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v3HttpCommandFactoryTestCases.SupportedGetInputsTestCases), MemberType = typeof(IPX800v3HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v3M2MCommandFactoryTestCases.SupportedGetInputsTestCases), MemberType = typeof(IPX800v3M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4HttpCommandFactoryTestCases.SupportedGetInputsTestCases), MemberType = typeof(IPX800v4HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4M2MCommandFactoryTestCases.SupportedGetInputsTestCases), MemberType = typeof(IPX800v4M2MCommandFactoryTestCases))]
    public void GivenSupportedInput_CreateGetInputsCommand_ReturnsMatchingCommand(InputType inputType, string expectedCommand, ICommandFactory commandFactory)
    {
        var command = commandFactory.CreateGetInputsCommand(inputType);
        Assert.Equal(expectedCommand, command);
    }
    
    [Theory]
    [MemberData(nameof(IPX800v2HttpCommandFactoryTestCases.UnsupportedGetInputsTestCases), MemberType = typeof(IPX800v2HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v2M2MCommandFactoryTestCases.UnsupportedGetInputsTestCases), MemberType = typeof(IPX800v2M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v3HttpCommandFactoryTestCases.UnsupportedGetInputsTestCases), MemberType = typeof(IPX800v3HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v3M2MCommandFactoryTestCases.UnsupportedGetInputsTestCases), MemberType = typeof(IPX800v3M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4HttpCommandFactoryTestCases.UnsupportedGetInputsTestCases), MemberType = typeof(IPX800v4HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4M2MCommandFactoryTestCases.UnsupportedGetInputsTestCases), MemberType = typeof(IPX800v4M2MCommandFactoryTestCases))]
    public void GivenUnsupportedInput_CreateGetInputsCommand_ThrowsException(InputType inputType, ICommandFactory commandFactory)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => commandFactory.CreateGetInputsCommand(inputType));
    }
    
    #endregion

    #region GetOutputCommand
    
    [Theory]
    [MemberData(nameof(IPX800v2HttpCommandFactoryTestCases.SupportedGetOutputTestCases), MemberType = typeof(IPX800v2HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v2M2MCommandFactoryTestCases.SupportedGetOutputTestCases), MemberType = typeof(IPX800v2M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v3HttpCommandFactoryTestCases.SupportedGetOutputTestCases), MemberType = typeof(IPX800v3HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v3M2MCommandFactoryTestCases.SupportedGetOutputTestCases), MemberType = typeof(IPX800v3M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4HttpCommandFactoryTestCases.SupportedGetOutputTestCases), MemberType = typeof(IPX800v4HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4M2MCommandFactoryTestCases.SupportedGetOutputTestCases), MemberType = typeof(IPX800v4M2MCommandFactoryTestCases))]
    public void GivenSupportedOutput_CreateGetOutputCommand_ReturnsMatchingCommand(Output output, string expectedCommand, ICommandFactory commandFactory)
    {
        var command = commandFactory.CreateGetOutputCommand(output);
        Assert.Equal(expectedCommand, command);
    }

    [Theory]
    [MemberData(nameof(IPX800v2HttpCommandFactoryTestCases.UnsupportedGetOutputTestCases), MemberType = typeof(IPX800v2HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v2M2MCommandFactoryTestCases.UnsupportedGetOutputTestCases), MemberType = typeof(IPX800v2M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v3HttpCommandFactoryTestCases.UnsupportedGetOutputTestCases), MemberType = typeof(IPX800v3HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v3M2MCommandFactoryTestCases.UnsupportedGetOutputTestCases), MemberType = typeof(IPX800v3M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4HttpCommandFactoryTestCases.UnsupportedGetOutputTestCases), MemberType = typeof(IPX800v4HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4M2MCommandFactoryTestCases.UnsupportedGetOutputTestCases), MemberType = typeof(IPX800v4M2MCommandFactoryTestCases))]
    public void GivenUnsupportedOutput_CreateGetOutputCommand_ThrowsException(Output output, ICommandFactory commandFactory)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => commandFactory.CreateGetOutputCommand(output));
    }
    
    #endregion
    
    #region GetOutputsCommand
    
    [Theory]
    //[MemberData(nameof(IPX800v2HttpCommandFactoryTestCases.SupportedGetOutputsTestCases), MemberType = typeof(IPX800v2HttpCommandFactoryTestCases))]
    //[MemberData(nameof(IPX800v2M2MCommandFactoryTestCases.SupportedGetOutputsTestCases), MemberType = typeof(IPX800v2M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v3HttpCommandFactoryTestCases.SupportedGetOutputsTestCases), MemberType = typeof(IPX800v3HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v3M2MCommandFactoryTestCases.SupportedGetOutputsTestCases), MemberType = typeof(IPX800v3M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4HttpCommandFactoryTestCases.SupportedGetOutputsTestCases), MemberType = typeof(IPX800v4HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4M2MCommandFactoryTestCases.SupportedGetOutputsTestCases), MemberType = typeof(IPX800v4M2MCommandFactoryTestCases))]
    public void GivenSupportedOutput_CreateGetOutputsCommand_ReturnsMatchingCommand(OutputType inputType, string expectedCommand, ICommandFactory commandFactory)
    {
        var command = commandFactory.CreateGetOutputsCommand(inputType);
        Assert.Equal(expectedCommand, command);
    }
    
    [Theory]
    [MemberData(nameof(IPX800v2HttpCommandFactoryTestCases.UnsupportedGetOutputsTestCases), MemberType = typeof(IPX800v2HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v2M2MCommandFactoryTestCases.UnsupportedGetOutputsTestCases), MemberType = typeof(IPX800v2M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v3HttpCommandFactoryTestCases.UnsupportedGetOutputsTestCases), MemberType = typeof(IPX800v3HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v3M2MCommandFactoryTestCases.UnsupportedGetOutputsTestCases), MemberType = typeof(IPX800v3M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4HttpCommandFactoryTestCases.UnsupportedGetOutputsTestCases), MemberType = typeof(IPX800v4HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4M2MCommandFactoryTestCases.UnsupportedGetOutputsTestCases), MemberType = typeof(IPX800v4M2MCommandFactoryTestCases))]
    public void GivenUnsupportedOutput_CreateGetOutputsCommand_ThrowsException(OutputType inputType, ICommandFactory commandFactory)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => commandFactory.CreateGetOutputsCommand(inputType));
    }
    
    #endregion
    
    #region SetOutputCommand

    [Theory]
    [MemberData(nameof(IPX800v2HttpCommandFactoryTestCases.SupportedSetOutputTestCases), MemberType = typeof(IPX800v2HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v2M2MCommandFactoryTestCases.SupportedSetOutputTestCases), MemberType = typeof(IPX800v2M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v3HttpCommandFactoryTestCases.SupportedSetOutputTestCases), MemberType = typeof(IPX800v3HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v3M2MCommandFactoryTestCases.SupportedSetOutputTestCases), MemberType = typeof(IPX800v3M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4HttpCommandFactoryTestCases.SupportedSetOutputTestCases), MemberType = typeof(IPX800v4HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4M2MCommandFactoryTestCases.SupportedSetOutputTestCases), MemberType = typeof(IPX800v4M2MCommandFactoryTestCases))]
    public void GivenSupportedOutput_CreateSetOutputCommand_ReturnsMatchingCommand(Output output, string expectedCommand, ICommandFactory commandFactory)
    {
        var command = commandFactory.CreateSetOutputCommand(output);
        Assert.Equal(expectedCommand, command);
    }
    
    [Theory]
    [MemberData(nameof(IPX800v2HttpCommandFactoryTestCases.UnsupportedSetOutputTestCases), MemberType = typeof(IPX800v2HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v2M2MCommandFactoryTestCases.UnsupportedSetOutputTestCases), MemberType = typeof(IPX800v2M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v3HttpCommandFactoryTestCases.UnsupportedSetOutputTestCases), MemberType = typeof(IPX800v3HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v3M2MCommandFactoryTestCases.UnsupportedSetOutputTestCases), MemberType = typeof(IPX800v3M2MCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4HttpCommandFactoryTestCases.UnsupportedSetOutputTestCases), MemberType = typeof(IPX800v4HttpCommandFactoryTestCases))]
    [MemberData(nameof(IPX800v4M2MCommandFactoryTestCases.UnsupportedSetOutputTestCases), MemberType = typeof(IPX800v4M2MCommandFactoryTestCases))]
    public void GivenUnsupportedOutput_CreateSetOutputCommand_ThrowsException(Output output, ICommandFactory commandFactory)
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => commandFactory.CreateSetOutputCommand(output));
    }
    
    #endregion
}