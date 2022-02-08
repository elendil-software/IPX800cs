using System.Net.Http;
using IPX800cs.Commands.Senders.HttpWebRequestBuilder;

namespace IPX800cs.Commands.Senders;

internal class CommandSenderIPX800V5 : CommandSenderHttp
{
    public CommandSenderIPX800V5(IHttpRequestMessageBuilder webRequestBuilder, HttpClient httpClient) : base(webRequestBuilder, httpClient)
    {
    }

    protected override string ReadResponse(HttpResponseMessage response)
    {
        return response.Content.ReadAsStringAsync().Result;
    }
}