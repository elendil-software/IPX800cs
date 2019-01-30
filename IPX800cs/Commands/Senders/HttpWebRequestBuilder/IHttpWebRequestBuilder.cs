using System.Net;

namespace software.elendil.IPX800.Commands.Senders.HttpWebRequestBuilder
{
    public interface IHttpWebRequestBuilder
    {
        WebRequest Build(string command);
    }
}