﻿using software.elendil.IPX800.Commands.Builders.v2.M2M;
using software.elendil.IPX800.Exceptions;
using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v2
{
    public class IPX800v2M2MCommandBuilderFactory : ICommandBuilderFactory
    {
        public ISetOutputCommandBuilder GetSetOutputCommandBuilder(Context context, Output output)
        {
            if (output.Type == OutputType.Output)
            {
                return new Ipx800V2SetOutputOutputM2MCommandBuilder();
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
    }
}