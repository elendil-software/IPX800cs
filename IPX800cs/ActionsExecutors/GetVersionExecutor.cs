using software.elendil.IPX800.Commands.Builders;
using software.elendil.IPX800.Commands.Senders;
using software.elendil.IPX800.Parsers;

namespace software.elendil.IPX800.ActionsExecutors
{
    internal class GetVersionExecutor
    {
        private readonly Context _context;
        private readonly ICommandBuilderFactory _commandBuilderFactory;
        private readonly ICommandSender _commandSender;
        private readonly IResponseParserFactory _responseParserFactory;

        public GetVersionExecutor(Context context)
        {
            _context = context;
            _commandBuilderFactory = new CommandBuilderFactoryProvider().GetCommandBuilderFactory(context);
            _commandSender = new CommandSenderFactory().GetCommandSender(context);
            _responseParserFactory = new ResponseParserFactoryProvider().GetResponseParserFactory(context);
        }
        
        public System.Version Execute()
        {
            IGetVersionCommandBuilder commandBuilder = _commandBuilderFactory.GetGetVersionCommandBuilder(_context);
            string command = commandBuilder.BuildCommandString();

            string response = _commandSender.ExecuteCommand(command);
            string result = _responseParserFactory.GetVersionResponseParser(_context).ParseResponse(response);
            return new System.Version(result);
        }
    }
}