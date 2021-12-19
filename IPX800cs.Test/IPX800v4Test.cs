namespace IPX800cs.Test;

public class IPX800v4Test : IPX800BaseTest
{
    public IPX800v4Test()
    {
        SetupMocks();
        _ipx800 = new IPX800V4(IPX800Protocol.Http, _commandFactory.Object, _commandSender.Object, _responseParserFactory.Object);
    }
}