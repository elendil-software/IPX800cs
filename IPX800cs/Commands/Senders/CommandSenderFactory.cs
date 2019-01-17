using software.elendil.IPX800.Version;

namespace software.elendil.IPX800.Commands.Senders
{
    public class CommandSenderFactory : ICommandSenderFactory
    {
        public ICommandSender GetCommandSender(Context context)
        {
            if (context.Protocol == IPX800Protocol.M2M)
            {
                return new CommandSenderM2M(context);
            }
            else if (context.Version == IPX800Version.V4)
            {
                return new CommandSenderHttpIPX800V4(context);
            }
            else
            {
                return new CommandSenderHttp(context);
            }
        }
    }
}