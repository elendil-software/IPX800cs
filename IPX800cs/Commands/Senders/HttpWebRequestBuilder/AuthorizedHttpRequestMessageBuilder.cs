using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace IPX800cs.Commands.Senders.HttpWebRequestBuilder;

internal class AuthorizedHttpRequestMessageBuilder : HttpRequestMessageBuilderBase
{
    public AuthorizedHttpRequestMessageBuilder(Context context) : base(context)
    {
    }

    public override HttpRequestMessage Build(Command command)
    {
        HttpRequestMessage request = base.Build(command);
        string encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{Context.User}:{Context.Password}"));
        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", encoded);
        return request;
    }
}