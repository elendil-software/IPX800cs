using System;
using System.Net;
using System.Text;

namespace software.elendil.IPX800.CommandSenders
{
	public class CommandSenderHttpIPX800V4 : CommandSenderHttp
 	{
		#region Constructors

		public CommandSenderHttpIPX800V4(string ip, ushort port) : base(ip, port)
		{
		}

		public CommandSenderHttpIPX800V4(string ip, ushort port, string user, string pass) : base(ip, port, user, pass)
		{
		}

		#endregion

		protected new string GetUri(string command)
		{
			var uri = new StringBuilder("http://");
			uri.Append(ip).Append(":").Append(port).Append("/api/xdevices.json?");

			if (!string.IsNullOrWhiteSpace(pass))
			{
				uri.Append("key=").Append(pass).Append("&");
			}
				
			uri.Append(command);
			return uri.ToString();
		}

		protected new void AddAuthorizationHeader(WebRequest request)
		{
			//DO NOTHING, key passed by URI if defined
		}
	}
}