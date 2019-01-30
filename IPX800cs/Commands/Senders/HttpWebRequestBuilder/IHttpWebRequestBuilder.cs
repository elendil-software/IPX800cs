using System.Net;

namespace software.elendil.IPX800.Commands.Senders
{
    public interface IHttpWebRequestBuilder
    {
        WebRequest Build(string command);
    }
}