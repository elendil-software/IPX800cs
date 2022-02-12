namespace IPX800cs.Parsers;

public interface IGetAnalogInputResponseParser
{
    double ParseResponse(string ipxResponse, int inputNumber);
}