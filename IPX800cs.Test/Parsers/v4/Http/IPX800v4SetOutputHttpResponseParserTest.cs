using IPX800cs.Exceptions;
using IPX800cs.Parsers.v4.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v4.Http
{
    public class IPX800v4SetOutputHttpResponseParserTest
    {
        [Fact]
        public void GivenSuccess_ParseResponse_ReturnsTrue()
        {
            //Arrange
            var parser = new IPX800v4SetOutputHttpResponseParser();
            string JsonSuccessResponse = @"{
                                            ""product"": ""IPX800_V4"",
                                            ""status"": ""Success""
                                        }";

            //Act
            bool response = parser.ParseResponse(JsonSuccessResponse);
            
            //Assert
            Assert.True(response);
        }
        
        [Fact]
        public void GivenError_ParseResponse_ReturnsFalse()
        {
            //Arrange
            var parser = new IPX800v4SetOutputHttpResponseParser();
            string JsonErrorResponse = @"{
                                            ""product"": ""IPX800_V4"",
                                            ""status"": ""Error""
                                        }";

            //Act
            bool response = parser.ParseResponse(JsonErrorResponse);
            
            //Assert
            Assert.False(response);
        }
        
        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        [InlineData("[]")]
        [InlineData("{}")]
        [InlineData("{\"product\": \"IPX800_V4\", \"unknownProperty\": \"SomeValue\"}")]
        public void GivenInvalidResponse_ParseResponse_ThrowsInvalidResponseException(string invalidresponse)
        {
            //Arrange
            var parser = new IPX800v4SetOutputHttpResponseParser();

            //Act/Assert
            Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidresponse));
        }
    }
}