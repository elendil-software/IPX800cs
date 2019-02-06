using IPX800cs.Commands.Builders;
using IPX800cs.Commands.Senders;
using IPX800cs.IO;
using IPX800cs.Parsers;

namespace IPX800cs.ActionsExecutors
{
    internal class GetOutputExecutor : IGetOutputExecutor
    {
        private readonly Context _context;
        private readonly ICommandBuilderFactory _commandBuilderFactory;
        private readonly ICommandSender _commandSender;
        private readonly IResponseParserFactory _responseParserFactory;

        public GetOutputExecutor(Context context)
        {
            _context = context;
            _commandBuilderFactory = new CommandBuilderFactoryProvider().GetCommandBuilderFactory(context);
            _commandSender = new CommandSenderFactory().GetCommandSender(context);
            _responseParserFactory = new ResponseParserFactoryProvider().GetResponseParserFactory(context);
        }
        
        public OutputState Execute(Output output)
        {
            IGetOutputCommandBuilder commandBuilder = _commandBuilderFactory.GetGetOutputCommandBuilder(_context, output);
            string command = commandBuilder.BuildCommandString(output);

            string response = _commandSender.ExecuteCommand(command);
            OutputState result = _responseParserFactory.GetOutputParser(_context, output).ParseResponse(response, output.Number);
            return result;
        }
    }
}