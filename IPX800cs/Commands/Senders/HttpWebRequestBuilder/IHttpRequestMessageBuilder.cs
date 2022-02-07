using System.Net;
using System.Net.Http;

namespace IPX800cs.Commands.Senders.HttpWebRequestBuilder;

public interface IHttpRequestMessageBuilder
{ 
    HttpRequestMessage Build(Command command);
}