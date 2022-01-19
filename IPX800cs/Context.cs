using System;
using System.Net;
using IPX800cs.Version;

namespace IPX800cs;

public class Context
{
    public Context(string host, int port, IPX800Protocol protocol, IPX800Version version)
    {
        if (string.IsNullOrWhiteSpace(host))
        {
            throw new ArgumentNullException(nameof(host));
        }

        Host = host;
        Port = port;
        Protocol = protocol;
        Version = version;
    }

    public Context(string host, int port, IPX800Protocol protocol, IPX800Version version, string user, string password)
    {
        if (string.IsNullOrWhiteSpace(host))
        {
            throw new ArgumentNullException(nameof(host));
        }

        Host = host;
        Port = port;
        Protocol = protocol;
        Version = version;
        User = user;
        Password = password;
    }

    public IPX800Version Version { get; }
    public IPX800Protocol Protocol { get; }
    public string Host { get; }
    public int Port { get; }
    public string User { get; }
    public string Password { get; }
}