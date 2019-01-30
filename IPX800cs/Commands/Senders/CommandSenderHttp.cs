using System;
using System.Net;
using System.Text;
using software.elendil.IPX800.ipx800csV1.Exceptions;

namespace software.elendil.IPX800.Commands.Senders
{
	public class CommandSenderHttp : ICommandSender
	{
		private readonly IHttpWebRequestBuilder webRequestBuilder;

		public CommandSenderHttp(IHttpWebRequestBuilder webRequestBuilder)
		{
			this.webRequestBuilder = webRequestBuilder ?? throw new ArgumentNullException(nameof(webRequestBuilder));
		}
		
		public string ExecuteCommand(string command)
		{
			var request = webRequestBuilder.Build(command);
			
			try
			{
				using (var response = (HttpWebResponse) request.GetResponse())
				{
					if (HttpStatusCode.OK.Equals(response.StatusCode))
					{
						using (var reader = new System.IO.StreamReader(response.GetResponseStream(), ASCIIEncoding.ASCII))
						{
							string responseText = reader.ReadToEnd();
							return responseText;
						}
					}
					else
					{
						throw new Exception(response.StatusDescription);
					}
				}
			}
			catch (WebException e)
			{
				throw new IPX800ConnectionException("Unable to connect to IPX800 : " + e.Message, e);
			}
		}
	}
}