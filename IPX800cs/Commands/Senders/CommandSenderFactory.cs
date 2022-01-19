namespace IPX800cs.Commands.Senders;

internal class CommandSenderFactory : ICommandSenderFactory
{
    public ICommandSender GetCommandSender(Context context)
    {
        if (context.Protocol == IPX800Protocol.M2M)
        {
            return new CommandSenderM2M(context);
        }
        
        return new CommandSenderHttp(HttpWebRequestBuilderFactory.Create(context));
    }
}