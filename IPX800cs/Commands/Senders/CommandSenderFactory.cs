using IPX800cs.Version;

namespace IPX800cs.Commands.Senders;

internal class CommandSenderFactory : ICommandSenderFactory
{
    public ICommandSender GetCommandSender(Context context)
    {
        if (context.Protocol == IPX800Protocol.M2M)
        {
            return new CommandSenderM2M(context);
        }

        if (context.Version == IPX800Version.V5)
        {
            return new CommandSenderIPX800V5(HttpWebRequestBuilderFactory.Create(context));
        }
        
        return new CommandSenderHttp(HttpWebRequestBuilderFactory.Create(context));
    }
}