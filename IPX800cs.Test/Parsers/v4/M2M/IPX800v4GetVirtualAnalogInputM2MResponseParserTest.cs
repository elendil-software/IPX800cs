using IPX800cs.Exceptions;
using IPX800cs.Parsers.v4.M2M;
using Xunit;

namespace IPX800cs.Test.Parsers.v4.M2M
{
    public class IPX800v4GetVirtualAnalogInputM2MResponseParserTest
    {
        private const string HeadedResponse = "VA1=0&VA2=0&VA3=1&VA4=0&VA5=0&VA6=0&VA7=0&VA8=0&VA9=0&VA10=0&VA11=0&VA12=0&VA13=0&VA14=0&VA15=0&VA16=0&VA17=0&VA18=0&VA19=0&VA20=0&VA21=0&VA22=0&VA23=0&VA24=0&VA25=0&VA26=0&VA27=0&VA28=0&VA29=0&VA30=0&VA31=0&VA32=0";
        private const string Response = "0&0&1&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0\r\n";

        [Theory]
        [InlineData(HeadedResponse)]
        [InlineData(Response)]
        public void GivenValidResponse_ParseResponse_ReturnsExpectedResponse(string ipxResponse)
        {
            //Arrange
            var parser = new IPX800v4GetVirtualAnalogInputM2MResponseParser();

            //Act
            double response = parser.ParseResponse(ipxResponse, 3);
            
            //Assert
            Assert.Equal(1, response);
        }
        
        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        [InlineData("Some Invalid String")]
        public void GivenInvalidResponse_ParseResponse_ThrowsInvalidResponseException(string invalidresponse)
        {
            //Arrange
            var parser = new IPX800v4GetVirtualAnalogInputM2MResponseParser();

            //Act/Assert
            Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidresponse, 2));
        }
    }
}