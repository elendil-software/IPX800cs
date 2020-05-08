using System.Collections.Generic;
using IPX800cs.Exceptions;
using IPX800cs.Parsers.v4.M2M;
using Xunit;

namespace IPX800cs.Test.Parsers.v4.M2M
{
    public class IPX800v4GetAnalogInputsM2MResponseParserTest
    {
        private const string HeadedResponse = "A1=9216&A2=0&A3=0&A4=0\r\n";
        private const string Response = "9216&0&0&0\r\n";

        [Theory]
        [InlineData(HeadedResponse)]
        [InlineData(Response)]
        public void GivenResponse_ParseResponse_ReturnsExpectedResponse(string ipxResponse)
        {
            //Arrange
            var parser = new IPX800v4GetAnalogInputsM2MResponseParser();
            var expectedResponse = new Dictionary<int, int>
            {
                {1, 9216},
                {2, 0},
                {3, 0},
                {4, 0}
            };
            
            //Act
            var result = parser.ParseResponse(ipxResponse);
            
            //Assert
            Assert.Equal(expectedResponse, result);
        }
        
        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        [InlineData("Some Invalid String")]
        public void GivenInvalidResponse_ParseResponse_ThrowsInvalidResponseException(string invalidresponse)
        {
            //Arrange
            var parser = new IPX800v4GetAnalogInputsM2MResponseParser();

            //Act/Assert
            Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidresponse));
        }
    }
}