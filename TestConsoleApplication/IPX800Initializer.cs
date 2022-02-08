using System;
using IPX800cs;
using IPX800cs.Version;
using TestConsoleApplication.Configuration;

namespace TestConsoleApplication;

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
        IIPX800Factory ipx800Factory = new IPX800Factory();

        IIPX800 ipx800 = _configuration.Version.ToLower() switch
        {
            "v2" => ipx800Factory.CreateInstance(IPX800Version.V2, protocol, _configuration.Host, _configuration.Port, _configuration.User, _configuration.Pass),
            "v3" => ipx800Factory.CreateInstance(IPX800Version.V3, protocol, _configuration.Host, _configuration.Port, _configuration.User, _configuration.Pass),
            "v4" => ipx800Factory.CreateInstance(IPX800Version.V4, protocol, _configuration.Host, _configuration.Port, _configuration.User, _configuration.Pass),
            _ => throw new ArgumentOutOfRangeException(nameof(_configuration.Version), $"{_configuration.Version} is not a valid IPX800 version")
        };

        LogConfiguration(ipx800);
        _logFile.LogEndLine();
            
        return ipx800;
    }

    private void LogConfiguration(IIPX800 ipx800)
    {
        _logFile.LogTitle("Configuration IPX800");
        _logFile.Log($"Version : {_configuration.Version}");
        _logFile.Log($"Protocol : {_configuration.Protocol}");
        _logFile.Log($"Host : {_configuration.Host}");
        _logFile.Log($"Port : {_configuration.Port}");
        _logFile.Log($"User : {(_configuration.User.Length > 0 ? "****" : "")}");
        _logFile.Log($"Pass : {(_configuration.Pass.Length > 0 ? "****" : "")}\n");
        _logFile.Log($"Instance Type : {ipx800.GetType().Name}");
    }
}