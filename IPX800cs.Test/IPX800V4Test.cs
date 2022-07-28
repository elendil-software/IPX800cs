namespace IPX800cs.Test;

public class IPX800V4Test : IPX800BaseTest
{
    public IPX800V4Test()
    {
        SetupMocks();
        _ipx800 = new IPX800V4(IPX800Protocol.Http, _commandFactory.Object, _commandSender.Object, _responseParserFactory.Object);
    }
}