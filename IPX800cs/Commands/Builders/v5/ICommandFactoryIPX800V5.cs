namespace IPX800cs.Commands.Builders.v5;
#pragma warning disable CS1591

public interface IIPX800V5CommandFactory : ICommandFactory
{
    Command CreateGetTimersCommand();
}