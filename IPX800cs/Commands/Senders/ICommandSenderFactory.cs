namespace IPX800cs.Commands.Senders;

public interface ICommandSenderFactory
{
    ICommandSender GetCommandSender(Context context);
}