using software.elendil.IPX800.Commands.Builders.v4.M2M;
using software.elendil.IPX800.Exceptions;
using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v4
{
    public class V4M2MCommandBuilderFactory : ICommandBuilderFactory
    {
        public ISetCommandBuilder GetSetOutCommandBuilder(Context context, IPX800Output output)
        {
            if (output.IsVirtual)
            {
                return new SetVirtualOutCommandBuilder();
            }
            else
            {
                return new SetOutCommandBuilder();
            }
        }

        public IGetOutCommandBuilder GetGetOutputCommandBuilder(Context context, IPX800Output output)
        {
            if (output.IsVirtual)
            {
                return new GetVirtualOutCommandBuilder();
            }
            else
            {
                return new GetOutCommandBuilder();
            }
        }

        public IGetInCommandBuilder GetGetInputCommandBuilder(Context context, IPX800Input input)
        {
            if (input.IsVirtual)
            {
                switch (input.Type)
                {
                    case InputType.VirtualAnalogInput:
                        return new GetVirtualAnalogInputCommandBuilder();
                    case InputType.VirtualDigitalInput:
                        return new GetVirtualInCommandBuilder();
                }
            }
            else
            {
                switch (input.Type)
                {
                    case InputType.AnalogInput:
                        return new IPX800v4GetAnalogInputM2MCommandBuilder();
                    case InputType.DigitalInput:
                        return new IPX800v4GetInputM2MCommandBuilder();
                }
            }

            throw new IPX800CommandException("Corresponding command builder not found");
        }
    }
}