using software.elendil.IPX800.Commands.Builders.v2.M2M;
using software.elendil.IPX800.Exceptions;
using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v2
{
    public class IPX800v2M2MCommandBuilderFactory : ICommandBuilderFactory
    {
        public ISetOutputCommandBuilder GetSetOutCommandBuilder(Context context, IPX800Output output)
        {
            return new Ipx800V2SetOutputOutputM2MCommandBuilder();
        }

        public IGetOutputCommandBuilder GetGetOutputCommandBuilder(Context context, IPX800Output output)
        {
            return new IPX800v2GetOutputM2MCommandBuilder();
        }

        public IGetInputCommandBuilder GetGetInputCommandBuilder(Context context, IPX800Input input)
        {
            switch (input.Type)
            {
                case InputType.AnalogInput:
                    return new IPX800v2GetAnalogInputM2MCommandBuilder();
                case InputType.DigitalInput:
                    return new IPX800v2GetInputM2MCommandBuilder();
            }

            throw new IPX800CommandException("Corresponding command builder not found");
        }
    }
}