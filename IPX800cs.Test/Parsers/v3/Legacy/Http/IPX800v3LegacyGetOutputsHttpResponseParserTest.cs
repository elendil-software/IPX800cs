using System.Collections.Generic;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v3.Legacy.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v3.Legacy.Http
{
    public class IPX800v3LegacyGetOutputsHttpResponseParserTest
    {
        [Fact]
        public void GivenValidResponse_ParseResponse_ReturnsExpectedValues()
        {
            //Arrange
            var parser = new IPX800v3LegacyGetOutputsHttpResponseParser();
            var expectedResponse = new Dictionary<int, OutputState>
            {
                {1, OutputState.Inactive},
                {2, OutputState.Active},
                {3, OutputState.Active},
                {4, OutputState.Inactive},
                {5, OutputState.Inactive},
                {6, OutputState.Active},
                {7, OutputState.Inactive},
                {8, OutputState.Inactive},
                {9, OutputState.Inactive},
                {10, OutputState.Inactive},
                {11, OutputState.Inactive},
                {12, OutputState.Inactive},
                {13, OutputState.Inactive},
                {14, OutputState.Inactive},
                {15, OutputState.Inactive},
                {16, OutputState.Inactive},
                {17, OutputState.Inactive},
                {18, OutputState.Inactive},
                {19, OutputState.Inactive},
                {20, OutputState.Inactive},
                {21, OutputState.Inactive},
                {22, OutputState.Inactive},
                {23, OutputState.Inactive},
                {24, OutputState.Inactive},
                {25, OutputState.Inactive},
                {26, OutputState.Inactive},
                {27, OutputState.Inactive},
                {28, OutputState.Inactive},
                {29, OutputState.Inactive},
                {30, OutputState.Inactive},
                {31, OutputState.Inactive},
                {32, OutputState.Inactive}
            };

            //Act
            Dictionary<int, OutputState> response = parser.ParseResponse(IPX800v3LegacyHttpResponse.XmlIpx800v3Legacy);
            
            //Assert
            Assert.Equal(expectedResponse, response);
        }
        
        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        [InlineData("[]")]
        [InlineData("{}")]
        [InlineData("Some Invalid String")]
        public void GivenInvalidResponse_ParseResponse_ThrowsIPX800InvalidResponseException(string invalidResponse)
        {
            //Arrange
            var parser = new IPX800v3LegacyGetOutputsHttpResponseParser();

            //Act/Assert
            Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidResponse));
        }
    }
}