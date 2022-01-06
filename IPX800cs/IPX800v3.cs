using System;
using System.Collections.Generic;
using IPX800cs.Commands.Builders;
using IPX800cs.Commands.Senders;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers;

namespace IPX800cs;

public class IPX800V3 : IPX800Base
{
    public IPX800V3(IPX800Protocol protocol, ICommandFactory commandFactory, ICommandSender commandSender, IResponseParserFactory responseParserFactory) : 
        base(protocol, commandFactory, commandSender, responseParserFactory)
    {
    }

    public override IEnumerable<AnalogInputResponse> GetAnalogInputs(AnalogInputType inputType)
    {
        return _protocol == IPX800Protocol.Http ? GetHttpAnalogInputs(inputType) : GetM2MAnalogInputs(inputType);
    }

    private IEnumerable<AnalogInputResponse> GetHttpAnalogInputs(AnalogInputType inputType)
    {
        string command = _commandFactory.CreateGetAnalogInputsCommand(inputType);
        string response = _commandSender.ExecuteCommand(command);
        return _responseParserFactory.GetAnalogInputsParser(_protocol, inputType).ParseResponse(response);
    }
    
    private List<AnalogInputResponse> GetM2MAnalogInputs(AnalogInputType inputType)
    {
        IAnalogInputResponseParser parser = _responseParserFactory.GetAnalogInputParser(_protocol, inputType);
        var result = new List<AnalogInputResponse>();
        
        for (int i = 1; i <= 16; i++)
        {
            var input = new AnalogInput { Number = i, Type = inputType };
            string command = _commandFactory.CreateGetAnalogInputCommand(input);
            string response = _commandSender.ExecuteCommand(command);

            result.Add(new AnalogInputResponse
            {
                Name = $"Analog {i}",
                Number = i,
                Type = inputType,
                Value = parser.ParseResponse(response, i)
            });
        }

        return result;
    }
}