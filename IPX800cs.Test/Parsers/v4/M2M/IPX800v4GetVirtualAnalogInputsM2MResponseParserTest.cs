using System.Collections.Generic;
using IPX800cs.Parsers.v4.M2M;
using Xunit;

namespace IPX800cs.Test.Parsers.v4.M2M
{
    public class IPX800v4GetVirtualAnalogInputsM2MResponseParserTest
    {
        private const string HeadedResponse = "VA1=0&VA2=0&VA3=1&VA4=0&VA5=0&VA6=0&VA7=0&VA8=0&VA9=0&VA10=0&VA11=0&VA12=0&VA13=0&VA14=0&VA15=0&VA16=0&VA17=0&VA18=0&VA19=0&VA20=0&VA21=0&VA22=0&VA23=0&VA24=0&VA25=0&VA26=0&VA27=0&VA28=0&VA29=0&VA30=0&VA31=0&VA32=0";
        private const string Response = "0&0&1&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0\r\n";

        [Theory]
        [InlineData(HeadedResponse)]
        [InlineData(Response)]
        public void GivenValidResponse_ParseResponse_ReturnsExpectedResponse(string ipxResponse)
        {
            //Arrange
            var parser = new IPX800v4GetVirtualAnalogInputsM2MResponseParser();
            var expectedResponse = new Dictionary<int, int>
            {
                {1, 0},
                {2, 0},
                {3, 1},
                {4, 0},
                {5, 0},
                {6, 0},
                {7, 0},
                {8, 0},
                {9, 0},
                {10, 0},
                {11, 0},
                {12, 0},
                {13, 0},
                {14, 0},
                {15, 0},
                {16, 0},
                {17, 0},
                {18, 0},
                {19, 0},
                {20, 0},
                {21, 0},
                {22, 0},
                {23, 0},
                {24, 0},
                {25, 0},
                {26, 0},
                {27, 0},
                {28, 0},
                {29, 0},
                {30, 0},
                {31, 0},
                {32, 0}
            };

            //Act
            var response = parser.ParseResponse(ipxResponse);
            
            //Assert
            Assert.Equal(expectedResponse, response);
        }
    }
}