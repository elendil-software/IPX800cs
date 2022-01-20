using IPX800cs.Commands.Senders.HttpWebRequestBuilder;
using IPX800cs.Exceptions;
using IPX800cs.Version;

namespace IPX800cs.Commands.Senders;

internal static class HttpWebRequestBuilderFactory
{
    public static IHttpWebRequestBuilder Create(Context context)
    {
        return context.Version switch
        {
            IPX800Version.V2 => CreateV2V3HttpWebRequestBuilder(context),
            IPX800Version.V3 => CreateV2V3HttpWebRequestBuilder(context),
            IPX800Version.V4 => CreateV4HttpWebRequestBuilder(context),
            IPX800Version.V5 => new ApiKeyHttpWebRequestBuilder(context, "ApiKey"),
            _ => throw new IPX800InvalidContextException($"IPX800 version {context.Version} is not supported")
        };
    }
    
    private static IHttpWebRequestBuilder CreateV2V3HttpWebRequestBuilder(Context context)
    {
        if (!string.IsNullOrWhiteSpace(context.User) && !string.IsNullOrWhiteSpace(context.Password))
        {
            return new AuthorizedHttpWebRequestBuilder(context);
        }

        return new HttpWebRequestBuilderBase(context);
    }

    private static IHttpWebRequestBuilder CreateV4HttpWebRequestBuilder(Context context)
    {
        if (!string.IsNullOrWhiteSpace(context.Password))
        {
            return new ApiKeyHttpWebRequestBuilder(context, "key");
        }

        return new HttpWebRequestBuilderBase(context);
    }
}