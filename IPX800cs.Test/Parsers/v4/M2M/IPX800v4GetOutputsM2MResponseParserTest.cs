using System.Collections.Generic;
using IPX800cs.IO;
using IPX800cs.Parsers.v4.M2M;
using Xunit;

namespace IPX800cs.Test.Parsers.v4.M2M
{
    public class IPX800v4GetOutputsM2MResponseParserTest
    {
        private const string HeadedResponse = "R01=0&R02=0&R03=1&R04=0&R05=0&R06=1&R07=1&R08=0&R09=0&R10=0&R11=0&R12=0&R13=0&R14=0&R15=0&R16=0&R17=0&R18=0&R19=0&R20=0&R21=0&R22=0&R23=0&R24=0&R25=0&R26=0&R27=0&R28=0&R29=0&R30=0&R31=0&R32=0&R33=0&R34=0&R35=0&R36=0&R37=0&R38=0&R39=0&R40=0&R41=0&R42=0&R43=0&R44=0&R45=0&R46=0&R47=0&R48=0&R49=0&R50=0&R51=0&R52=0&R53=0&R54=0&R55=0&R56=0";
        private const string Response = "00100110000000000000000000000000000000000000000000000000\r\n";

        [Theory]
        [InlineData(HeadedResponse)]
        [InlineData(Response)]
        public void GivenValidResponse_ParseResponse_ReturnsExpectedValues(string ipxResponse)
        {
            //Arrange
            var parser = new IPX800v4GetOutputsM2MResponseParser();
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
            var response = parser.ParseResponse(ipxResponse);
            
            //Assert
            Assert.Equal(expectedResponse, response);
        }
    }
}