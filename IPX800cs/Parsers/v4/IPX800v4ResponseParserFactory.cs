using System;
using software.elendil.IPX800.Exceptions;
using software.elendil.IPX800.IO;
using software.elendil.IPX800.Parsers.v4.Http;
using software.elendil.IPX800.Parsers.v4.M2M;

namespace software.elendil.IPX800.Parsers.v4
{
    public class IPX800v4ResponseParserFactory : IResponseParserFactory
    {
        public IGetVersionResponseParser GetVersionResponseParser(Context context)
        {
            throw new IPX800NotSupportedCommandException("GetVersion command is not supported by IPX800v4");
        }

        public IAnalogInputResponseParser GetAnalogInputParser(Context context, Input input)
        {
            switch (context.Protocol)
            {
                case IPX800Protocol.Http:
                    return new IPX800v4GetAnalogInputHttpResponseParser();
                
                case IPX800Protocol.M2M:
                    return new IPX800v4GetAnalogInputM2MResponseParser();
                
                default:
                    throw new IPX800InvalidContextException($"'{context.Protocol}' is not a valid protocol");
            }
        }

        public IInputResponseParser GetInputParser(Context context, Input input)
        {
            switch (context.Protocol)
            {
                case IPX800Protocol.Http:
                    return new IPX800v4GetInputHttpResponseParser();
                
                case IPX800Protocol.M2M:
                    return new IPX800v4GetInputM2MResponseParser();
                
                default:
                    throw new IPX800InvalidContextException($"'{context.Protocol}' is not a valid protocol");
            }
        }

        public IGetOutputResponseParser GetOutputParser(Context context, Output input)
        {
            switch (context.Protocol)
            {
                case IPX800Protocol.Http:
                    return new IPX800v4GetOutputHttpResponseParser();
                
                case IPX800Protocol.M2M:
                    return new IPX800v4GetOutputM2MResponseParser();
                
                default:
                    throw new IPX800InvalidContextException($"'{context.Protocol}' is not a valid protocol");
            }
        }

        public ISetOutputResponseParser GetSetOutputParser(Context context, Output input)
        {
            switch (context.Protocol)
            {
                case IPX800Protocol.Http:
                    return new IPX800v4SetOutputHttpResponseParser();
                
                case IPX800Protocol.M2M:
                    return new IPX800v4SetOutputM2MResponseParser();
                
                default:
                    throw new IPX800InvalidContextException($"'{context.Protocol}' is not a valid protocol");
            }
        }
    }
}