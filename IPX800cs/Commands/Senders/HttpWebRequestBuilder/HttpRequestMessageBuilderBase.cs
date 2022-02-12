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
        var request = new HttpRequestMessage(command.Method, BuildRequestUriString(command));
        if (!string.IsNullOrWhiteSpace(command.Body))
        {
            request.Content = new StringContent(command.Body, Encoding.ASCII, command.ContentType);
        }

        return request;
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