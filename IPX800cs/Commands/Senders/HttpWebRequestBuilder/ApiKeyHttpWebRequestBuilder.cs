using System;
using System.Text;

namespace IPX800cs.Commands.Senders.HttpWebRequestBuilder;

internal class ApiKeyHttpWebRequestBuilder : HttpWebRequestBuilderBase
{
    private readonly string _keyArgName;

    public ApiKeyHttpWebRequestBuilder(Context context, string keyArgName) : base(context)
    {
        _keyArgName = keyArgName ?? throw new ArgumentNullException(nameof(keyArgName));
    }
    
    protected override string BuildRequestUriString(Command command)
    {
        string uri = base.BuildRequestUriString(command);
        return uri.Contains("?") ? $"{uri}&{_keyArgName}={Context.Password}" : $"{uri}?{_keyArgName}={Context.Password}";
    }
}