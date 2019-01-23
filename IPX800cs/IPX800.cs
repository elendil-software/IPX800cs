using System;
using software.elendil.IPX800.Commands.Builders;
using software.elendil.IPX800.Commands.Senders;
using software.elendil.IPX800.IO;
using software.elendil.IPX800.Parsers;
using IPX800Exception = software.elendil.IPX800.Exceptions.IPX800Exception;

namespace software.elendil.IPX800
{
    public class IPX800 : IIPX800v4
    {
        private readonly Context context;
        private readonly ICommandBuilderFactory commandBuilderFactory;
        private readonly ICommandSender commandSender;
        private readonly IResponseParserFactory responseParserFactory;

        public IPX800(Context context)
        {
            this.context = context;
            commandBuilderFactory = new CommandBuilderFactoryProvider().GetCommandBuilderFactory(context);
            commandSender = new CommandSenderFactory().GetCommandSender(context);
            responseParserFactory = new ResponseParserFactory();
        }

        public InputState GetIn(int inputNumber)
        {
            var input = new Input
            {
                Number = inputNumber,
                Type = InputType.DigitalInput
            };

            try
            {
                IGetInputCommandBuilder commandBuilder = commandBuilderFactory.GetGetInputCommandBuilder(context, input);
                var command = commandBuilder.BuildCommandString(input);

                var response = commandSender.ExecuteCommand(command);
                InputState result = responseParserFactory.GetInputParser(context, input).ParseResponse(response, inputNumber);
                return result;
            }
            catch (Exception e) when (!(e is IPX800Exception))
            {
                throw new IPX800Exception(e.Message, e);
            }
        }

        public OutputState GetOut(int outputNumber)
        {
            throw new NotImplementedException();
        }

        public string SetOut(int outputNumber, OutputState state, bool fugitive)
        {
            throw new NotImplementedException();
        }

        public string GetAn(int inputNumber)
        {
            throw new NotImplementedException();
        }

        public InputState GetVirtualIn(int inputNumber)
        {
            throw new NotImplementedException();
        }

        public OutputState GetVirtualOut(int outputNumber)
        {
            throw new NotImplementedException();
        }

        public string SetVirtualOut(int outputNumber, OutputState state, bool fugitive)
        {
            throw new NotImplementedException();
        }

        public string GetVirtualAn(int inputNumber)
        {
            throw new NotImplementedException();
        }
    }
}