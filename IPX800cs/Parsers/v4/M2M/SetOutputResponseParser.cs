namespace software.elendil.IPX800.Parsers.v4.M2M
{
    public class SetOutputResponseParser : IOutputResponseParser<bool>
    {
        public bool ParseResponse(string ipxResponse, int ioNumber)
        {
            //TODO remplacer Equals par ==
            var isSuccessful = "Success".Equals(ipxResponse.Trim());
            return isSuccessful;
        }
    }
}