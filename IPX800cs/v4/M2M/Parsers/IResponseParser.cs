namespace software.elendil.IPX800.v4.M2M.Parsers
{
    public interface IResponseParser<T>
    {
        T ParseResponse(string responseString, uint inputOutputNumber);
    }
}