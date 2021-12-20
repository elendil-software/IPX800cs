using System.Net;

namespace IPX800cs.Commands.Senders.HttpWebRequestBuilder;

public interface IHttpWebRequestBuilder
{
    WebRequest Build(string command);
}