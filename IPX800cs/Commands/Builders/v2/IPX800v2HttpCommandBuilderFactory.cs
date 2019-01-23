using software.elendil.IPX800.Commands.Builders.v2.Http;
using software.elendil.IPX800.Exceptions;
using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v2
{
    public class IPX800v2HttpCommandBuilderFactory : ICommandBuilderFactory
    {
        public ISetOutputCommandBuilder GetSetOutCommandBuilder(Context context, IPX800Output output)
        {
            return new Ipx800V2SetOutputOutputHttpCommandBuilder();
        }

        public IGetOutputCommandBuilder GetGetOutputCommandBuilder(Context context, IPX800Output output)
        {
            return new IPX800v2GetOutputHttpCommandBuilder();
        }

        public IGetInputCommandBuilder GetGetInputCommandBuilder(Context context, Input input)
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