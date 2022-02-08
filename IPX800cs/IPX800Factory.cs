using System.Net.Http;
using IPX800cs.Commands.Builders;
using IPX800cs.Commands.Builders.v2;
using IPX800cs.Commands.Builders.v3;
using IPX800cs.Commands.Builders.v4;
using IPX800cs.Commands.Builders.v5;
using IPX800cs.Commands.Senders;
using IPX800cs.Exceptions;
using IPX800cs.Parsers.v2;
using IPX800cs.Parsers.v3;
using IPX800cs.Parsers.v4;
using IPX800cs.Parsers.v5;
using IPX800cs.Version;

namespace IPX800cs;

public class IPX800Factory : IIPX800Factory
{
	public IIPX800 CreateInstance(IPX800Version version, HttpClient httpClient)
	{
		return CreateInstance(version, httpClient, null, null);
	}

	public IIPX800 CreateInstance(IPX800Version version, HttpClient httpClient, string apiKey)
	{
		return CreateInstance(version, httpClient, null, apiKey);
	}

	public IIPX800 CreateInstance(IPX800Version version, HttpClient httpClient, string user, string password)
	{
		return IPX800V2(version, httpClient, user, password);
	}

	private static IIPX800 IPX800V2(IPX800Version version, HttpClient httpClient, string user, string password)
	{
		var context = new Context(httpClient.BaseAddress.Host, httpClient.BaseAddress.Port, IPX800Protocol.Http, version, user, password);

		return version switch
		{
			IPX800Version.V2 => CreateIPX800V2(context, httpClient),
			IPX800Version.V3 => CreateIPX800V3(context, httpClient),
			IPX800Version.V4 => CreateIPX800V4(context, httpClient),
			_ => throw new IPX800InvalidContextException($"IPX800 version {version} is not supported")
		};
	}

	public IIPX800 CreateInstance(IPX800Version version, IPX800Protocol protocol, string ip, int port)
	{
		return CreateInstance(version, protocol, ip, port, null, null);
	}
		
	public IIPX800 CreateInstance(IPX800Version version, IPX800Protocol protocol, string ip, int port, string apiKey)
	{
		return CreateInstance(version, protocol, ip, port, null, apiKey);
	}
	
	
		
	public IIPX800 CreateInstance(IPX800Version version, IPX800Protocol protocol, string ip, int port, string user, string password)
	{
		var context = new Context(ip, port, protocol, version, user, password);

		return version switch
		{
			IPX800Version.V2 => CreateIPX800V2(context),
			IPX800Version.V3 => CreateIPX800V3(context),
			IPX800Version.V4 => CreateIPX800V4(context),
			IPX800Version.V5 => CreateIPX800V5(context),
			_ => throw new IPX800InvalidContextException($"IPX800 version {version} is not supported")
		};
	}
	
	private static IPX800V2 CreateIPX800V2(Context context, HttpClient httpClient = null)
	{
		ICommandFactory commandFactory = context.Protocol switch
		{
			IPX800Protocol.Http => new IPX800v2HttpCommandFactory(),
			IPX800Protocol.M2M => new IPX800v2M2MCommandFactory(),
			_ => throw new IPX800InvalidContextException($"Protocol {context.Protocol} is not supported by IPX800 v2")
		};
			
		return new IPX800V2(
			context.Protocol, 
			commandFactory, 
			CommandSenderFactory.GetCommandSender(context, httpClient), 
			new IPX800v2ResponseParserFactory()
		);
	}
		
	private static IPX800V3 CreateIPX800V3(Context context, HttpClient httpClient = null)
	{
		ICommandFactory commandFactory = context.Protocol switch
		{
			IPX800Protocol.Http => new IPX800V3HttpCommandFactory(),
			IPX800Protocol.M2M => new IPX800V3M2MCommandFactory(),
			_ => throw new IPX800InvalidContextException($"Protocol {context.Protocol} is not supported by IPX800 v3")
		};
			
		return new IPX800V3(
			context.Protocol, 
			commandFactory, 
			CommandSenderFactory.GetCommandSender(context, httpClient), 
			new IPX800V3ResponseParserFactory()
		);
	}
		
	private static IPX800V4 CreateIPX800V4(Context context, HttpClient httpClient = null)
	{
		ICommandFactory commandFactory = context.Protocol switch
		{
			IPX800Protocol.Http => new IPX800V4HttpCommandFactory(),
			IPX800Protocol.M2M => new IPX800V4M2MCommandFactory(),
			_ => throw new IPX800InvalidContextException($"Protocol {context.Protocol} is not supported by IPX800 v4")
		};
			
		return new IPX800V4(
			context.Protocol, 
			commandFactory, 
			CommandSenderFactory.GetCommandSender(context, httpClient), 
			new IPX800V4ResponseParserFactory()
		);
	}
	
	private static IPX800V5 CreateIPX800V5(Context context)
	{
		IIPX800V5CommandFactory commandFactory = context.Protocol switch
		{
			IPX800Protocol.Http => new IPX800V5HttpCommandFactory(),
			_ => throw new IPX800InvalidContextException($"Protocol {context.Protocol} is not supported by IPX800 v5")
		};
			
		return new IPX800V5(
			context.Protocol, 
			commandFactory, 
			new CommandSenderFactory().GetCommandSender(context), 
			new IPX800V5ResponseParserFactory()
		);
	}
}