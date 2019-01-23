using software.elendil.IPX800.Commands.Builders.v3.Http;
using software.elendil.IPX800.Commands.Builders.v3.Legacy.Http;
using software.elendil.IPX800.Exceptions;
using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v3
{
    public class IPX800v3HttpCommandBuilderFactory : ICommandBuilderFactory
    {
        public ISetOutputCommandBuilder GetSetOutCommandBuilder(Context context, Output output)
        {
            return new Ipx800V3SetOutputOutputHttpCommandBuilder();
        }

        public IGetOutputCommandBuilder GetGetOutputCommandBuilder(Context context, Output output)
        {
            if (IsLegacy(context.FirmwareVersion))
            {
                return new IPX800v3LegacyGetOutputHttpCommandBuilder();
            }
            else
            {
                return new IPX800v3GetOutputHttpCommandBuilder();
            }
        }

        public IGetInputCommandBuilder GetGetInputCommandBuilder(Context context, Input input)
        {
            switch (input.Type)
            {
                case InputType.AnalogInput:
                    return IsLegacy(context.FirmwareVersion) ? (IGetInputCommandBuilder) new IPX800v3LegacyGetAnalogInputHttpCommandBuilder() : new IPX800v3GetAnalogInputHttpCommandBuilder();
                case InputType.DigitalInput:
                    return IsLegacy(context.FirmwareVersion) ? (IGetInputCommandBuilder) new IPX800v3LegacyGetInputHttpCommandBuilder() : new IPX800v3GetInputHttpCommandBuilder();
            }

            throw new IPX800CommandException("Corresponding command builder not found");
        }

        private bool IsLegacy(System.Version version)
        {
            if (version == null)
            {
                return false;
            }

            var version30542 = new System.Version("3.05.42");
            return version.CompareTo(version30542) < 0;
        }
    }
}