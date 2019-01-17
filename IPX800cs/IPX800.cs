using System;
using software.elendil.IPX800.Commands.Builders;
using software.elendil.IPX800.Commands.Senders;
using software.elendil.IPX800.ipx800csV1.Exceptions;
using software.elendil.IPX800.IO;
using software.elendil.IPX800.Parsers;
using software.elendil.IPX800.Version;
using IPX800ConnectionException = software.elendil.IPX800.Exceptions.IPX800ConnectionException;
using IPX800Exception = software.elendil.IPX800.Exceptions.IPX800Exception;

namespace software.elendil.IPX800
{
    public class IPX800 : IIPX800v4
    {
        private readonly Context context;
        private readonly ICommandBuilderFactory commandBuilderFactory;
        private readonly ICommandSender commandSender;
        private readonly IResponseParserFactory responseParserFactory;

        public IPX800()
        {
            context = new Context("192.168.1.130", 9870, IPX800Protocol.M2M, IPX800Version.V4, "", "");
            commandBuilderFactory = new CommandBuilderFactory();
            ICommandSenderFactory commandSenderFactory = new CommandSenderFactory();
            commandSender = commandSenderFactory.GetCommandSender(context);
            responseParserFactory = new ResponseParserFactory();
        }

        public InputState GetIn(int inputNumber)
        {
            var input = new IPX800Input
            {
                IsVirtual = false,
                Number = inputNumber,
                Type = InputType.DigitalInput
            };

            try
            {
                IGetInCommandBuilder commandBuilder = commandBuilderFactory.GetGetInputCommandBuilder(context, input);
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