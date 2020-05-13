namespace IPX800cs.Parsers.v2.M2M
{
    internal abstract class IPX800v2M2MParserBase
    {
        protected int ParseValue(string ipxResponse)
        {
            string[] splitString = ipxResponse.Trim().Split('=');
            return int.Parse(splitString[1]);
        }
    }
}