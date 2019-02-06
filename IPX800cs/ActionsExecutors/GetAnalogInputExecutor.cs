using IPX800cs.Commands.Builders;
using IPX800cs.Commands.Senders;
using IPX800cs.IO;
using IPX800cs.Parsers;

namespace IPX800cs.ActionsExecutors
{
    internal class GetAnalogInputExecutor : IGetAnalogInputExecutor
    {
        private readonly Context _context;
        private readonly ICommandBuilderFactory _commandBuilderFactory;
        private readonly ICommandSender _commandSender;
        private readonly IResponseParserFactory _responseParserFactory;

        public GetAnalogInputExecutor(Context context)
        {
            this._context = context;
            _commandBuilderFactory = new CommandBuilderFactoryProvider().GetCommandBuilderFactory(context);
            _commandSender = new CommandSenderFactory().GetCommandSender(context);
            _responseParserFactory = new ResponseParserFactoryProvider().GetResponseParserFactory(context);
        }
        
        public int Execute(Input input)
        {           
            IGetInputCommandBuilder commandBuilder = _commandBuilderFactory.GetGetInputCommandBuilder(_context, input);
            string command = commandBuilder.BuildCommandString(input);

            string response = _commandSender.ExecuteCommand(command);
            int result = _responseParserFactory.GetAnalogInputParser(_context, input).ParseResponse(response, input.Number);
            return result;
        }
    }
}