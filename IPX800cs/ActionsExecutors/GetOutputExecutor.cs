using software.elendil.IPX800.Commands.Builders;
using software.elendil.IPX800.Commands.Senders;
using software.elendil.IPX800.IO;
using software.elendil.IPX800.Parsers;

namespace software.elendil.IPX800.ActionsExecutors
{
    internal class GetOutputExecutor
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