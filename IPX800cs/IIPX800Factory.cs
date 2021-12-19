using IPX800cs.Version;

namespace IPX800cs;

public interface IIPX800Factory
{
    IIPX800 CreateInstance(IPX800Version version, string ip, int port, IPX800Protocol protocol);
    IIPX800 CreateInstance(IPX800Version version, string ip, int port, IPX800Protocol protocol, string apiKey);
    IIPX800 CreateInstance(IPX800Version version, string ip, int port, IPX800Protocol protocol, string user, string password);
}