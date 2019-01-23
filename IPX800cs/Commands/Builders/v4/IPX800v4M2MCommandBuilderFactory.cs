using software.elendil.IPX800.Commands.Builders.v4.M2M;
using software.elendil.IPX800.Exceptions;
using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v4
{
    public class IPX800v4M2MCommandBuilderFactory : ICommandBuilderFactory
    {
        public ISetOutputCommandBuilder GetSetOutCommandBuilder(Context context, IPX800Output output)
        {
            if (output.IsVirtual)
            {
                return new Ipx800V4SetOutputVirtualOutputM2MCommandBuilder();
            }
            else
            {
                return new Ipx800V4SetOutputOutputM2MCommandBuilder();
            }
        }

        public IGetOutputCommandBuilder GetGetOutputCommandBuilder(Context context, IPX800Output output)
        {
            if (output.IsVirtual)
            {
                return new IPX800v4GetVirtualOutputM2MCommandBuilder();
            }
            else
            {
                return new IPX800v4GetOutputM2MCommandBuilder();
            }
        }

        public IGetInputCommandBuilder GetGetInputCommandBuilder(Context context, IPX800Input input)
        {
            if (input.IsVirtual)
            {
                switch (input.Type)
                {
                    case InputType.VirtualAnalogInput:
                        return new IPX800v4GetVirtualAnalogInputM2MCommandBuilder();
                    case InputType.VirtualDigitalInput:
                        return new IPX800v4GetVirtualInputM2MCommandBuilder();
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