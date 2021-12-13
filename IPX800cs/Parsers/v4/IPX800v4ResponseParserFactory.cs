using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v4.Http;
using IPX800cs.Parsers.v4.M2M;

namespace IPX800cs.Parsers.v4
{
    internal class IPX800v4ResponseParserFactory : IResponseParserFactory
    {
        public IAnalogInputResponseParser GetAnalogInputParser(Context context, Input input)
        {
            switch (context.Protocol)
            {
                case IPX800Protocol.Http:
                    if (input.Type == InputType.AnalogInput)
                    {
                        return new IPX800v4GetAnalogInputHttpResponseParser();
                    }
                    else
                    {
                        return new IPX800v4GetVirtualAnalogInputHttpResponseParser();
                    }

                case IPX800Protocol.M2M:
                    if (input.Type == InputType.AnalogInput)
                    {
                        return new IPX800v4GetAnalogInputM2MResponseParser();
                    }
                    else
                    {
                        return new IPX800v4GetVirtualAnalogInputM2MResponseParser();
                    }

                default:
                    throw new IPX800InvalidContextException($"'{context.Protocol}' is not a valid protocol");
            }
        }

        public IInputResponseParser GetInputParser(Context context, Input input)
        {
            switch (context.Protocol)
            {
                case IPX800Protocol.Http:
                    if (input.Type == InputType.DigitalInput)
                    {
                        return new IPX800v4GetInputHttpResponseParser();
                    }
                    else
                    {
                        return new IPX800v4GetVirtualInputHttpResponseParser();
                    }
                
                case IPX800Protocol.M2M:
                    if (input.Type == InputType.DigitalInput)
                    {
                        return new IPX800v4GetInputM2MResponseParser();
                    }
                    else
                    {
                        return new IPX800v4GetVirtualInputM2MResponseParser();
                    }

                default:
                    throw new IPX800InvalidContextException($"'{context.Protocol}' is not a valid protocol");
            }
        }

        public IInputsResponseParser GetInputsParser(Context context, Input input)
        {
            switch (context.Protocol)
            {
                case IPX800Protocol.Http:
                    return GetHttpInputsParser(context, input);

                case IPX800Protocol.M2M:
                    return GetM2MInputsParser(context, input);
                
                default:
                    throw new IPX800InvalidContextException($"'{context.Protocol}' is not a valid protocol");
            }
        }

        private IInputsResponseParser GetM2MInputsParser(Context context, Input input)
        {
            switch (input.Type)
            {
                case InputType.VirtualDigitalInput:
                    return new IPX800v4GetVirtualInputsM2MResponseParser();

                case InputType.DigitalInput:
                    return new IPX800v4GetInputsM2MResponseParser();

                default:
                    throw new IPX800InvalidContextException($"'{input}' is not a valid inputType for GetInputsParser");
            }
        }

        private IInputsResponseParser GetHttpInputsParser(Context context, Input input)
        {
            switch (input.Type)
            {
                case InputType.VirtualDigitalInput:
                    return new IPX800v4GetVirtualInputsHttpResponseParser();
                
                case InputType.DigitalInput:
                    return new IPX800v4GetInputsHttpResponseParser();
                
                default:
                    throw new IPX800InvalidContextException($"'{input}' is not a valid inputType for GetInputsParser");
            }
        }
        
        public IAnalogInputsResponseParser GetAnalogInputsParser(Context context, Input input)
        {
            switch (context.Protocol)
            {
                case IPX800Protocol.Http:
                    return GetHttpAnalogInputsParser(context, input);

                case IPX800Protocol.M2M:
                    return GetM2MAnalogInputsParser(context, input);
                
                default:
                    throw new IPX800InvalidContextException($"'{context.Protocol}' is not a valid protocol");
            }
        }

        private IAnalogInputsResponseParser GetM2MAnalogInputsParser(Context context, Input input)
        {
            switch (input.Type)
            {
                case InputType.VirtualAnalogInput:
                    return new IPX800v4GetVirtualAnalogInputsM2MResponseParser();

                case InputType.AnalogInput:
                    return new IPX800v4GetAnalogInputsM2MResponseParser();

                default:
                    throw new IPX800InvalidContextException($"'{input}' is not a valid inputType for GetAnalogInputsParser");
            }
        }

        private IAnalogInputsResponseParser GetHttpAnalogInputsParser(Context context, Input input)
        {
            switch (input.Type)
            {
                case InputType.VirtualAnalogInput:
                    return new IPX800v4GetVirtualAnalogInputsHttpResponseParser();
                
                case InputType.AnalogInput:
                    return new IPX800v4GetAnalogInputsHttpResponseParser();
                
                default:
                    throw new IPX800InvalidContextException($"'{input}' is not a valid inputType for GetAnalogInputsParser");
            }
        }

        public IGetOutputResponseParser GetOutputParser(Context context, Output output)
        {
            switch (context.Protocol)
            {
                case IPX800Protocol.Http:
                    if (output.Type == OutputType.Output)
                    {
                        return new IPX800v4GetOutputHttpResponseParser();
                    }
                    else
                    {
                        return new IPX800v4GetVirtualOutputHttpResponseParser();
                    }

                case IPX800Protocol.M2M:
                    if (output.Type == OutputType.Output)
                    {
                        return new IPX800v4GetOutputM2MResponseParser();
                    }
                    else
                    {
                        return new IPX800v4GetVirtualOutputM2MResponseParser();
                    }
                default:
                    throw new IPX800InvalidContextException($"'{context.Protocol}' is not a valid protocol");
            }
        }

        public IGetOutputsResponseParser GetOutputsParser(Context context, Output output)
        {
            switch (context.Protocol)
            {
                case IPX800Protocol.Http:
                    if (output.Type == OutputType.Output)
                    {
                        return new IPX800v4GetOutputsHttpResponseParser();
                    }
                    else
                    {
                        return new IPX800v4GetVirtualOutputsHttpResponseParser();
                    }
                
                case IPX800Protocol.M2M:
                    if (output.Type == OutputType.Output)
                    {
                        return new IPX800v4GetOutputsM2MResponseParser();
                    }
                    else
                    {
                        return new IPX800v4GetVirtualOutputsM2MResponseParser();
                    }

                default:
                    throw new IPX800InvalidContextException($"'{context.Protocol}' is not a valid protocol");
            }
        }

        public ISetOutputResponseParser GetSetOutputParser(Context context, Output output)
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