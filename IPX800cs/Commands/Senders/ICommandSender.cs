using System;
#pragma warning disable CS1591

namespace IPX800cs.Commands.Senders;

public interface ICommandSender : IDisposable
{
	string ExecuteCommand(Command command);
}