using IPX800cs.IO;
using IPX800cs.Version;

namespace IPX800cs.Exceptions;

internal static class ExceptionHelper
{
    public static IPX800NotSupportedCommandException ThrowNotSupportedException(this IPX800Protocol protocol, IPX800Version version)
    {
        return new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 {version}");
    }
    
    public static IPX800NotSupportedCommandException ThrowNotSupportedException(this InputType inputType, IPX800Version version)
    {
        return new IPX800NotSupportedCommandException($"Input type '{inputType}' is not supported by IPX800 {version}");
    }
    
    public static IPX800NotSupportedCommandException ThrowNotSupportedException(this AnalogInputType analogInputType, IPX800Version version)
    {
        return new IPX800NotSupportedCommandException($"Analog Input type '{analogInputType}' is not supported by IPX800 {version}");
    }
    
    public static IPX800NotSupportedCommandException ThrowNotSupportedException(this OutputType outputType, IPX800Version version)
    {
        return new IPX800NotSupportedCommandException($"Output type '{outputType}' is not supported by IPX800 {version}");
    }
}