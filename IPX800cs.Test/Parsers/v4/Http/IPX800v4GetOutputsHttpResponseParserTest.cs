using System.Collections.Generic;
using IPX800cs.IO;
using IPX800cs.Parsers.v4.Http;
using Xunit;

namespace IPX800cs.Test.Parsers.v4.Http
{
    public class IPX800v4GetOutputsHttpResponseParserTest
    {
        [Fact]
        public void GivenValidResponse_ParseResponse_ReturnsExpectedValues()
        {
            //Arrange
            var parser = new IPX800v4GetOutputsHttpResponseParser();
            var expectedResponse = new Dictionary<int, OutputState>
            {
                {1, OutputState.Inactive},
                {2, OutputState.Inactive},
                {3, OutputState.Active},
                {4, OutputState.Inactive},
                {5, OutputState.Inactive},
                {6, OutputState.Active},
                {7, OutputState.Active},
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
                {32, OutputState.Inactive},
                {33, OutputState.Inactive},
                {34, OutputState.Inactive},
                {35, OutputState.Inactive},
                {36, OutputState.Inactive},
                {37, OutputState.Inactive},
                {38, OutputState.Inactive},
                {39, OutputState.Inactive},
                {40, OutputState.Inactive},
                {41, OutputState.Inactive},
                {42, OutputState.Inactive},
                {43, OutputState.Inactive},
                {44, OutputState.Inactive},
                {45, OutputState.Inactive},
                {46, OutputState.Inactive},
                {47, OutputState.Inactive},
                {48, OutputState.Inactive},
                {49, OutputState.Inactive},
                {50, OutputState.Inactive},
                {51, OutputState.Inactive},
                {52, OutputState.Inactive},
                {53, OutputState.Inactive},
                {54, OutputState.Inactive},
                {55, OutputState.Inactive},
                {56, OutputState.Inactive}
            };

            //Act
            var response = parser.ParseResponse(IPX800v4JsonResponse.GetOutputsJsonResponse);
            
            //Assert
            Assert.Equal(expectedResponse, response);
        }
    }
}