using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v2.Http;
using IPX800cs.Parsers.v2.M2M;

namespace IPX800cs.Parsers.v2
{
    internal class IPX800v2ResponseParserFactory : IResponseParserFactory
    {
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

        public IAnalogInputsResponseParser GetAnalogInputsParser(Context context, Input input)
        {
            throw new System.NotImplementedException();
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

        public IInputsResponseParser GetInputsParser(Context context, Input input)
        {
            throw new IPX800InvalidContextException("GetInputs command is not supported by IPX800 v2");
        }

        public IGetOutputResponseParser GetOutputParser(Context context, Output output)
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

        public IGetOutputsResponseParser GetOutputsParser(Context context, Output output)
        {
            throw new IPX800InvalidContextException("GetOutputs command is not supported by IPX800 v2");
        }

        public ISetOutputResponseParser GetSetOutputParser(Context context, Output output)
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