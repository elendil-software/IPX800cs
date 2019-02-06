using IPX800cs.Commands.Senders.HttpWebRequestBuilder;
using IPX800cs.Version;

namespace IPX800cs.Commands.Senders
{
    internal class CommandSenderFactory : ICommandSenderFactory
    {
        public ICommandSender GetCommandSender(Context context)
        {
            if (context.Protocol == IPX800Protocol.M2M)
            {
                return new CommandSenderM2M(context);
            }
            else
            {
                IHttpWebRequestBuilder httpWebRequestBuilder;
                if (context.Version == IPX800Version.V4)
                {
                    httpWebRequestBuilder = new IPX800v4HttpWebRequestBuilder(context);
                }
                else
                {
                    httpWebRequestBuilder = new DefaultHttpWebRequestBuilder(context);
                }
                
                return new CommandSenderHttp(httpWebRequestBuilder);
            }
        }
    }
}