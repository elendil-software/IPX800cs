using IPX800cs.Commands.Builders.v2.Http;
using IPX800cs.Exceptions;
using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v2
{
    internal class IPX800v2HttpCommandBuilderFactory : ICommandBuilderFactory
    {
        public ISetOutputCommandBuilder GetSetOutputCommandBuilder(Context context, Output output)
        {
            if (output.Type == OutputType.Output)
            {
                return new IPX800v2SetOutputHttpCommandBuilder();
            }

            throw new IPX800InvalidContextException($"Output type '{output.Type}' is not valid");
        }

        public IGetOutputCommandBuilder GetGetOutputCommandBuilder(Context context, Output output)
        {
            if (output.Type == OutputType.Output)
            {
                return new IPX800v2GetOutputHttpCommandBuilder();
            }

            throw new IPX800InvalidContextException($"Output type '{output.Type}' is not valid");
        }

        public IGetInputCommandBuilder GetGetInputCommandBuilder(Context context, Input input)
        {
            switch (input.Type)
            {
                case InputType.AnalogInput:
                    return new IPX800v2GetAnalogInputHttpCommandBuilder();

                case InputType.DigitalInput:
                    return new IPX800v2GetInputHttpCommandBuilder();

                default:
                    throw new IPX800InvalidContextException($"Input type '{input.Type}' is not valid");
            }
        }

        public IGetVersionCommandBuilder GetGetVersionCommandBuilder(Context context)
        {
            return new IPX800v2GetVersionHttpCommandBuilder();
        }
    }
}