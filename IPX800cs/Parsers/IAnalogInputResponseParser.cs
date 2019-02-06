namespace IPX800cs.Parsers
{
    public interface IAnalogInputResponseParser
    {
        double ParseResponse(string ipxResponse, int inputNumber);
    }
}