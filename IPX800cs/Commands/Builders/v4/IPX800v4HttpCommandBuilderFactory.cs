using IPX800cs.Commands.Builders.v4.Http;
using IPX800cs.Exceptions;
using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v4
{
    internal class IPX800v4HttpCommandBuilderFactory : ICommandBuilderFactory
    {
        public ISetOutputCommandBuilder GetSetOutputCommandBuilder(Context context, Output output)
        {
            switch (output.Type)
            {
                case OutputType.VirtualOutput:
                    return new IPX800v4SetVirtualOutputHttpCommandBuilder();

                case OutputType.Output:
                    return new IPX800v4SetOutputHttpCommandBuilder();

                default:
                    throw new IPX800InvalidContextException($"Output type '{output.Type}' is not valid");
            }
        }

        public IGetOutputCommandBuilder GetGetOutputCommandBuilder(Context context, Output output)
        {
            switch (output.Type)
            {
                case OutputType.VirtualOutput:
                    return new IPX800v4GetVirtualOutputHttpCommandBuilder();

                case OutputType.Output:
                    return new IPX800v4GetOutputHttpCommandBuilder();

                default:
                    throw new IPX800InvalidContextException($"Output type '{output.Type}' is not valid");
            }
        }

        public IGetOutputsCommandBuilder GetGetOutputsCommandBuilder(Context context, Output output)
        {
            switch (output.Type)
            {
                case OutputType.VirtualOutput:
                    return new IPX800v4GetVirtualOutputsHttpCommandBuilder();

                case OutputType.Output:
                    return new IPX800v4GetOutputsHttpCommandBuilder();

                default:
                    throw new IPX800InvalidContextException($"Output type '{output.Type}' is not valid");
            }
        }

        public IGetInputCommandBuilder GetGetInputCommandBuilder(Context context, Input input)
        {
            switch (input.Type)
            {
                case InputType.AnalogInput:
                    return new IPX800v4GetAnalogInputHttpCommandBuilder();

                case InputType.DigitalInput:
                    return new IPX800v4GetInputHttpCommandBuilder();

                case InputType.VirtualAnalogInput:
                    return new IPX800v4GetVirtualAnalogInputHttpCommandBuilder();

                case InputType.VirtualDigitalInput:
                    return new IPX800v4GetVirtualInputHttpCommandBuilder();

                default:
                    throw new IPX800InvalidContextException($"Input type '{input.Type}' is not valid");
            }
        }

        public IGetInputsCommandBuilder GetGetInputsCommandBuilder(Context context, Input input)
        {
            switch (input.Type)
            {
                case InputType.DigitalInput:
                    return new IPX800v4GetInputsHttpCommandBuilder();

                case InputType.AnalogInput:
                    return new IPX800v4GetAnalogInputsHttpCommandBuilder();
                    
                case InputType.VirtualAnalogInput:
                    return new IPX800v4GetVirtualAnalogInputsHttpCommandBuilder();
                    
                case InputType.VirtualDigitalInput:
                    return new IPX800v4GetVirtualInputsHttpCommandBuilder();

                default:
                    throw new IPX800InvalidContextException($"Input type '{input.Type}' is not valid");
            }
        }

        public IGetVersionCommandBuilder GetGetVersionCommandBuilder(Context context)
        {
            throw new IPX800NotSupportedCommandException("GetVersion command is not supported by IPX800 v4");
        }
    }
}