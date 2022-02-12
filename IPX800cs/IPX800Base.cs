using System;
using System.Collections.Generic;
using IPX800cs.Commands.Builders;
using IPX800cs.Commands.Senders;
using IPX800cs.IO;
using IPX800cs.Parsers;

namespace IPX800cs;

public abstract class IPX800Base : IIPX800, IDisposable
{
    protected readonly IPX800Protocol Protocol;
    protected readonly ICommandFactory CommandFactory;
    protected readonly ICommandSender CommandSender;
    protected readonly IResponseParserFactory ResponseParserFactory;

    protected IPX800Base(IPX800Protocol protocol, ICommandFactory commandFactory, ICommandSender commandSender, IResponseParserFactory responseParserFactory)
    {
        Protocol = protocol;
        CommandFactory = commandFactory ?? throw new ArgumentNullException(nameof(commandFactory));
        CommandSender = commandSender ?? throw new ArgumentNullException(nameof(commandSender));
        ResponseParserFactory = responseParserFactory ?? throw new ArgumentNullException(nameof(responseParserFactory));
    }

    public InputState GetInput(Input input)
    {
        var command = CommandFactory.CreateGetInputCommand(input);
        var response = CommandSender.ExecuteCommand(command);
        return ResponseParserFactory.CreateGetInputParser(Protocol, input.Type).ParseResponse(response, input.Number);
    }

    public virtual IEnumerable<InputResponse> GetInputs(InputType inputType)
    {
        var command = CommandFactory.CreateGetInputsCommand(inputType);
        var response = CommandSender.ExecuteCommand(command);
        return ResponseParserFactory.CreateGetInputsParser(Protocol, inputType).ParseResponse(response);
    }

    public double GetAnalogInput(AnalogInput input)
    {
        var command = CommandFactory.CreateGetAnalogInputCommand(input);
        var response = CommandSender.ExecuteCommand(command);
        return ResponseParserFactory.CreateGetAnalogInputParser(Protocol, input.Type).ParseResponse(response, input.Number);
    }

    public virtual IEnumerable<AnalogInputResponse> GetAnalogInputs(AnalogInputType inputType)
    {
        var command = CommandFactory.CreateGetAnalogInputsCommand(inputType);
        var response = CommandSender.ExecuteCommand(command);
        return ResponseParserFactory.CreateGetAnalogInputsParser(Protocol, inputType).ParseResponse(response);
    }

    public virtual OutputState GetOutput(Output output)
    {
        var command = CommandFactory.CreateGetOutputCommand(output);
        var response = CommandSender.ExecuteCommand(command);
        return ResponseParserFactory.CreateGetOutputParser(Protocol, output.Type).ParseResponse(response, output.Number);
    }

    public virtual IEnumerable<OutputResponse> GetOutputs(OutputType outputType)
    {
        var command = CommandFactory.CreateGetOutputsCommand(outputType);
        var response = CommandSender.ExecuteCommand(command);
        return ResponseParserFactory.CreateGetOutputsParser(Protocol, outputType).ParseResponse(response);
    }

    public bool SetOutput(Output output)
    {
        var command = CommandFactory.CreateSetOutputCommand(output);
        var response = CommandSender.ExecuteCommand(command);
        return ResponseParserFactory.CreateSetOutputParser(Protocol).ParseResponse(response);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            CommandSender?.Dispose();
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}