using System.Net.Http;
using IPX800cs.Version;

namespace IPX800cs;

public interface IIPX800Factory
{
    IIPX800 CreateInstance(IPX800Version version, HttpClient httpClient);
    IIPX800 CreateInstance(IPX800Version version, HttpClient httpClient, string apiKey);
    IIPX800 CreateInstance(IPX800Version version, HttpClient httpClient, string user, string password);
    
    IIPX800 CreateInstance(IPX800Version version, IPX800Protocol protocol, string ip, int port);
    IIPX800 CreateInstance(IPX800Version version, IPX800Protocol protocol, string ip, int port, string apiKey);
    IIPX800 CreateInstance(IPX800Version version, IPX800Protocol protocol, string ip, int port, string user, string password);
}