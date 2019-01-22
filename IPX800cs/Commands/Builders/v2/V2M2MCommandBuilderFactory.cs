using software.elendil.IPX800.Commands.Builders.v2.M2M;
using software.elendil.IPX800.Exceptions;
using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v2
{
    public class V2M2MCommandBuilderFactory : ICommandBuilderFactory
    {
        public ISetCommandBuilder GetSetOutCommandBuilder(Context context, IPX800Output output)
        {
            return new SetOutCommandBuilder();
        }

        public IGetOutCommandBuilder GetGetOutputCommandBuilder(Context context, IPX800Output output)
        {
            return new GetOutCommandBuilder();
        }

        public IGetInCommandBuilder GetGetInputCommandBuilder(Context context, IPX800Input input)
        {
            switch (input.Type)
            {
                case InputType.AnalogInput:
                    return new GetAnalogInputCommandBuilder();
                case InputType.DigitalInput:
                    return new GetInCommandBuilder();
            }

            throw new IPX800CommandException("Corresponding command builder not found");
        }
    }
}