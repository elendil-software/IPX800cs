namespace IPX800cs.Parsers;

public interface IGetAnalogInputResponseParser
{
    int ParseResponse(string ipxResponse, int inputNumber);
}