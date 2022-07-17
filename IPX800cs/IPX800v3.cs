using System.Collections.Generic;
using IPX800cs.Commands;
using IPX800cs.Commands.Builders;
using IPX800cs.Commands.Senders;
using IPX800cs.IO;
using IPX800cs.Parsers;

namespace IPX800cs;

public class IPX800V3 : IPX800Base
{
    internal IPX800V3(IPX800Protocol protocol, ICommandFactory commandFactory, ICommandSender commandSender, IResponseParserFactory responseParserFactory) : 
        base(protocol, commandFactory, commandSender, responseParserFactory)
    {
    }

    public override IEnumerable<AnalogInputResponse> GetAnalogInputs(AnalogInputType inputType)
    {
        return Protocol == IPX800Protocol.Http ? GetHttpAnalogInputs(inputType) : GetM2MAnalogInputs(inputType);
    }

    private IEnumerable<AnalogInputResponse> GetHttpAnalogInputs(AnalogInputType inputType)
    {
        Command command = CommandFactory.CreateGetAnalogInputsCommand(inputType);
        string response = CommandSender.ExecuteCommand(command);
        return ResponseParserFactory.CreateGetAnalogInputsParser(Protocol, inputType).ParseResponse(response);
    }
    
    private List<AnalogInputResponse> GetM2MAnalogInputs(AnalogInputType inputType)
    {
        IGetAnalogInputResponseParser parser = ResponseParserFactory.CreateGetAnalogInputParser(Protocol, inputType);
        var result = new List<AnalogInputResponse>();
        
        for (int i = 1; i <= 16; i++)
        {
            var input = new AnalogInput { Number = i, Type = inputType };
            Command command = CommandFactory.CreateGetAnalogInputCommand(input);
            string response = CommandSender.ExecuteCommand(command);

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