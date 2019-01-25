namespace software.elendil.IPX800.Parsers
{
    public interface IAnalogInputResponseParser
    {
        double ParseResponse(string ipxResponse, int inputNumber);
    }
}