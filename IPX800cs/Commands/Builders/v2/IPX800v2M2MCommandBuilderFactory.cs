using IPX800cs.Commands.Builders.v2.M2M;
using IPX800cs.Exceptions;
using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v2
{
    internal class IPX800v2M2MCommandBuilderFactory : ICommandBuilderFactory
    {
        public ISetOutputCommandBuilder GetSetOutputCommandBuilder(Context context, Output output)
        {
            if (output.Type == OutputType.Output)
            {
                return new IPX800v2SetOutputM2MCommandBuilder();
            }

            throw new IPX800InvalidContextException($"Output type '{output.Type}' is not valid");
        }

        public IGetOutputCommandBuilder GetGetOutputCommandBuilder(Context context, Output output)
        {
            if (output.Type == OutputType.Output)
            {
                return new IPX800v2GetOutputM2MCommandBuilder();
            }

            throw new IPX800InvalidContextException($"Output type '{output.Type}' is not valid");
        }

        public IGetOutputsCommandBuilder GetGetOutputsCommandBuilder(Context context, Output output)
        {
            throw new IPX800InvalidContextException("GetOutputs command is not supported by IPX800 v2");
        }

        public IGetInputCommandBuilder GetGetInputCommandBuilder(Context context, Input input)
        {
            switch (input.Type)
            {
                case InputType.AnalogInput:
                    return new IPX800v2GetAnalogInputM2MCommandBuilder();

                case InputType.DigitalInput:
                    return new IPX800v2GetInputM2MCommandBuilder();

                default:
                    throw new IPX800InvalidContextException($"Input type '{input.Type}' is not valid");
            }
        }

        public IGetInputsCommandBuilder GetGetInputsCommandBuilder(Context context, Input input)
        {
            throw new IPX800InvalidContextException("GetOutputs command is not supported by IPX800 v2");
        }

        public IGetVersionCommandBuilder GetGetVersionCommandBuilder(Context context)
        {
            throw new IPX800NotSupportedCommandException("GetVersion command is not supported by IPX800 v2 M2M");
        }
    }
}