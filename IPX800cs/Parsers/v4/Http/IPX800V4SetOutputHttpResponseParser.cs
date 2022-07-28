using System;
using System.Text.Json;
using IPX800cs.Exceptions;

namespace IPX800cs.Parsers.v4.Http;

internal class IPX800V4SetOutputHttpResponseParser : ISetOutputResponseParser
{
    public bool ParseResponse(string ipxResponse)
    {
        try
        {
            JsonDocument json = JsonParser.Parse(ipxResponse);
            string strValue = json.RootElement.GetProperty("status").GetString();
            return strValue == "Success";
        }
        catch (Exception ex) when (ex is not IPX800InvalidResponseException)
        {
            throw new IPX800InvalidResponseException(ipxResponse, ex); 
        }
    }
}