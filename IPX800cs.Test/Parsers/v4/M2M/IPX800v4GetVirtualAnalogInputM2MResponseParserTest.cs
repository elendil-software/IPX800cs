using software.elendil.IPX800.Parsers.v4.M2M;
using Xunit;

namespace IPX800cs.Test.Parsers.v4.M2M
{
    public class IPX800v4GetVirtualAnalogInputM2MResponseParserTest
    {
        private const string headedResponse = "VA1=0&VA2=0&VA3=0&VA4=0&VA5=0&VA6=0&VA7=0&VA8=0&VA9=0&VA10=0&VA11=0&VA12=0&VA13=0&VA14=0&VA15=0&VA16=0&VA17=0&VA18=0&VA19=0&VA20=0&VA21=0&VA22=0&VA23=0&VA24=0&VA25=0&VA26=0&VA27=0&VA28=0&VA29=0&VA30=0&VA31=0&VA32=0";
        private const string response = "0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0\r\n";
    
        [Fact]
        public void GivenValidResponse_ParseResponse_ReturnsExpectedResponse()
        {
            //Arrange
            var parser = new IPX800v4GetVirtualAnalogInputM2MResponseParser();
            var ipxResponse = "";

            //Act
            double response = parser.ParseResponse(ipxResponse, 2);
            
            //Assert
            Assert.Equal(1, response);
        }
    }
}