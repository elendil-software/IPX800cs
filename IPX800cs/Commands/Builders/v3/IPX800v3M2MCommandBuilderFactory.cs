using software.elendil.IPX800.Commands.Builders.v3.M2M;
using software.elendil.IPX800.Exceptions;
using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v3
{
    public class IPX800v3M2MCommandBuilderFactory : ICommandBuilderFactory
    {
        public ISetOutputCommandBuilder GetSetOutCommandBuilder(Context context, IPX800Output output)
        {
            return new Ipx800V3SetOutputOutputM2MCommandBuilder();
        }

        public IGetOutputCommandBuilder GetGetOutputCommandBuilder(Context context, IPX800Output output)
        {
            return new IPX800v3GetOutputM2MCommandBuilder();
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

            throw new IPX800CommandException("Corresponding command builder not found");
        }
    }
}