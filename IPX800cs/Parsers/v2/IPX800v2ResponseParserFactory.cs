using software.elendil.IPX800.Exceptions;
using software.elendil.IPX800.IO;
using software.elendil.IPX800.Parsers.v2.Http;
using software.elendil.IPX800.Parsers.v2.M2M;

namespace software.elendil.IPX800.Parsers.v2
{
    internal class IPX800v2ResponseParserFactory : IResponseParserFactory
    {
        public IGetVersionResponseParser GetVersionResponseParser(Context context)
        {
            switch (context.Protocol)
            {
                case IPX800Protocol.Http:
                    return new IPX800v2GetVersionHttpResponseParser();
                
                case IPX800Protocol.M2M:
                    throw new IPX800InvalidContextException("M2M GetVersion is not supported by IPX800 v2, use HTTP instead");
                
                default:
                    throw new IPX800InvalidContextException($"'{context.Protocol}' is not a valid protocol");
            }
        }

        public IAnalogInputResponseParser GetAnalogInputParser(Context context, Input input)
        {
            switch (context.Protocol)
            {
                case IPX800Protocol.Http:
                    return new IPX800v2GetAnalogInputHttpResponseParser();
                
                case IPX800Protocol.M2M:
                    return new IPX800v2GetAnalogInputM2MResponseParser();
                
                default:
                    throw new IPX800InvalidContextException($"'{context.Protocol}' is not a valid protocol");
            }
        }

        public IInputResponseParser GetInputParser(Context context, Input input)
        {
            switch (context.Protocol)
            {
                case IPX800Protocol.Http:
                    return new IPX800v2GetInputHttpResponseParser();
                
                case IPX800Protocol.M2M:
                    return new IPX800v2GetInputM2MResponseParser();
                
                default:
                    throw new IPX800InvalidContextException($"'{context.Protocol}' is not a valid protocol");
            }
        }

        public IGetOutputResponseParser GetOutputParser(Context context, Output input)
        {
            switch (context.Protocol)
            {
                case IPX800Protocol.Http:
                    return new IPX800v2GetOutputHttpResponseParser();
                
                case IPX800Protocol.M2M:
                    return new IPX800v2GetOutputM2MResponseParser();
                
                default:
                    throw new IPX800InvalidContextException($"'{context.Protocol}' is not a valid protocol");
            }
        }

        public ISetOutputResponseParser GetSetOutputParser(Context context, Output input)
        {
            switch (context.Protocol)
            {
                case IPX800Protocol.Http:
                    return new IPX800v2SetOutputHttpResponseParser();
                
                case IPX800Protocol.M2M:
                    return new IPX800v2SetOutputM2MResponseParser();
                
                default:
                    throw new IPX800InvalidContextException($"'{context.Protocol}' is not a valid protocol");
            }
        }
    }
}