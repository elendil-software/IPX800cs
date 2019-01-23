using software.elendil.IPX800.Commands.Builders.v4.Http;
using software.elendil.IPX800.Exceptions;
using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v4
{
    public class IPX800v4HttpCommandBuilderFactory : ICommandBuilderFactory
    {
        public ISetOutputCommandBuilder GetSetOutCommandBuilder(Context context, Output output)
        {
            switch (output.Type)
            {
                case OutputType.VirtualOutput:
                    return new Ipx800V4SetOutputVirtualOutputHttpCommandBuilder();

                case OutputType.Output:
                    return new Ipx800V4SetOutputOutputHttpCommandBuilder();

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
    }
}