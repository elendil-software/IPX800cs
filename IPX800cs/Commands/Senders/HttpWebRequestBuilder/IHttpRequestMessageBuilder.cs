using System.Net.Http;
#pragma warning disable CS1591

namespace IPX800cs.Commands.Senders.HttpWebRequestBuilder;

public interface IHttpRequestMessageBuilder
{ 
    HttpRequestMessage Build(Command command);
}