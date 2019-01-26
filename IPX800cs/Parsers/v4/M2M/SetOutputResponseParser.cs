namespace software.elendil.IPX800.Parsers.v4.M2M
{
    public class SetOutputResponseParser : ISetOutputResponseParser
    {
        public bool ParseResponse(string ipxResponse)
        {
            //TODO remplacer Equals par ==
            var isSuccessful = "Success".Equals(ipxResponse.Trim());
            return isSuccessful;
        }
    }
}