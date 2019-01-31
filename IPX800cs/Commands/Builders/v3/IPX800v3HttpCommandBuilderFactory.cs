using software.elendil.IPX800.Commands.Builders.v3.Http;
using software.elendil.IPX800.Commands.Builders.v3.Legacy.Http;
using software.elendil.IPX800.Exceptions;
using software.elendil.IPX800.IO;
using software.elendil.IPX800.Version;

namespace software.elendil.IPX800.Commands.Builders.v3
{
    public class IPX800v3HttpCommandBuilderFactory : ICommandBuilderFactory
    {
        public ISetOutputCommandBuilder GetSetOutputCommandBuilder(Context context, Output output)
        {
            if (output.Type == OutputType.Output)
            {
                return new IPX800v3SetOutputHttpCommandBuilder();
            }
            
            throw new IPX800InvalidContextException($"Output type '{output.Type}' is not valid");
        }

        public IGetOutputCommandBuilder GetGetOutputCommandBuilder(Context context, Output output)
        {
            if (output.Type != OutputType.Output)
            {
                throw new IPX800InvalidContextException($"Output type '{output.Type}' is not valid");
            }

            if (VersionChecker.IsLegacy(context.FirmwareVersion))
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
                    return VersionChecker.IsLegacy(context.FirmwareVersion) ? (IGetInputCommandBuilder) new IPX800v3LegacyGetAnalogInputHttpCommandBuilder() : new IPX800v3GetAnalogInputHttpCommandBuilder();

                case InputType.DigitalInput:
                    return VersionChecker.IsLegacy(context.FirmwareVersion) ? (IGetInputCommandBuilder) new IPX800v3LegacyGetInputHttpCommandBuilder() : new IPX800v3GetInputHttpCommandBuilder();

                default:
                    throw new IPX800InvalidContextException($"Input type '{input.Type}' is not valid");
            }
        }

        public IGetVersionCommandBuilder GetGetVersionCommandBuilder(Context context)
        {
            if (VersionChecker.IsLegacy(context.FirmwareVersion))
            {
                return new IPX800v3LegacyGetVersionHttpCommandBuilder();
            }
            else
            {
                return new IPX800v3GetVersionHttpCommandBuilder();
            }
        }
    }
}