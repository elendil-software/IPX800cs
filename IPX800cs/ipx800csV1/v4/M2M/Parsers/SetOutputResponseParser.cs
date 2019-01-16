namespace software.elendil.IPX800.ipx800csV1.v4.M2M.Parsers
{
    public class SetOutputResponseParser : IResponseParser<bool>
    {
        public bool ParseResponse(string responseString, uint inputOutputNumber)
        {
            var isSuccessful = "Success".Equals(responseString.Trim());
            return isSuccessful;
        }
    }
}