using software.elendil.IPX800.Commands.Builders.v3.Http;
using software.elendil.IPX800.Commands.Builders.v3.Legacy.Http;
using software.elendil.IPX800.Exceptions;
using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v3
{
    public class V3HttpCommandBuilderFactory : ICommandBuilderFactory
    {
        public ISetCommandBuilder GetSetOutCommandBuilder(Context context, IPX800Output output)
        {
            return new SetOutHttpCommandBuilder();
        }

        public IGetOutCommandBuilder GetGetOutputCommandBuilder(Context context, IPX800Output output)
        {
            if (IsLegacy(context.FirmwareVersion))
            {
                return new GetOutHttpLegacyCommandBuilder();
            }
            else
            {
                return new GetOutHttpCommandBuilder();
            }
        }

        public IGetInCommandBuilder GetGetInputCommandBuilder(Context context, IPX800Input input)
        {
            switch (input.Type)
            {
                case InputType.AnalogInput:
                    return IsLegacy(context.FirmwareVersion) ? (IGetInCommandBuilder) new GetAnalogInputHttpLegacyCommandBuilder() : new GetAnalogInputHttpCommandBuilder();
                case InputType.DigitalInput:
                    return IsLegacy(context.FirmwareVersion) ? (IGetInCommandBuilder) new GetInHttpLegacyCommandBuilder() : new GetInHttpCommandBuilder();
            }

            throw new IPX800CommandException("Corresponding command builder not found");
        }

        private bool IsLegacy(System.Version version)
        {
            var version30542 = new System.Version("3.05.42");
            return version.CompareTo(version30542) < 0;
        }
    }
}