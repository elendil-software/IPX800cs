using IPX800cs.Commands.Builders;
using IPX800cs.Commands.Senders;
using IPX800cs.Parsers;

namespace IPX800cs;

/// <summary>
/// Represent an IPX800 V4 device
///
/// Use the <see cref="IPX800Factory"/> to create an instance of this class
/// </summary>
public sealed class IPX800V4 : IPX800Base
{
    internal IPX800V4(IPX800Protocol protocol, ICommandFactory commandFactory, ICommandSender commandSender, IResponseParserFactory responseParserFactory) : 
        base(protocol, commandFactory, commandSender, responseParserFactory)
    {
    }
}