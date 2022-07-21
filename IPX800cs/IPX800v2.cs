using System.Collections.Generic;
using IPX800cs.Commands;
using IPX800cs.Commands.Builders;
using IPX800cs.Commands.Senders;
using IPX800cs.IO;
using IPX800cs.Parsers;
#pragma warning disable CS1591

namespace IPX800cs;

/// <summary>
/// Represent an IPX800 V2 device
///
/// Use the <see cref="IPX800Factory"/> to create an instance of this class
/// </summary>
public sealed class IPX800V2 : IPX800Base
{
    internal IPX800V2(IPX800Protocol protocol, ICommandFactory commandFactory, ICommandSender commandSender, IResponseParserFactory responseParserFactory) : 
        base(protocol, commandFactory, commandSender, responseParserFactory)
    {
    }

    public override IEnumerable<InputResponse> GetInputs(InputType inputType)
    {
        return Protocol == IPX800Protocol.Http ? GetHttpInputs(inputType) : GetM2MInputs(inputType);
    }

    private IEnumerable<InputResponse> GetHttpInputs(InputType inputType)
    {
        Command command = CommandFactory.CreateGetInputsCommand(inputType);
        string response = CommandSender.ExecuteCommand(command);
        return ResponseParserFactory.CreateGetInputsParser(Protocol, inputType).ParseResponse(response);
    }
    
    private List<InputResponse> GetM2MInputs(InputType inputType)
    {
        IGetInputResponseParser parser = ResponseParserFactory.CreateGetInputParser(Protocol, inputType);
        var result = new List<InputResponse>();
        
        for (int i = 1; i <= 4; i++)
        {
            var input = new Input { Number = i, Type = inputType };
            Command command = CommandFactory.CreateGetInputCommand(input);
            string response = CommandSender.ExecuteCommand(command);

            result.Add(new InputResponse
            {
                Name = $"Input {i}",
                Number = i,
                Type = inputType,
                State = parser.ParseResponse(response, i)
            });
        }

        return result;
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
        
        for (int i = 1; i <= 2; i++)
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
        
    public override IEnumerable<OutputResponse> GetOutputs(OutputType inputType)
    {
        return Protocol == IPX800Protocol.Http ? GetHttpOutputs(inputType) : GetM2MOutputs(inputType);
    }

    private IEnumerable<OutputResponse> GetHttpOutputs(OutputType inputType)
    {
        Command command = CommandFactory.CreateGetOutputsCommand(inputType);
        string response = CommandSender.ExecuteCommand(command);
        return ResponseParserFactory.CreateGetOutputsParser(Protocol, inputType).ParseResponse(response);
    }
    
    private List<OutputResponse> GetM2MOutputs(OutputType inputType)
    {
        IGetOutputResponseParser parser = ResponseParserFactory.CreateGetOutputParser(Protocol, inputType);
        var result = new List<OutputResponse>();
        
        for (int i = 1; i <= 8; i++)
        {
            var input = new Output { Number = i, Type = inputType };
            Command command = CommandFactory.CreateGetOutputCommand(input);
            string response = CommandSender.ExecuteCommand(command);

            result.Add(new OutputResponse
            {
                Name = $"Output {i}",
                Number = i,
                Type = inputType,
                State = parser.ParseResponse(response, i)
            });
        }

        return result;
    }
}