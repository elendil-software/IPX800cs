
using System;

namespace IPX800cs.Commands.Senders;

public interface ICommandSender : IDisposable
{
	string ExecuteCommand(Command command);
}