using IPX800cs.Exceptions;
using IPX800cs.Parsers.v2;
using IPX800cs.Parsers.v3;
using IPX800cs.Parsers.v4;
using IPX800cs.Version;

namespace IPX800cs.Parsers
{
    internal class ResponseParserFactoryProvider : IResponseParserFactoryProvider
    {
        public IResponseParserFactory GetResponseParserFactory(Context context)
        {
            switch (context.Version)
            {
                case IPX800Version.V2:
                    return new IPX800v2ResponseParserFactory();
                
                case IPX800Version.V3:
                    return new IPX800v3ResponseParserFactory();
                
                case IPX800Version.V4:
                    return new IPX800v4ResponseParserFactory();
                
                default:
                    throw new IPX800UnknownVersionException($"Version '{context.Version}' is not a valid IPX800 version");
            }
        }
    }
}