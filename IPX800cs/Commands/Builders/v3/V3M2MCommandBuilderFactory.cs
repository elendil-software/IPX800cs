using software.elendil.IPX800.Commands.Builders.v3.M2M;
using software.elendil.IPX800.Exceptions;
using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v3
{
    public class V3M2MCommandBuilderFactory : ICommandBuilderFactory
    {
        public ISetCommandBuilder GetSetOutCommandBuilder(Context context, IPX800Output output)
        {
            return new SetOutCommandBuilder();
        }

        public IGetOutCommandBuilder GetGetOutputCommandBuilder(Context context, IPX800Output output)
        {
            return new IPX800v3GetOutputM2MCommandBuilder();
        }

        public IGetInCommandBuilder GetGetInputCommandBuilder(Context context, IPX800Input input)
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