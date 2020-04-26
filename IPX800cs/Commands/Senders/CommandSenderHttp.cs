using System;
using System.Net;
using System.Text;
using IPX800cs.Commands.Senders.HttpWebRequestBuilder;
using IPX800cs.Exceptions;

namespace IPX800cs.Commands.Senders
{
	internal class CommandSenderHttp : ICommandSender
	{
		private readonly IHttpWebRequestBuilder _webRequestBuilder;

		public CommandSenderHttp(IHttpWebRequestBuilder webRequestBuilder)
		{
			_webRequestBuilder = webRequestBuilder ?? throw new ArgumentNullException(nameof(webRequestBuilder));
		}
		
		public string ExecuteCommand(string command)
		{
			var request = _webRequestBuilder.Build(command);
			
			try
			{
				using (var response = (HttpWebResponse) request.GetResponse())
				{
					if (HttpStatusCode.OK.Equals(response.StatusCode))
					{
						return ReadResponse(response);
					}
					else
					{
						throw new IPX800SendCommandException($"{response.StatusCode} {response.StatusDescription}");
					}
				}
			}
			catch (WebException e)
			{
				throw new IPX800SendCommandException($"An error occured while sending command : {e.Message}", e);
			}
		}

		private static string ReadResponse(HttpWebResponse response)
		{
			using (var reader = new System.IO.StreamReader(response.GetResponseStream(), ASCIIEncoding.ASCII))
			{
				string responseText = reader.ReadToEnd();
				return responseText;
			}
		}
	}
}