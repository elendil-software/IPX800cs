using System;
using System.Net.Http;
using IPX800cs.Commands.Senders.HttpWebRequestBuilder;
using IPX800cs.Exceptions;

namespace IPX800cs.Commands.Senders;

internal sealed class CommandSenderHttp : ICommandSender
{
	private readonly IHttpRequestMessageBuilder _requestMessageBuilder;
	private readonly HttpClient _httpClient;
	
	public CommandSenderHttp(IHttpRequestMessageBuilder requestMessageBuilder, HttpClient httpClient)
	{
		_requestMessageBuilder = requestMessageBuilder ?? throw new ArgumentNullException(nameof(requestMessageBuilder));
		_httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
	}
		
	public string ExecuteCommand(Command command)
	{
		try
		{
			using HttpRequestMessage request = _requestMessageBuilder.Build(command);
			
			HttpResponseMessage response = _httpClient.SendAsync(request).Result;
			response.EnsureSuccessStatusCode();
			return ReadResponse(response);
		}
		catch (Exception e)
		{
			throw new IPX800SendCommandException(e.Message, e);
		}
	}

	private static string ReadResponse(HttpResponseMessage response)
	{
		string responseText = response.Content.ReadAsStringAsync().Result;

		if (responseText.ToLower().Contains("error"))
		{
			throw new IPX800SendCommandException("An error occured while sending command, IPX800 returned ERROR Status");
		}
				
		return responseText;
	}

	public void Dispose()
	{
		_httpClient?.Dispose();
	}
}