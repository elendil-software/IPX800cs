using System;
using System.Net;
using System.Text;

namespace IPX800cs.Commands.Senders.HttpWebRequestBuilder;

internal class IPX800v4HttpWebRequestBuilder : IHttpWebRequestBuilder
{
    private readonly Context _context;
    private readonly string _keyArgName;

    public IPX800v4HttpWebRequestBuilder(Context context, string keyArgName)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _keyArgName = keyArgName ?? throw new ArgumentNullException(nameof(keyArgName));
    }

    public WebRequest Build(Command command)
    {
        string uri = BuildRequestUriString(command.QueryString);
        var request = (HttpWebRequest) WebRequest.Create(uri);

        return request;
    }
        
    private string BuildRequestUriString(string command)
    {
        var uri = new StringBuilder($"{_context.Host}:{_context.Port}{command}");

        if (!string.IsNullOrWhiteSpace(_context.Password))
        {
            uri.Append($"&{_keyArgName}={_context.Password}");
        }

        return uri.ToString();
    }
}