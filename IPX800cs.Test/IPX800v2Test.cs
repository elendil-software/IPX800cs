using IPX800cs.Exceptions;
using IPX800cs.IO;
using Xunit;

namespace IPX800cs.Test;

public class IPX800v2Test : IPX800BaseTest
{
    public IPX800v2Test()
    {
        SetupMocks();
        _ipx800 = new IPX800V2(IPX800Protocol.Http, _commandFactory.Object, _commandSender.Object, _responseParserFactory.Object);
    }

    public override void GetInputsTest()
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => _ipx800.GetInputs(InputType.DigitalInput));
    }

    public override void GetAnalogInputsTest()
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => _ipx800.GetAnalogInputs(AnalogInputType.AnalogInput));
    }

    public override void GetOutputsTest()
    {
        Assert.Throws<IPX800NotSupportedCommandException>(() => _ipx800.GetOutputs(OutputType.Output));
    }
}