using System;
using System.Net;
using System.Text;

namespace IPX800cs.Commands.Senders.HttpWebRequestBuilder;

internal class AuthorizedHttpWebRequestBuilder : HttpWebRequestBuilderBase
{
    public AuthorizedHttpWebRequestBuilder(Context context) : base(context)
    {
    }

    public override WebRequest Build(Command command)
    {
        var request = base.Build(command);
            
        AddAuthorizationHeader(request);

        return request;
    }
		
    private void AddAuthorizationHeader(WebRequest request)
    {
        string encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{Context.User}:{Context.Password}"));
        request.Headers.Add("Authorization", $"Basic {encoded}");
    }
}