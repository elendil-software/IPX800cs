using software.elendil.IPX800.Commands.Builders.v2;
using software.elendil.IPX800.Commands.Builders.v3;
using software.elendil.IPX800.Commands.Builders.v4;
using software.elendil.IPX800.Exceptions;
using software.elendil.IPX800.Version;

namespace software.elendil.IPX800.Commands.Builders
{
    internal class CommandBuilderFactoryProvider : ICommandBuilderFactoryProvider
    {
        public ICommandBuilderFactory GetCommandBuilderFactory(Context context)
        {
            switch (context.Version)
            {
                case IPX800Version.V2:
                    return GetIPX800v2CommandBuilderFactory(context);
                
                case IPX800Version.V3:
                    return GetIPX800v3CommandBuilderFactory(context);
                
                case IPX800Version.V4:
                    return GetIPX800v4CommandBuilderFactory(context);
                
                default:
                    throw new IPX800UnknownVersionException($"Version '{context.Version}' is not a valid IPX800 version");
            }
        }

        private ICommandBuilderFactory GetIPX800v2CommandBuilderFactory(Context context)
        {
            if (context.Protocol == IPX800Protocol.Http)
            {
                return new IPX800v2HttpCommandBuilderFactory();
            }
            else
            {
                return new IPX800v2M2MCommandBuilderFactory();
            }
        }
        
        private ICommandBuilderFactory GetIPX800v3CommandBuilderFactory(Context context)
        {
            if (context.Protocol == IPX800Protocol.Http)
            {
                return new IPX800v3HttpCommandBuilderFactory();
            }
            else
            {
                return new IPX800v3M2MCommandBuilderFactory();
            }
        }
        
        private ICommandBuilderFactory GetIPX800v4CommandBuilderFactory(Context context)
        {
            if (context.Protocol == IPX800Protocol.Http)
            {
                return new IPX800v4HttpCommandBuilderFactory();
            }
            else
            {
                return new IPX800v4M2MCommandBuilderFactory();
            }
        }
    }
}