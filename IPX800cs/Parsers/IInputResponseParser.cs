namespace software.elendil.IPX800.Parsers
{
    public interface IInputResponseParser<out T>
    {
        T ParseResponse(string ipxResponse, int inputNumber);
    }
}