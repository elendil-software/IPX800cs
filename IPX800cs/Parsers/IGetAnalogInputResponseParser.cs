namespace IPX800cs.Parsers;
#pragma warning disable CS1591

public interface IGetAnalogInputResponseParser
{
    double ParseResponse(string ipxResponse, int inputNumber);
}