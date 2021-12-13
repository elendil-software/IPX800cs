using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v3.Http;
using IPX800cs.Parsers.v3.M2M;

namespace IPX800cs.Parsers.v3
{
    internal class IPX800v3ResponseParserFactory : IResponseParserFactory
    {
        public IAnalogInputResponseParser GetAnalogInputParser(Context context, Input input)
        {
            switch (context.Protocol)
            {
                case IPX800Protocol.Http:
                    return new IPX800v3GetAnalogInputHttpResponseParser();
                
                case IPX800Protocol.M2M:
                    return new IPX800v3GetAnalogInputM2MResponseParser();

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
                    return new IPX800v3GetInputHttpResponseParser();
                
                case IPX800Protocol.M2M:
                    return new IPX800v3GetInputM2MResponseParser();

                default:
                    throw new IPX800InvalidContextException($"'{context.Protocol}' is not a valid protocol");
            }
        }

        public IInputsResponseParser GetInputsParser(Context context, Input input)
        {
            switch (context.Protocol)
            {
                case IPX800Protocol.Http:
                    return new IPX800v3GetInputsHttpResponseParser();

                case IPX800Protocol.M2M:
                    return new IPX800v3GetInputsM2MResponseParser();
                    
                default:
                    throw new IPX800InvalidContextException($"'{context.Protocol}' is not a valid protocol");
            }
        }

        public IGetOutputResponseParser GetOutputParser(Context context, Output output)
        {
            switch (context.Protocol)
            {
                case IPX800Protocol.Http:
                    return new IPX800v3GetOutputHttpResponseParser();
                
                case IPX800Protocol.M2M:
                    return new IPX800v3GetOutputM2MResponseParser();

                default:
                    throw new IPX800InvalidContextException($"'{context.Protocol}' is not a valid protocol");
            }
        }

        public IGetOutputsResponseParser GetOutputsParser(Context context, Output output)
        {
            switch (context.Protocol)
            {
                case IPX800Protocol.Http:
                    return new IPX800v3GetOutputsHttpResponseParser();

                case IPX800Protocol.M2M:
                    return new IPX800v3GetOutputsM2MResponseParser();

                default:
                    throw new IPX800InvalidContextException($"'{context.Protocol}' is not a valid protocol");
            }
        }

        public ISetOutputResponseParser GetSetOutputParser(Context context, Output output)
        {
            switch (context.Protocol)
            {
                case IPX800Protocol.Http:
                    return new IPX800v3SetOutputHttpResponseParser();
                
                case IPX800Protocol.M2M:
                    return new IPX800v3SetOutputM2MResponseParser();

                default:
                    throw new IPX800InvalidContextException($"'{context.Protocol}' is not a valid protocol");
            }
        }
    }
}