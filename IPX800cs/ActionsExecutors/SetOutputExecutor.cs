using IPX800cs.Commands.Builders;
using IPX800cs.Commands.Senders;
using IPX800cs.IO;
using IPX800cs.Parsers;

namespace IPX800cs.ActionsExecutors
{
    internal class SetOutputExecutor : ISetOutputExecutor
    {
        private readonly Context _context;
        private readonly ICommandBuilderFactory _commandBuilderFactory;
        private readonly ICommandSender _commandSender;
        private readonly IResponseParserFactory _responseParserFactory;

        public SetOutputExecutor(Context context)
        {
            _context = context;
            _commandBuilderFactory = new CommandBuilderFactoryProvider().GetCommandBuilderFactory(context);
            _commandSender = new CommandSenderFactory().GetCommandSender(context);
            _responseParserFactory = new ResponseParserFactoryProvider().GetResponseParserFactory(context);
        }
        
        public bool Execute(Output output)
        {
            ISetOutputCommandBuilder commandBuilder = _commandBuilderFactory.GetSetOutputCommandBuilder(_context, output);
            string command = commandBuilder.BuildCommandString(output);

            string response = _commandSender.ExecuteCommand(command);
            bool result = _responseParserFactory.GetSetOutputParser(_context, output).ParseResponse(response);
            return result;
        }
    }
}