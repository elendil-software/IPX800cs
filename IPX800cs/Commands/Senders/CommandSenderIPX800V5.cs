using System.Net;
using System.Text;
using IPX800cs.Commands.Senders.HttpWebRequestBuilder;

namespace IPX800cs.Commands.Senders;

internal class CommandSenderIPX800V5 : CommandSenderHttp
{
    public CommandSenderIPX800V5(IHttpWebRequestBuilder webRequestBuilder) : base(webRequestBuilder)
    {
    }

    protected override string ReadResponse(HttpWebResponse response)
    {
        using var reader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.ASCII);
        string responseText = reader.ReadToEnd();
        return responseText;
    }
}