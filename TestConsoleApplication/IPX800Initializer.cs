using System;
using IPX800cs;
using IPX800cs.Contracts;
using TestConsoleApplication.Configuration;

namespace TestConsoleApplication
{
    internal class IPX800Initializer
    {
        private readonly IPX800Config _configuration;
        private readonly LogFile _logFile;

        public IPX800Initializer(IPX800Config configuration, LogFile logFile)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _logFile = logFile ?? throw new ArgumentNullException(nameof(logFile));
        }

        public IIPX800 InitIPX800()
        {
            IPX800Protocol protocol = _configuration.Protocol == "M2M" ? IPX800Protocol.M2M : IPX800Protocol.Http;
            IIPX800 ipx800;

            switch (_configuration.Version.ToLower())
            {
                case "v2":
                    ipx800 = IPX800Factory.GetIPX800v2Instance(_configuration.IP, _configuration.Port, protocol, _configuration.User, _configuration.Pass);
                    break;

                case "v3":
                    ipx800 = IPX800Factory.GetIPX800v3Instance(_configuration.IP, _configuration.Port, protocol, _configuration.User, _configuration.Pass);
                    break;

                case "v4":
                    ipx800 = IPX800Factory.GetIPX800v4Instance(_configuration.IP, _configuration.Port, protocol, _configuration.User, _configuration.Pass);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(_configuration.Version), $"{_configuration.Version} is not a valid IPX800 version");
            }

            LogConfiguration(ipx800);
            
            return ipx800;
        }

        private void LogConfiguration(IIPX800 ipx800)
        {
            _logFile.LogTitle("Configuration IPX800");
            _logFile.Log($"Version : {_configuration.Version}");
            _logFile.Log($"Protocol : {_configuration.Protocol}");
            _logFile.Log($"IP : {_configuration.IP}");
            _logFile.Log($"Port : {_configuration.Port}");
            _logFile.Log($"User : {(_configuration.User.Length > 0 ? "****" : "")}");
            _logFile.Log($"Pass : {(_configuration.Pass.Length > 0 ? "****" : "")}\n");
            _logFile.Log($"Instance Type : {ipx800.GetType().Name}");
            _logFile.Log($"Instance Type : {ipx800.GetType().FullName}");
            _logFile.LogEndLine();
        }
    }
}