using software.elendil.IPX800.Exceptions;
using software.elendil.IPX800.IO;
using software.elendil.IPX800.Parsers.v3.Http;
using software.elendil.IPX800.Parsers.v3.Legacy.M2M;
using software.elendil.IPX800.Parsers.v3.M2M;
using software.elendil.IPX800.Version;

namespace software.elendil.IPX800.Parsers.v3
{
    public class IPX800v3ResponseParserFactory : IResponseParserFactory
    {
        public IGetVersionResponseParser GetVersionResponseParser(Context context)
        {
            switch (context.Protocol)
            {
                case IPX800Protocol.Http:
                    return new IPX800v3GetVersionHttpResponseParser();
                
                case IPX800Protocol.M2M:
                    if (VersionChecker.IsLegacy(context.FirmwareVersion))
                    {
                        return new IPX800v3LegacyGetVersionM2MResponseParser();
                    }
                    else
                    {
                        return new IPX800v3GetVersionM2MResponseParser();
                    }

                default:
                    throw new IPX800InvalidContextException($"'{context.Protocol}' is not a valid protocol");
            }
        }

        public IAnalogInputResponseParser GetAnalogInputParser(Context context, Input input)
        {
            switch (context.Protocol)
            {
                case IPX800Protocol.Http:
                    return new IPX800v3GetAnalogInputHttpResponseParser();
                
                case IPX800Protocol.M2M:
                    if (VersionChecker.IsLegacy(context.FirmwareVersion))
                    {
                        return new IPX800v3LegacyGetAnalogInputM2MResponseParser();
                    }
                    else
                    {
                        return new IPX800v3GetAnalogInputM2MResponseParser();
                    }
                
                default:
                    throw new IPX800InvalidContextException($"'{context.Protocol}' is not a valid protocol");
            }
        }

        public IInputResponseParser GetInputParser(Context context, Input input)
        {
            switch (context.Protocol)
            {
                case IPX800Protocol.Http:
                    return new IPX800v3GetInputHttpResponseParser();
                
                case IPX800Protocol.M2M:
                    if (VersionChecker.IsLegacy(context.FirmwareVersion))
                    {
                        return new IPX800v3LegacyGetInputM2MResponseParser();
                    }
                    else
                    {
                        return new IPX800v3GetInputM2MResponseParser();
                    }
                
                default:
                    throw new IPX800InvalidContextException($"'{context.Protocol}' is not a valid protocol");
            }
        }

        public IGetOutputResponseParser GetOutputParser(Context context, Output input)
        {
            switch (context.Protocol)
            {
                case IPX800Protocol.Http:
                    return new IPX800v3GetOutputHttpResponseParser();
                
                case IPX800Protocol.M2M:
                    if (VersionChecker.IsLegacy(context.FirmwareVersion))
                    {
                        return new IPX800v3LegacyGetOutputM2MResponseParser();
                    }
                    else
                    {
                        return new IPX800v3GetOutputM2MResponseParser();
                    }
                    
                default:
                    throw new IPX800InvalidContextException($"'{context.Protocol}' is not a valid protocol");
            }
        }

        public ISetOutputResponseParser GetSetOutputParser(Context context, Output input)
        {
            switch (context.Protocol)
            {
                case IPX800Protocol.Http:
                    return new IPX800v3SetOutputHttpResponseParser();
                
                case IPX800Protocol.M2M:
                    if (VersionChecker.IsLegacy(context.FirmwareVersion))
                    {
                        return new IPX800v3LegacySetOutputM2MResponseParser();
                    }
                    else
                    {
                        return new IPX800v3SetOutputM2MResponseParser();
                    }
                    
                
                default:
                    throw new IPX800InvalidContextException($"'{context.Protocol}' is not a valid protocol");
            }
        }
    }
}