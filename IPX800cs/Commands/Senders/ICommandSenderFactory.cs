namespace software.elendil.IPX800.Commands.Senders
{
    public interface ICommandSenderFactory
    {
        ICommandSender GetCommandSender(Context context);
    }
}