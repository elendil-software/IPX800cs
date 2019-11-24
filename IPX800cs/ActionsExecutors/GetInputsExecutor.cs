using System.Collections.Generic;
using IPX800cs.Commands.Builders;
using IPX800cs.Commands.Senders;
using IPX800cs.IO;
using IPX800cs.Parsers;

namespace IPX800cs.ActionsExecutors
{
    internal class GetInputsExecutor : IGetInputsExecutor
    {
        private readonly Context _context;
        private readonly ICommandBuilderFactory _commandBuilderFactory;
        private readonly ICommandSender _commandSender;
        private readonly IResponseParserFactory _responseParserFactory;

        public GetInputsExecutor(Context context)
        {
            _context = context;
            _commandBuilderFactory = new CommandBuilderFactoryProvider().GetCommandBuilderFactory(context);
            _commandSender = new CommandSenderFactory().GetCommandSender(context);
            _responseParserFactory = new ResponseParserFactoryProvider().GetResponseParserFactory(context);
        }
        
        public Dictionary<int, InputState> Execute(Input input)
        {
            IGetInputsCommandBuilder commandBuilder = _commandBuilderFactory.GetGetInputsCommandBuilder(_context, input);
            string command = commandBuilder.BuildCommandString();

            string response = _commandSender.ExecuteCommand(command);
            Dictionary<int, InputState> result = _responseParserFactory.GetInputsParser(_context, input).ParseResponse(response);
            return result;
        }
    }
}