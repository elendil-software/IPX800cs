namespace IPX800cs.Parsers.v2.M2M;

internal abstract class IPX800V2M2MParserBase
{
    protected static int ParseValue(string ipxResponse)
    {
        string[] splitString = ipxResponse.Trim().Split('=');
        return int.Parse(splitString[1]);
    }
}