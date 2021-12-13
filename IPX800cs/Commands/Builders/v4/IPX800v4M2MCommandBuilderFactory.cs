using IPX800cs.Commands.Builders.v4.M2M;
using IPX800cs.Exceptions;
using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v4
{
    internal class IPX800v4M2MCommandBuilderFactory : ICommandBuilderFactory
    {
        public ISetOutputCommandBuilder GetSetOutputCommandBuilder(Context context, Output output)
        {
            switch (output.Type)
            {
                case OutputType.VirtualOutput:
                    return new IPX800v4SetVirtualOutputM2MCommandBuilder();

                case OutputType.Output:
                    return new IPX800v4SetOutputM2MCommandBuilder();

                default:
                    throw new IPX800InvalidContextException($"Output type '{output.Type}' is not valid");
            }
        }

        public IGetOutputCommandBuilder GetGetOutputCommandBuilder(Context context, Output output)
        {
            switch (output.Type)
            {
                case OutputType.VirtualOutput:
                    return new IPX800v4GetVirtualOutputM2MCommandBuilder();

                case OutputType.Output:
                    return new IPX800v4GetOutputM2MCommandBuilder();

                default:
                    throw new IPX800InvalidContextException($"Output type '{output.Type}' is not valid");
            }
        }

        public IGetOutputsCommandBuilder GetGetOutputsCommandBuilder(Context context, Output output)
        {
            switch (output.Type)
            {
                case OutputType.VirtualOutput:
                    return new IPX800v4GetVirtualOutputsM2MCommandBuilder();

                case OutputType.Output:
                    return new IPX800v4GetOutputsM2MCommandBuilder();

                default:
                    throw new IPX800InvalidContextException($"Output type '{output.Type}' is not valid");
            }
        }

        public IGetInputCommandBuilder GetGetInputCommandBuilder(Context context, Input input)
        {
            switch (input.Type)
            {
                case InputType.AnalogInput:
                    return new IPX800v4GetAnalogInputM2MCommandBuilder();

                case InputType.DigitalInput:
                    return new IPX800v4GetInputM2MCommandBuilder();

                case InputType.VirtualAnalogInput:
                    return new IPX800v4GetVirtualAnalogInputM2MCommandBuilder();

                case InputType.VirtualDigitalInput:
                    return new IPX800v4GetVirtualInputM2MCommandBuilder();

                default:
                    throw new IPX800InvalidContextException($"Input type '{input.Type}' is not valid");
            }
        }

        public IGetInputsCommandBuilder GetGetInputsCommandBuilder(Context context, Input input)
        {
            switch (input.Type)
            {
                case InputType.DigitalInput:
                    return new IPX800v4GetInputsM2MCommandBuilder();

                case InputType.AnalogInput:
                    return new IPX800v4GetAnalogInputsM2MCommandBuilder();
                    
                case InputType.VirtualAnalogInput:
                    return new IPX800v4GetVirtualAnalogInputsM2MCommandBuilder();
                
                case InputType.VirtualDigitalInput:
                    return new IPX800v4GetVirtualInputsM2MCommandBuilder();
                
                default:
                    throw new IPX800InvalidContextException($"Input type '{input.Type}' is not valid");
            }
        }
    }
}