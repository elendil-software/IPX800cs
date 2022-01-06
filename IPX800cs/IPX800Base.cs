using System;
using System.Collections.Generic;
using IPX800cs.Commands.Builders;
using IPX800cs.Commands.Senders;
using IPX800cs.IO;
using IPX800cs.Parsers;

namespace IPX800cs;

public abstract class IPX800Base : IIPX800
{
    protected readonly IPX800Protocol _protocol;
    protected readonly ICommandFactory _commandFactory;
    protected readonly ICommandSender _commandSender;
    protected readonly IResponseParserFactory _responseParserFactory;

    protected IPX800Base(IPX800Protocol protocol, ICommandFactory commandFactory, ICommandSender commandSender, IResponseParserFactory responseParserFactory)
    {
        _protocol = protocol;
        _commandFactory = commandFactory ?? throw new ArgumentNullException(nameof(commandFactory));
        _commandSender = commandSender ?? throw new ArgumentNullException(nameof(commandSender));
        _responseParserFactory = responseParserFactory ?? throw new ArgumentNullException(nameof(responseParserFactory));
    }

    public InputState GetInput(Input input)
    {
        var command = _commandFactory.CreateGetInputCommand(input);
        var response = _commandSender.ExecuteCommand(command);
        return _responseParserFactory.GetInputParser(_protocol, input.Type).ParseResponse(response, input.Number);
    }

    public virtual IEnumerable<InputResponse> GetInputs(InputType input)
    {
        var command = _commandFactory.CreateGetInputsCommand(input);
        var response = _commandSender.ExecuteCommand(command);
        return _responseParserFactory.GetInputsParser(_protocol, input).ParseResponse(response);
    }

    public int GetAnalogInput(AnalogInput input)
    {
        var command = _commandFactory.CreateGetAnalogInputCommand(input);
        var response = _commandSender.ExecuteCommand(command);
        return _responseParserFactory.GetAnalogInputParser(_protocol, input.Type).ParseResponse(response, input.Number);
    }

    public virtual IEnumerable<AnalogInputResponse> GetAnalogInputs(AnalogInputType inputType)
    {
        var command = _commandFactory.CreateGetAnalogInputsCommand(inputType);
        var response = _commandSender.ExecuteCommand(command);
        return _responseParserFactory.GetAnalogInputsParser(_protocol, inputType).ParseResponse(response);
    }

    public OutputState GetOutput(Output output)
    {
        var command = _commandFactory.CreateGetOutputCommand(output);
        var response = _commandSender.ExecuteCommand(command);
        return _responseParserFactory.GetOutputParser(_protocol, output.Type).ParseResponse(response, output.Number);
    }

    public virtual IEnumerable<OutputResponse> GetOutputs(OutputType outputType)
    {
        var command = _commandFactory.CreateGetOutputsCommand(outputType);
        var response = _commandSender.ExecuteCommand(command);
        return _responseParserFactory.GetOutputsParser(_protocol, outputType).ParseResponse(response);
    }

    public bool SetOutput(Output output)
    {
        var command = _commandFactory.CreateSetOutputCommand(output);
        var response = _commandSender.ExecuteCommand(command);
        return _responseParserFactory.GetSetOutputParser(_protocol).ParseResponse(response);
    }
}