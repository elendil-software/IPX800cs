using System.Collections.Generic;
using System.Linq;
using IPX800cs.Commands;
using IPX800cs.Commands.Builders.v5;
using IPX800cs.Commands.Senders;
using IPX800cs.IO;
using IPX800cs.Parsers.v5;
#pragma warning disable CS1591

namespace IPX800cs;

/// <summary>
/// Represent an IPX800 V5 device
///
/// Use the <see cref="IPX800Factory"/> to create an instance of this class
/// </summary>
public sealed class IPX800V5 : IPX800Base
{
    private readonly IIPX800V5CommandFactory _ipx800V5CommandFactory;
    private readonly IIPX800V5ResponseParserFactory _ipx800V5ResponseParserFactory;
    
    internal IPX800V5(IPX800Protocol protocol, IIPX800V5CommandFactory commandFactory, ICommandSender commandSender, IIPX800V5ResponseParserFactory responseParserFactory) : 
        base(protocol, commandFactory, commandSender, responseParserFactory)
    {
        _ipx800V5CommandFactory = commandFactory;
        _ipx800V5ResponseParserFactory = responseParserFactory;
    }

    public override OutputState GetOutput(Output output)
    {
        if (output.Type is OutputType.DelayedOutput or OutputType.DelayedOpenCollectorOutput)
        {
            IList<OutputResponseIPX800V5> outputs = base.GetOutputs(output.Type).Cast<OutputResponseIPX800V5>().ToList();

            OutputResponseIPX800V5 tempoStart = outputs.Single(io => io.Number == output.Number);
            OutputResponseIPX800V5 tempoOutput = outputs.Single(io => io.Link0 == tempoStart.Link1);
            OutputResponseIPX800V5 foundOutput = outputs.First(io => io.Link0 == tempoOutput.Link1);
            return foundOutput.State;
        }
        
        return base.GetOutput(output);
    }


    public override IEnumerable<OutputResponse> GetOutputs(OutputType outputType)
    {
        IList<OutputResponse> outputs = base.GetOutputs(outputType).ToList();

        if (outputType != OutputType.DelayedOutput && outputType != OutputType.DelayedOpenCollectorOutput)
        {
            return outputs;
        }

        IList<TimerResponse> tempos = GetTimers().ToList();
        if (!tempos.Any())
        {
            return new List<OutputResponse>();
        }

        List<int> ioIds = IPX800V5Const.IOIds[outputType];
        IList<OutputResponseIPX800V5> ioIpx800V5 = outputs.Cast<OutputResponseIPX800V5>().ToList();
        
        IEnumerable<int> relaysLink = ioIpx800V5.Where(o => o.Link0 > 0 && o.Number >= ioIds[0] && o.Number <= ioIds[1]).Select(o => o.Link0).Distinct();
        IEnumerable<int> potentialTempoOutputsLinks = ioIpx800V5.Where(io => relaysLink.Contains(io.Link1)).Select(io => io.Link0).Distinct();
        IEnumerable<int> potentialTempoStartIds = ioIpx800V5.Where(io => potentialTempoOutputsLinks.Contains(io.Link1) && io.Name.EndsWith("Start")).Select(io => io.Number).Distinct();
        IEnumerable<TimerResponse> delayedOutputs = tempos.Where(t => potentialTempoStartIds.Contains(t.IoStartId));

        return delayedOutputs.Select(delayedOutput => new OutputResponse
        {
            Type = outputType, 
            State = ioIpx800V5.First(o => o.Link0 == ioIpx800V5.First(t => t.Number == delayedOutput.IoOutId).Link1).State, 
            Number = delayedOutput.IoStartId, 
            Name = delayedOutput.Name
        }).ToList();
    }

    private IEnumerable<TimerResponse> GetTimers()
    {
        Command command = _ipx800V5CommandFactory.CreateGetTimersCommand();
        string response = CommandSender.ExecuteCommand(command);
        return _ipx800V5ResponseParserFactory.CreateGetTimersParser().ParseResponse(response);
    }
}