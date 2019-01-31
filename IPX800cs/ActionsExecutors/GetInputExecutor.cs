using software.elendil.IPX800.Commands.Builders;
using software.elendil.IPX800.Commands.Senders;
using software.elendil.IPX800.IO;
using software.elendil.IPX800.Parsers;

namespace software.elendil.IPX800.ActionsExecutors
{
    public class GetInputExecutor
    {
        private readonly Context _context;
        private readonly ICommandBuilderFactory _commandBuilderFactory;
        private readonly ICommandSender _commandSender;
        private readonly IResponseParserFactory _responseParserFactory;

        public GetInputExecutor(Context context)
        {
            _context = context;
            _commandBuilderFactory = new CommandBuilderFactoryProvider().GetCommandBuilderFactory(context);
            _commandSender = new CommandSenderFactory().GetCommandSender(context);
            _responseParserFactory = new ResponseParserFactoryProvider().GetResponseParserFactory(context);
        }
        
        public InputState Execute(Input input)
        {
            IGetInputCommandBuilder commandBuilder = _commandBuilderFactory.GetGetInputCommandBuilder(_context, input);
            string command = commandBuilder.BuildCommandString(input);

            string response = _commandSender.ExecuteCommand(command);
            InputState result = _responseParserFactory.GetInputParser(_context, input).ParseResponse(response, input.Number);
            return result;
        }
    }
}