﻿using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using IPX800cs.Commands;
using IPX800cs.Commands.Builders;
using IPX800cs.Commands.Builders.v5;
using IPX800cs.Commands.Senders;
using IPX800cs.IO;
using IPX800cs.Parsers;
using IPX800cs.Parsers.v5;

namespace IPX800cs;

public class IPX800V5 : IPX800Base
{
    private readonly IIPX800V5CommandFactory _ipx800V5CommandFactory;
    private readonly IIPX800V5ResponseParserFactory _ipx800V5ResponseParserFactory;
    
    public IPX800V5(IPX800Protocol protocol, IIPX800V5CommandFactory commandFactory, ICommandSender commandSender, IIPX800V5ResponseParserFactory responseParserFactory) : 
        base(protocol, commandFactory, commandSender, responseParserFactory)
    {
        _ipx800V5CommandFactory = commandFactory;
        _ipx800V5ResponseParserFactory = responseParserFactory;
    }

    public override IEnumerable<OutputResponse> GetOutputs(OutputType outputType)
    {
        IList<OutputResponse> outputs = base.GetOutputs(outputType).ToList();

        if (outputType != OutputType.DelayedOutput)
        {
            return outputs;
        }

        IList<TimerResponse> tempos = GetTimers().ToList();
        if (!tempos.Any())
        {
            return new List<OutputResponse>();
        }

        IList<OutputResponseIPX800V5> ioIpx800V5 = outputs.Cast<OutputResponseIPX800V5>().ToList();
        IEnumerable<int> relaysLink = ioIpx800V5.Where(o => o.Link0 > 0 && o.Number is >= IPX800V5Const.RelayMinId and <= IPX800V5Const.RelayMaxId).Select(o => o.Link0).Distinct();
        IEnumerable<int> potentialTempoOutputsLinks = ioIpx800V5.Where(io => relaysLink.Contains(io.Link1)).Select(io => io.Link0).Distinct();
        IEnumerable<int> potentialTempoStartIds = ioIpx800V5.Where(io => potentialTempoOutputsLinks.Contains(io.Link1) && io.Name.EndsWith("Start")).Select(io => io.Number).Distinct();
        return tempos.Where(t => potentialTempoStartIds.Contains(t.IoStartId))
            .Select(t => new OutputResponse
                    {
                        Type = OutputType.DelayedOutput,
                        State = OutputState.Unknown,
                        Number = t.IoStartId,
                        Name = t.Name
                    });

    }

    private IEnumerable<TimerResponse> GetTimers()
    {
        Command command = _ipx800V5CommandFactory.CreateGetTimersCommand();
        string response = CommandSender.ExecuteCommand(command);
        return _ipx800V5ResponseParserFactory.CreateGetTimersParser().ParseResponse(response);
    }
}