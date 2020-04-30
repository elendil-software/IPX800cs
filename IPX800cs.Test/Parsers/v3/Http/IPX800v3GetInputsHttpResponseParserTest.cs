using System.Collections.Generic;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v3.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v3.Http
{
    public class IPX800v3GetInputsHttpResponseParserTest
    {
        [Fact]
        public void GivenValidResponse_ParseResponse_ReturnsExpectedValues()
        {
            //Arrange
            var parser = new IPX800v3GetInputsHttpResponseParser();
            var jsonResponse = "{\"product\":\"IPX800_V3\",\"IN1\":0,\"IN2\":0,\"IN3\":0,\"IN4\":0,\"IN5\":1,\"IN6\":1,\"IN7\":0,\"IN8\":1,\"IN9\":0,\"IN10\":0,\"IN11\":0,\"IN12\":0,\"IN13\":0,\"IN14\":0,\"IN15\":0,\"IN16\":0,\"IN17\":0,\"IN18\":0,\"IN19\":0,\"IN20\":0,\"IN21\":0,\"IN22\":0,\"IN23\":0,\"IN24\":0,\"IN25\":0,\"IN26\":0,\"IN27\":0,\"IN28\":0,\"IN29\":0,\"IN30\":0,\"IN31\":0,\"IN32\":0}";
            var expectedResponse = new Dictionary<int, InputState>
            {
                {1, InputState.Inactive},
                {2, InputState.Inactive},
                {3, InputState.Inactive},
                {4, InputState.Inactive},
                {5, InputState.Active},
                {6, InputState.Active},
                {7, InputState.Inactive},
                {8, InputState.Active},
                {9, InputState.Inactive},
                {10, InputState.Inactive},
                {11, InputState.Inactive},
                {12, InputState.Inactive},
                {13, InputState.Inactive},
                {14, InputState.Inactive},
                {15, InputState.Inactive},
                {16, InputState.Inactive},
                {17, InputState.Inactive},
                {18, InputState.Inactive},
                {19, InputState.Inactive},
                {20, InputState.Inactive},
                {21, InputState.Inactive},
                {22, InputState.Inactive},
                {23, InputState.Inactive},
                {24, InputState.Inactive},
                {25, InputState.Inactive},
                {26, InputState.Inactive},
                {27, InputState.Inactive},
                {28, InputState.Inactive},
                {29, InputState.Inactive},
                {30, InputState.Inactive},
                {31, InputState.Inactive},
                {32, InputState.Inactive}
            };

            //Act
            Dictionary<int, InputState> response = parser.ParseResponse(jsonResponse);
            
            //Assert
            Assert.Equal(expectedResponse, response);
        }
        
        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        [InlineData("[]")]
        [InlineData("{}")]
        public void GivenInvalidResponse_ParseResponse_ThrowsIPX800InvalidResponseException(string invalidResponse)
        {
            //Arrange
            var parser = new IPX800v3GetInputsHttpResponseParser();

            //Act/Assert
            Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidResponse));
        }
    }
}