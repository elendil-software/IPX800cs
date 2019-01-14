using System;
using software.elendil.IPX800.CommandSenders;
using software.elendil.IPX800.Enum;

namespace software.elendil.IPX800.v3.M2M
{
	/// <summary>
	/// Class IPX800M2MLegacy.
	/// 
	/// This is the implementation to use with an IPX800 v3 having a firmware older than v3.05.42
	/// </summary>
	public class IPX800M2MLegacy : IPX800M2MBase
	{
		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="IPX800M2MLegacy"/> class.
		/// </summary>
		/// <param name="ip">IP of the IPX800</param>
		/// <param name="port">M2M port of the IPX800</param>
		/// <exception cref="System.ArgumentNullException">ip</exception>
		public IPX800M2MLegacy(string ip, ushort port)
		{
			if (ip == null) throw new ArgumentNullException("ip");
			commandSender = new CommandSenderM2M(ip, port);
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
			var response = responseString.Trim().Split('=');
			return response[1];
		}

		/// <summary>
		/// Parses the response from a <see cref="IPX800M2MBase.GetOut" /> command
		/// </summary>
		/// <param name="responseString">The response string.</param>
		/// <returns>The parsed response</returns>
		protected override OutputState ParseGetOutResponse(string responseString)
		{
			string result = (responseString.Trim().Split('='))[1];
			return (OutputState) System.Enum.Parse(typeof (OutputState), result);
		}

		/// <summary>
		/// Parses the response from a <see cref="IPX800M2MBase.GetIn" /> command
		/// </summary>
		/// <param name="responseString">The response string.</param>
		/// <returns>The parsed response</returns>
		protected override InputState ParseGetInResponse(string responseString)
		{
			var result = (responseString.Trim().Split('='))[1];
			return (InputState) System.Enum.Parse(typeof (InputState), result);
		}

		/// <summary>
		/// Parses the response from a <see cref="IPX800M2MBase.SetOut" /> command
		/// </summary>
		/// <param name="responseString">The response string.</param>
		/// <returns>The parsed response</returns>
		protected override bool ParseSetOutResponse(string responseString)
		{
			var isSuccessful = "Success".Equals(responseString.Trim());
			return isSuccessful;
		}

		#endregion
	}
}