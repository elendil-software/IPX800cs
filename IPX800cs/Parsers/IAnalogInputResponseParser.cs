namespace IPX800cs.Parsers
{
    public interface IAnalogInputResponseParser
    {
        int ParseResponse(string ipxResponse, int inputNumber);
    }
}