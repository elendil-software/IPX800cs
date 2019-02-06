using IPX800cs.Commands.Builders.v3.M2M;
using IPX800cs.Exceptions;
using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v3
{
    internal class IPX800v3M2MCommandBuilderFactory : ICommandBuilderFactory
    {
        public ISetOutputCommandBuilder GetSetOutputCommandBuilder(Context context, Output output)
        {
            if (output.Type == OutputType.Output)
            {
                return new IPX800v3SetOutputM2MCommandBuilder();
            }

            throw new IPX800InvalidContextException($"Output type '{output.Type}' is not valid");
        }

        public IGetOutputCommandBuilder GetGetOutputCommandBuilder(Context context, Output output)
        {
            if (output.Type == OutputType.Output)
            {
                return new IPX800v3GetOutputM2MCommandBuilder();
            }

            throw new IPX800InvalidContextException($"Output type '{output.Type}' is not valid");
        }

        public IGetInputCommandBuilder GetGetInputCommandBuilder(Context context, Input input)
        {
            switch (input.Type)
            {
                case InputType.AnalogInput:
                    return new IPX800v3GetAnalogInputM2MCommandBuilder();
                case InputType.DigitalInput:
                    return new IPX800v3GetInputM2MCommandBuilder();
            }

            throw new IPX800InvalidContextException($"Input type '{input.Type}' is not valid");
        }

        public IGetVersionCommandBuilder GetGetVersionCommandBuilder(Context context)
        {
            return new IPX800v3GetVersionM2MCommandBuilder();
        }
    }
}