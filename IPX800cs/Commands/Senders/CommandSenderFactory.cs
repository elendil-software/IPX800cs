using System;
using System.Net.Http;

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

        return new CommandSenderHttp(HttpWebRequestBuilderFactory.Create(context), httpClient);
    }
}