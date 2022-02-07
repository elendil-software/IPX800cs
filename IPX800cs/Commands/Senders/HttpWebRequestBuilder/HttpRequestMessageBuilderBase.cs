using System;
using System.Net;
using System.Net.Http;
using System.Text;

namespace IPX800cs.Commands.Senders.HttpWebRequestBuilder;

internal class HttpRequestMessageBuilderBase : IHttpRequestMessageBuilder
{
    protected readonly Context Context;
    
    public HttpRequestMessageBuilderBase(Context context)
    {
        Context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public virtual HttpRequestMessage Build(Command command)
    {
        return new HttpRequestMessage(command.Method, BuildRequestUriString(command));
    }

    protected virtual string BuildRequestUriString(Command command)
    {
        var query = new StringBuilder();

        if (!command.QueryString.StartsWith("/"))
        {
            query.Append("/");
        }

        query.Append(command.QueryString);
        
        return query.ToString();
    }
}