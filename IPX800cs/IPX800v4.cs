using IPX800cs.Commands.Builders;
using IPX800cs.Commands.Senders;
using IPX800cs.Parsers;

namespace IPX800cs;

public class IPX800V4 : IPX800Base
{
    internal IPX800V4(IPX800Protocol protocol, ICommandFactory commandFactory, ICommandSender commandSender, IResponseParserFactory responseParserFactory) : 
        base(protocol, commandFactory, commandSender, responseParserFactory)
    {
    }
}