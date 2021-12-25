using IPX800cs.Exceptions;
using IPX800cs.IO;
using Xunit;

namespace IPX800cs.Test;

public class IPX800v3Test : IPX800BaseTest
{
    public IPX800v3Test()
    {
        SetupMocks();
        _ipx800 = new IPX800V3(IPX800Protocol.Http, _commandFactory.Object, _commandSender.Object, _responseParserFactory.Object);
    }
        
    public override void GetAnalogInputsTest()
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => _ipx800.GetAnalogInputs(AnalogInputType.AnalogInput));
    }
}