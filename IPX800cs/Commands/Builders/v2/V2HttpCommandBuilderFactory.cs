using software.elendil.IPX800.Commands.Builders.v2.Http;
using software.elendil.IPX800.Exceptions;
using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v2
{
    public class V2HttpCommandBuilderFactory : ICommandBuilderFactory
    {
        public ISetCommandBuilder GetSetOutCommandBuilder(Context context, IPX800Output output)
        {
            return new SetOutHttpCommandBuilder();
        }

        public IGetOutCommandBuilder GetGetOutputCommandBuilder(Context context, IPX800Output output)
        {
            return new GetOutHttpCommandBuilder();
        }

        public IGetInCommandBuilder GetGetInputCommandBuilder(Context context, IPX800Input input)
        {
            switch (input.Type)
            {
                case InputType.AnalogInput:
                    return new IPX800v2GetAnalogInputHttpCommandBuilder();
                case InputType.DigitalInput:
                    return new IPX800v2GetInputHttpCommandBuilder();
            }


            throw new IPX800CommandException("Corresponding command builder not found");
        }
    }
}