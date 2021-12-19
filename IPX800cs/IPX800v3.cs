using System.Collections.Generic;
using IPX800cs.Commands.Builders;
using IPX800cs.Commands.Senders;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers;

namespace IPX800cs;

public class IPX800V3 : IPX800Base
{
    public IPX800V3(IPX800Protocol protocol, ICommandFactory commandFactory, ICommandSender commandSender, IResponseParserFactoryNew responseParserFactory) : 
        base(protocol, commandFactory, commandSender, responseParserFactory)
    {
    }

    public override Dictionary<int, int> GetAnalogInputs(InputType inputType)
    {
        throw new IPX800NotSupportedCommandException("GetAnalogInputs is not supported by IPX800 v3");
    }
}