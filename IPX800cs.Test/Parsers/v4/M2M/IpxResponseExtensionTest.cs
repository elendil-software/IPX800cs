using IPX800cs.Parsers.v4.M2M;
using Xunit;

namespace IPX800cs.Test.Parsers.v4.M2M
{
    public class IpxResponseExtensionTest
    {
        [Theory]
        [InlineData("A1=9232&A2=0&A3=0&A4=0\r\n", ResponseType.WithHeader)]
        [InlineData("9216&0&0&0\r\n", ResponseType.WithoutHeader)]
        [InlineData("00011100000000000000000000000000000000000000000000000000\r\n", ResponseType.NumberOnly)]
        [InlineData("VA1=0&VA2=0&VA3=1&VA4=0&VA5=0&VA6=0&VA7=0&VA8=0&VA9=0\r\n", ResponseType.WithHeader)]
        public void Test(string response, ResponseType expectedType)
        {
            ResponseType type = response.CheckAndGetResponseType();
            
            Assert.Equal(expectedType, type);
        }
    }
}