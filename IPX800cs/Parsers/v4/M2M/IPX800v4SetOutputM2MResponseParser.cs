namespace software.elendil.IPX800.Parsers.v4.M2M
{
    public class IPX800v4SetOutputM2MResponseParser : ISetOutputResponseParser
    {
        public bool ParseResponse(string ipxResponse)
        {
            //TODO remplacer Equals par ==
            var isSuccessful = "Success".Equals(ipxResponse.Trim());
            return isSuccessful;
        }
    }
}