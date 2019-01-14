using System;
using software.elendil.IPX800.CommandSenders;
using software.elendil.IPX800.Enum;

namespace software.elendil.IPX800.v3.M2M
{
	/// <summary>
	/// Class IPX800M2M.
	/// 
	/// This is the implementation to use with an IPX800 v3 having a firmware equals or newer than the v3.05.42
	/// </summary>
	public class IPX800M2M : IPX800M2MBase
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="IPX800M2M"/> class.
		/// </summary>
		/// <param name="ip">IP of the IPX800</param>
		/// <param name="port">M2M port of the IPX800</param>
		/// <exception cref="System.ArgumentNullException">ip</exception>
		public IPX800M2M(string ip, ushort port)
		{
			if (ip == null) throw new ArgumentNullException("ip");
			commandSender = new CommandSenderM2M(ip, port);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IPX800M2M"/> class.
		/// </summary>
		/// <param name="ip">IP of the IPX800</param>
		/// <param name="port">M2M port of the IPX800</param>
		/// <param name="pass">password</param>
		/// <exception cref="System.ArgumentNullException">ip</exception>
		public IPX800M2M(string ip, ushort port, string pass)
		{
			if (ip == null) throw new ArgumentNullException("ip");
			commandSender = new CommandSenderM2M(ip, port, pass);
		}

		#endregion

		#region Parse methods

		/// <summary>
		/// Parses the response from a <see cref="IPX800M2MBase.GetAn" /> command
		/// </summary>
		/// <param name="responseString">The response string.</param>
		/// <returns>The parsed response</returns>
		protected override string ParseGetAnResponse(string responseString)
		{
			var result = responseString.Trim();
			return result;
		}

		/// <summary>
		/// Parses the response from a <see cref="IPX800M2MBase.GetOut" /> command
		/// </summary>
		/// <param name="responseString">The response string.</param>
		/// <returns>The parsed response</returns>
		protected override OutputState ParseGetOutResponse(string responseString)
		{
			var result = responseString.Trim();
			return (OutputState) System.Enum.Parse(typeof (OutputState), result);
		}

		/// <summary>
		/// Parses the response from a <see cref="IPX800M2MBase.GetIn" /> command
		/// </summary>
		/// <param name="responseString">The response string.</param>
		/// <returns>The parsed response</returns>
		protected override InputState ParseGetInResponse(string responseString)
		{
			var result = responseString.Trim();
			return (InputState) System.Enum.Parse(typeof (InputState), result);
		}

		/// <summary>
		/// Parses the response from a <see cref="IPX800M2MBase.SetOut" /> command
		/// </summary>
		/// <param name="responseString">The response string.</param>
		/// <returns>The parsed response</returns>
		protected override bool ParseSetOutResponse(string responseString)
		{
			var isSuccessful = "OK".Equals(responseString.Trim());
			return isSuccessful;
		}

		#endregion
	}
}