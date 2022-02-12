using System;
using System.Net.Http;
using IPX800cs.Version;

namespace IPX800cs.Commands.Senders;

internal static class CommandSenderFactory
{
    public static ICommandSender GetCommandSender(Context context, HttpClient httpClient = null)
    {
        if (context.Protocol == IPX800Protocol.M2M)
        {
            return new CommandSenderM2M(context);
        }

        httpClient ??= new HttpClient();
        if (httpClient.BaseAddress == null)
        {
            httpClient.BaseAddress = new Uri($"{context.Host}:{context.Port}");
        }
        
        if (context.Version == IPX800Version.V5)
        {    
            return new CommandSenderIPX800V5(HttpWebRequestBuilderFactory.Create(context), httpClient);
        }

        return new CommandSenderHttp(HttpWebRequestBuilderFactory.Create(context), httpClient);
    }
}