using IPX800cs.Commands.Builders;
using IPX800cs.Commands.Senders;
using IPX800cs.Parsers;

namespace IPX800cs.ActionsExecutors
{
    internal class GetVersionExecutor : IGetVersionExecutor
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