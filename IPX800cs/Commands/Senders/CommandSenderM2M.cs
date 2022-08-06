using System;
using System.Net.Sockets;
using System.Text;
using IPX800cs.Exceptions;

namespace IPX800cs.Commands.Senders;

internal sealed class CommandSenderM2M : ICommandSender
{
	private readonly Context _context;
	private readonly byte[] _buffer = new byte[1024];	
	private Socket _socket;

	public CommandSenderM2M(Context context)
	{
		_context = context ?? throw new ArgumentNullException(nameof(context));
	}

	private void Connect()
	{
		try
		{
			_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
			{
				ReceiveTimeout = 10000,
				SendTimeout = 10000
			};

			_socket.Connect(_context.Host, _context.Port);
		}
		catch (Exception e)
		{
			throw new IPX800SendCommandException($"Unable to connect to IPX800 : {e.Message}", e);
		}
	}

	private void Disconnect()
	{
		_socket.Shutdown(SocketShutdown.Both);
		_socket.Close();
		_socket = null;
	}

	public string ExecuteCommand(Command command)
	{
		Connect();

		try
		{
			SendPassword();
                
			var byteCommand = Encoding.ASCII.GetBytes(command.QueryString);
			_socket.Send(byteCommand);

			var nbBytesReceived = _socket.Receive(_buffer);
			var response = Encoding.ASCII.GetString(_buffer, 0, nbBytesReceived);

			return response;
		}
		catch (Exception e)
		{
			throw new IPX800SendCommandException($"Unable to execute the command '{command}' : {e.Message}", e);
		}
		finally
		{
			Disconnect();
		}
	}

	private void SendPassword()
	{
		if (!string.IsNullOrEmpty(_context.Password))
		{
			byte[] byteCommand = Encoding.ASCII.GetBytes($"key={_context.Password}");
			_socket.Send(byteCommand);

			var nbBytesReceived = _socket.Receive(_buffer);
			var response = Encoding.ASCII.GetString(_buffer, 0, nbBytesReceived);

			if (string.IsNullOrEmpty(response))
			{
				throw new IPX800SendCommandException("wrong user or password");
			}
		}
	}

	public void Dispose()
	{
		_socket?.Dispose();
	}
}