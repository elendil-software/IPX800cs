using software.elendil.IPX800.Commands.Builders.v4;
using software.elendil.IPX800.Commands.Builders.v4.Http;
using software.elendil.IPX800.Exceptions;
using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders
{
    public class V4HttpCommandBuilderFactory : ICommandBuilderFactory
    {
        public ISetCommandBuilder GetSetOutCommandBuilder(Context context, IPX800Output output)
        {
            if (output.IsVirtual)
            {
                return new SetVirtualOutHttpCommandBuilder();
            }
            else
            {
                return new SetOutHttpCommandBuilder();
            }
        }

        public IGetOutCommandBuilder GetGetOutputCommandBuilder(Context context, IPX800Output output)
        {
            if (output.IsVirtual)
            {
                return new GetVirtualOutHttpCommandBuilder();
            }
            else
            {
                return new GetOutHttpCommandBuilder();
            }
        }

        public IGetInCommandBuilder GetGetInputCommandBuilder(Context context, IPX800Input input)
        {
            if (input.IsVirtual)
            {
                switch (input.Type)
                {
                    case InputType.VirtualAnalogInput:
                        return new GetVirtualAnalogInputHttpCommandBuilder();
                    case InputType.VirtualDigitalInput:
                        return new GetVirtualInHttpCommandBuilder();
                }
            }
            else
            {
                switch (input.Type)
                {
                    case InputType.AnalogInput:
                        return new GetAnalogInputHttpCommandBuilder();
                    case InputType.DigitalInput:
                        return new GetInHttpCommandBuilder();
                }
            }

            throw new IPX800CommandException("Corresponding command builder not found");
        }
    }
}