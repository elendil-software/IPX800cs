using software.elendil.IPX800.Exceptions;
using software.elendil.IPX800.Parsers.v2;
using software.elendil.IPX800.Parsers.v3;
using software.elendil.IPX800.Parsers.v4;
using software.elendil.IPX800.Version;

namespace software.elendil.IPX800.Parsers
{
    public class ResponseParserFactoryProvider : IResponseParserFactoryProvider
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