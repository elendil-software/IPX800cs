using IPX800cs.Commands;
using IPX800cs.Commands.Builders.v5;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v5;

public class IPX800V5CommandFactoryTest
{
    [Fact]
    public void CreateGetTimersCommand_ReturnsMatchingCommand()
    {
        IIPX800V5CommandFactory commandFactory = new IPX800V5HttpCommandFactory();
        var command = commandFactory.CreateGetTimersCommand();
        CommandFactoryTest.AssertCommandAreEqual(Command.CreateGet("/api/object/timer?option=filter_id"), command);
    }
}