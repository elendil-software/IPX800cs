using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using software.elendil.IPX800.Exceptions;

namespace software.elendil.IPX800.Commands.Senders
{
	internal class CommandSenderM2M : ICommandSender
    {
        private readonly Context context;
		private readonly byte[] buffer = new byte[1024];	
		private Socket socket;

        public CommandSenderM2M(Context context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        private void Connect()
		{
			try
			{
				socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
				{
					ReceiveTimeout = 10000,
					SendTimeout = 10000
				};
				var ipEndPoint = new IPEndPoint(context.IP, context.Port);
				socket.Connect(ipEndPoint);
			}
			catch (Exception e)
			{
				throw new IPX800SendCommandException($"Unable to connect to IPX800 : {e.Message}", e);
			}
		}

		private void Disconnect()
		{
			socket.Shutdown(SocketShutdown.Both);
			socket.Close();
			socket = null;
		}

        public string ExecuteCommand(string command)
		{
			Connect();

			try
			{
				SendPassword();
                
				var byteCommand = Encoding.ASCII.GetBytes(command);
				socket.Send(byteCommand);

				var nbBytesReceived = socket.Receive(buffer);
				var response = Encoding.ASCII.GetString(buffer, 0, nbBytesReceived);

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
			if (!string.IsNullOrEmpty(context.Password))
			{
				byte[] byteCommand = Encoding.ASCII.GetBytes($"key={context.Password}");
				socket.Send(byteCommand);

				var nbBytesReceived = socket.Receive(buffer);
				var response = Encoding.ASCII.GetString(buffer, 0, nbBytesReceived);

				if (string.IsNullOrEmpty(response))
				{
					throw new IPX800SendCommandException("wrong user or password");
				}
			}
		}
	}
}