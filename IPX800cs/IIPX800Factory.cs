using System.Net.Http;
using IPX800cs.Exceptions;
using IPX800cs.Version;

namespace IPX800cs;

/// <summary>
/// This factory provide method allowing to create an instance of an implementation of <see cref="IIPX800"/> corresponding to a physical type of
/// IPX800 device from version 2 to 5
/// </summary>
public interface IIPX800Factory
{
    /// <summary>
    /// Create an instance of IIPX800 implementation matching the <paramref name="version"/>.
    ///
    /// The <paramref name="httpClient"/> has to be configured with the <see cref="HttpClient.BaseAddress"/> set with
    /// the protocol, host or IP and port configured in the IPX800 (e.g. http://IPX800_V4:80)
    /// </summary>
    /// <param name="version">The IPX800 version for which to create the instance</param>
    /// <param name="httpClient">An HttpClient instance to use to connect to the IPX800</param>
    /// <returns>The created instance</returns>
    /// <exception cref="IPX800InvalidContextException">When <paramref name="version"/> value is not valid or not supported</exception>
    IIPX800 CreateInstance(IPX800Version version, HttpClient httpClient);

    /// <summary>
    /// Create an instance of IIPX800 implementation matching the <paramref name="version"/>.
    ///
    /// The <paramref name="httpClient"/> has to be configured with the <see cref="HttpClient.BaseAddress"/> set with
    /// the protocol, host or IP and port configured in the IPX800 (e.g. http://IPX800_V4:80)
    /// </summary>
    /// <param name="version">The IPX800 version for which to create the instance</param>
    /// <param name="httpClient">An HttpClient instance to use to connect to the IPX800</param>
    /// <param name="apiKey">API Key configured in the IPX800</param>
    /// <returns>The created instance</returns>
    /// <exception cref="IPX800InvalidContextException">When <paramref name="version"/> value is not valid or not supported</exception>
    IIPX800 CreateInstance(IPX800Version version, HttpClient httpClient, string apiKey);

    /// <summary>
    /// Create an instance of IIPX800 implementation matching the <paramref name="version"/>.
    ///
    /// The <paramref name="httpClient"/> has to be configured with the <see cref="HttpClient.BaseAddress"/> set with
    /// the protocol, host or IP and port configured in the IPX800 (e.g. http://IPX800_V4:80)
    /// </summary>
    /// <param name="version">The IPX800 version for which to create the instance</param>
    /// <param name="httpClient">An HttpClient instance to use to connect to the IPX800</param>
    /// <param name="user">User configured in the IPX800</param>
    /// <param name="password">Password configured in the IPX800</param>
    /// <returns>The created instance</returns>
    /// <exception cref="IPX800InvalidContextException">When <paramref name="version"/> value is not valid or not supported</exception>
    IIPX800 CreateInstance(IPX800Version version, HttpClient httpClient, string user, string password);
    
    /// <summary>
    /// Create an instance of IIPX800 implementation matching the <paramref name="version"/>.
    ///
    /// In the case of <see cref="IPX800Protocol.Http"/> used as <paramref name="protocol"/> the <paramref name="host"/> has to be specified
    /// with the protocol (e.g. http://IPX800_V4 or http://192.168.1.2) 
    /// </summary>
    /// <param name="version">The IPX800 version for which to create the instance</param>
    /// <param name="protocol">The protocol to use to connect to the IPX800</param>
    /// <param name="host">Host or IP configured in the IPX800</param>
    /// <param name="port">Port configured in the IPX800 for the used <paramref name="protocol"/></param>
    /// <returns>The created instance</returns>
    /// <exception cref="IPX800InvalidContextException">When <paramref name="version"/> or <paramref name="protocol"/> combination values are not valid or not supported</exception>
    IIPX800 CreateInstance(IPX800Version version, IPX800Protocol protocol, string host, int port);
    
    /// <summary>
    /// Create an instance of IIPX800 implementation matching the <paramref name="version"/>.
    ///
    /// In the case of <see cref="IPX800Protocol.Http"/> used as <paramref name="protocol"/> the <paramref name="host"/> has to be specified
    /// with the protocol (e.g. http://IPX800_V4 or http://192.168.1.2) 
    /// </summary>
    /// <param name="version">The IPX800 version for which to create the instance</param>
    /// <param name="protocol">The protocol to use to connect to the IPX800</param>
    /// <param name="host">Host or IP configured in the IPX800</param>
    /// <param name="port">Port configured in the IPX800 for the used <paramref name="protocol"/></param>
    /// <param name="apiKey">API Key configured in the IPX800</param>
    /// <returns>The created instance</returns>
    /// <exception cref="IPX800InvalidContextException">When <paramref name="version"/> or <paramref name="protocol"/> combination values are not valid or not supported</exception>
    IIPX800 CreateInstance(IPX800Version version, IPX800Protocol protocol, string host, int port, string apiKey);
    
    /// <summary>
    /// Create an instance of IIPX800 implementation matching the <paramref name="version"/>.
    ///
    /// In the case of <see cref="IPX800Protocol.Http"/> used as <paramref name="protocol"/> the <paramref name="host"/> has to be specified
    /// with the protocol (e.g. http://IPX800_V4 or http://192.168.1.2) 
    /// </summary>
    /// <param name="version">The IPX800 version for which to create the instance</param>
    /// <param name="protocol">The protocol to use to connect to the IPX800</param>
    /// <param name="host">Host or IP configured in the IPX800</param>
    /// <param name="port">Port configured in the IPX800 for the used <paramref name="protocol"/></param>
    /// <param name="user">User configured in the IPX800</param>
    /// <param name="password">Password configured in the IPX800</param>
    /// <returns>The created instance</returns>
    /// <exception cref="IPX800InvalidContextException">When <paramref name="version"/> or <paramref name="protocol"/> combination values are not valid or not supported</exception>
    IIPX800 CreateInstance(IPX800Version version, IPX800Protocol protocol, string host, int port, string user, string password);
}