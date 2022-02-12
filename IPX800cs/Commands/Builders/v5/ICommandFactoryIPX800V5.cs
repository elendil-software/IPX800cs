namespace IPX800cs.Commands.Builders.v5;

public interface IIPX800V5CommandFactory : ICommandFactory
{
    Command CreateGetTimersCommand();
}