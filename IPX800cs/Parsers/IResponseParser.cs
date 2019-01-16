namespace software.elendil.IPX800.Parsers
{
    public interface IResponseParser<out T, in TDeviceResponse>
    {
        T ParseResponse(TDeviceResponse ipxResponse, int ioNumber);
    }
}