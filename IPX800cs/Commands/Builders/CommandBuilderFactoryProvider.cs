using System;
using software.elendil.IPX800.Exceptions;
using software.elendil.IPX800.Version;

namespace software.elendil.IPX800.Commands.Builders
{
    public class CommandBuilderFactoryProvider : ICommandBuilderFactoryProvider
    {
        public ICommandBuilderFactory GetCommandBuilderFactory(Context context)
        {
            switch (context.Version)
            {
                case IPX800Version.V2:
                    return GetIpx800v2CommandBuilderFactory(context);
                
                case IPX800Version.V3:
                    return GetIpx800v3CommandBuilderFactory(context);
                
                case IPX800Version.V4:
                    return GetIpx800v4CommandBuilderFactory(context);
                
                default:
                    throw new IPX800UnknownVersionException($"Version '{context.Version}' is not a valid IPX800 version");
            }
        }

        private ICommandBuilderFactory GetIpx800v2CommandBuilderFactory(Context context)
        {
            if (context.Protocol == IPX800Protocol.Http)
            {
                return new V4HttpCommandBuilderFactory();
            }
            else
            {
                return new V4M2MCommandBuilderFactory();
            }
        }
        
        private ICommandBuilderFactory GetIpx800v3CommandBuilderFactory(Context context)
        {
            throw new NotImplementedException();
        }
        private ICommandBuilderFactory GetIpx800v4CommandBuilderFactory(Context context)
        {
            throw new NotImplementedException();
        }
    }
}