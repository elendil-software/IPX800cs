using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using software.elendil.IPX800.Exceptions;

namespace software.elendil.IPX800.CommandSenders
{
	/// <summary>
	/// Class CommandSenderM2M.
	/// Provides methods to send M2M command to an IPX800
	/// </summary>
	public class CommandSenderM2M : ICommandSender
	{
		/// <summary>
		/// The IP address of the IPX800
		/// </summary>
		private readonly string ip;

		/// <summary>
		/// The port of the IPX800
		/// </summary>
		private readonly ushort port;

		/// <summary>
		/// Password
		/// </summary>
		private readonly string pass;

		/// <summary>
		/// The buffer to store the IPX800 responses
		/// </summary>
		private readonly byte[] buffer = new byte[64];

		/// <summary>
		/// The socket to send the commands to the IPX800
		/// </summary>
		private Socket socket;

		/// <summary>
		/// Constructor
		/// </summary>
		public CommandSenderM2M(string ip, ushort port)
		{
			if (ip == null) throw new ArgumentNullException("ip");
			this.ip = ip;
			this.port = port;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		public CommandSenderM2M(string ip, ushort port, string pass)
		{
			if (ip == null) throw new ArgumentNullException("ip");
			this.ip = ip;
			this.port = port;
			this.pass = pass;
		}

		#region Connect/Disconnect

		/// <summary>
		/// Establish a connection with the IPX800
		/// </summary>
		/// <exception cref="IPX800ConnectionException">Thrown if the connexion with the IPX800 failed</exception>
		private void Connect()
		{
			try
			{
				socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
				{
					ReceiveTimeout = 10000,
					SendTimeout = 10000
				};
				var ipEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
				socket.Connect(ipEndPoint);
			}
			catch (Exception e)
			{
				throw new IPX800ConnectionException("Unable to connect to IPX800 : " + e.Message, e);
			}
		}

		private void Disconnect()
		{
			socket.Shutdown(SocketShutdown.Both);
			socket.Close();
			socket = null;
		}

		#endregion

		/// <summary>
		/// Execute the given command
		/// </summary>
		/// <param name="command">the command to execute</param>
		/// <returns>the response to the executed</returns>
		/// <exception cref="IPX800ExecuteException">Thrown if it was unable to send the request or in case of timeout while waiting for response</exception>
		public object ExecuteCommand(string command)
		{
			Connect();

			try
			{
				SendPassword();

#if DEBUG
				Console.WriteLine("ExecuteCommand : " + command);
#endif
				var byteCommand = Encoding.ASCII.GetBytes(command);
				var nbBytesSent = socket.Send(byteCommand);
#if DEBUG
				Console.WriteLine("nbBytesSent : " + nbBytesSent);
#endif

				var nbBytesReceived = socket.Receive(buffer);
				var response = Encoding.ASCII.GetString(buffer, 0, nbBytesReceived);

				return response;
			}
			catch (Exception e)
			{
				throw new IPX800ExecuteException("Unable to execute the command '" + command + "' : " + e.Message, e);
			}
			finally
			{
				Disconnect();
			}
		}

		private void SendPassword()
		{
			if (!string.IsNullOrEmpty(pass))
			{
#if DEBUG
				Console.WriteLine("Send password");
#endif
				var byteCommand = Encoding.ASCII.GetBytes("key=" + pass);
				var nbBytesSent = socket.Send(byteCommand);
#if DEBUG
				Console.WriteLine("nbBytesSent : " + nbBytesSent);
#endif
				var nbBytesReceived = socket.Receive(buffer);
				var response = Encoding.ASCII.GetString(buffer, 0, nbBytesReceived);

				if (string.IsNullOrEmpty(response))
				{
					throw new IPX800ExecuteException("wrong user or password");
				}
			}
		}
	}
}