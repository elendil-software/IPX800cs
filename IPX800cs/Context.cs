using System;
using System.Net;
using IPX800cs.Version;

namespace IPX800cs
{
    public class Context
    {
        public Context(string ip, int port, IPX800Protocol protocol, IPX800Version version)
        {
            if (string.IsNullOrWhiteSpace(ip))
            {
                throw new ArgumentNullException(nameof(ip));
            }

            IP = IPAddress.Parse(ip);
            Port = port;
            Protocol = protocol;
            Version = version;
        }

        public Context(string ip, int port, IPX800Protocol protocol, IPX800Version version, System.Version firmwareVersion)
        {
            if (string.IsNullOrWhiteSpace(ip))
            {
                throw new ArgumentNullException(nameof(ip));
            }

            IP = IPAddress.Parse(ip);
            Port = port;
            Protocol = protocol;
            Version = version;
            FirmwareVersion = firmwareVersion ?? throw new ArgumentNullException(nameof(firmwareVersion));
        }

        public Context(string ip, int port, IPX800Protocol protocol, IPX800Version version, string user, string password)
        {
            if (string.IsNullOrWhiteSpace(ip))
            {
                throw new ArgumentNullException(nameof(ip));
            }

            IP = IPAddress.Parse(ip);
            Port = port;
            Protocol = protocol;
            Version = version;
            User = user;
            Password = password;
        }

        public Context(string ip, int port, IPX800Protocol protocol, IPX800Version version, string user,
            string password, System.Version firmwareVersion)
        {
            if (string.IsNullOrWhiteSpace(ip))
            {
                throw new ArgumentNullException(nameof(ip));
            }

            IP = IPAddress.Parse(ip);
            Port = port;
            Protocol = protocol;
            Version = version;
            User = user ?? throw new ArgumentNullException(nameof(user));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            FirmwareVersion = firmwareVersion ?? throw new ArgumentNullException(nameof(firmwareVersion));
        }

        public IPX800Version Version { get; }
        public System.Version FirmwareVersion { get; }
        public IPX800Protocol Protocol { get; }
        public IPAddress IP { get; }
        public int Port { get; }
        public string User { get; }
        public string Password { get; }
    }
}