using System;
using System.Net;
using System.Text;

namespace IPX800cs.Commands.Senders.HttpWebRequestBuilder;

internal class HttpWebRequestBuilderBase : IHttpWebRequestBuilder
{
    protected readonly Context Context;
    
    public HttpWebRequestBuilderBase(Context context)
    {
        Context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public virtual WebRequest Build(Command command)
    {
        string uri = BuildRequestUriString(command);
        var request = (HttpWebRequest) WebRequest.Create(uri);

        return request;
    }

    protected virtual string BuildRequestUriString(Command command)
    {
        var uri = new StringBuilder($"{Context.Host}:{Context.Port}");

        if (!command.QueryString.StartsWith("/"))
        {
            uri.Append("/");
        }

        uri.Append(command.QueryString);
        
        return uri.ToString();
    }
}