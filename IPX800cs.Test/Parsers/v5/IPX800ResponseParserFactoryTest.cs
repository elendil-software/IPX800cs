using IPX800cs.Parsers.v5;
using Xunit;

namespace IPX800cs.Test.Parsers.v5;

public class IPX800V5ResponseParserFactoryTest
{
    [Fact] 
    public void GetTimersParser_ReturnsParserCorrespondingToContext()
    {
        var responseParserFactory = new IPX800V5ResponseParserFactory();

        var parser = responseParserFactory.CreateGetTimersParser();
        Assert.Equal(typeof(IPX800V5GetTemposResponseParser), parser.GetType());
    }
}