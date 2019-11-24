using System.Collections.Generic;
using IPX800cs.Commands.Builders;
using IPX800cs.Commands.Senders;
using IPX800cs.IO;
using IPX800cs.Parsers;

namespace IPX800cs.ActionsExecutors
{
    internal class GetOutputsExecutor : IGetOutputsExecutor
    {
        private readonly Context _context;
        private readonly ICommandBuilderFactory _commandBuilderFactory;
        private readonly ICommandSender _commandSender;
        private readonly IResponseParserFactory _responseParserFactory;

        public GetOutputsExecutor(Context context)
        {
            _context = context;
            _commandBuilderFactory = new CommandBuilderFactoryProvider().GetCommandBuilderFactory(context);
            _commandSender = new CommandSenderFactory().GetCommandSender(context);
            _responseParserFactory = new ResponseParserFactoryProvider().GetResponseParserFactory(context);
        }
        
        public Dictionary<int, OutputState> Execute(Output output)
        {
            IGetOutputsCommandBuilder commandBuilder = _commandBuilderFactory.GetGetOutputsCommandBuilder(_context, output);
            string command = commandBuilder.BuildCommandString();

            string response = _commandSender.ExecuteCommand(command);
            Dictionary<int, OutputState> result = _responseParserFactory.GetOutputsParser(_context, output).ParseResponse(response);
            return result;
        }
    }
}