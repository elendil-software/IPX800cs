using System;
using System.Net;
using System.Text;

namespace IPX800cs.Commands.Senders.HttpWebRequestBuilder;

internal class DefaultHttpWebRequestBuilder : IHttpWebRequestBuilder
{
    private readonly Context context;

    public DefaultHttpWebRequestBuilder(Context context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public WebRequest Build(Command command)
    {
        var uri = $"{context.Host}:{context.Port}/{command.QueryString}";
        var request = (HttpWebRequest) WebRequest.Create(uri);
            
        AddAuthorizationHeader(request);

        return request;
    }
		
    private void AddAuthorizationHeader(WebRequest request)
    {
        if (!string.IsNullOrWhiteSpace(context.User) && !string.IsNullOrWhiteSpace(context.Password))
        {
            string encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes($"{context.User}:{context.Password}"));
            request.Headers.Add("Authorization", $"Basic {encoded}");
        }
    }
}