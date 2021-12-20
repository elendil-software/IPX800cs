using System.Collections.Generic;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v4.M2M;
using Xunit;

namespace IPX800cs.Test.Parsers.v4.M2M;

public class IPX800v4GetVirtualOutputsM2MResponseParserTest
{
    private const string HeadedResponse = "VO=1&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0&0";
    private const string Response = "10000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000\r\n";

    [Theory]
    [InlineData(HeadedResponse)]
    [InlineData(Response)]
    public void GivenActiveOutput_ParseResponse_ReturnsActive(string ipxResponse)
    {
        //Arrange
        var parser = new IPX800v4GetVirtualOutputsM2MResponseParser();
        var expectedResponse = new Dictionary<int, OutputState>
        {
            {1, OutputState.Active},
            {2, OutputState.Inactive},
            {3, OutputState.Inactive},
            {4, OutputState.Inactive},
            {5, OutputState.Inactive},
            {6, OutputState.Inactive},
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
            {56, OutputState.Inactive},
            {57, OutputState.Inactive},
            {58, OutputState.Inactive},
            {59, OutputState.Inactive},
            {60, OutputState.Inactive},
            {61, OutputState.Inactive},
            {62, OutputState.Inactive},
            {63, OutputState.Inactive},
            {64, OutputState.Inactive},
            {65, OutputState.Inactive},
            {66, OutputState.Inactive},
            {67, OutputState.Inactive},
            {68, OutputState.Inactive},
            {69, OutputState.Inactive},
            {70, OutputState.Inactive},
            {71, OutputState.Inactive},
            {72, OutputState.Inactive},
            {73, OutputState.Inactive},
            {74, OutputState.Inactive},
            {75, OutputState.Inactive},
            {76, OutputState.Inactive},
            {77, OutputState.Inactive},
            {78, OutputState.Inactive},
            {79, OutputState.Inactive},
            {80, OutputState.Inactive},
            {81, OutputState.Inactive},
            {82, OutputState.Inactive},
            {83, OutputState.Inactive},
            {84, OutputState.Inactive},
            {85, OutputState.Inactive},
            {86, OutputState.Inactive},
            {87, OutputState.Inactive},
            {88, OutputState.Inactive},
            {89, OutputState.Inactive},
            {90, OutputState.Inactive},
            {91, OutputState.Inactive},
            {92, OutputState.Inactive},
            {93, OutputState.Inactive},
            {94, OutputState.Inactive},
            {95, OutputState.Inactive},
            {96, OutputState.Inactive},
            {97, OutputState.Inactive},
            {98, OutputState.Inactive},
            {99, OutputState.Inactive},
            {100, OutputState.Inactive},
            {101, OutputState.Inactive},
            {102, OutputState.Inactive},
            {103, OutputState.Inactive},
            {104, OutputState.Inactive},
            {105, OutputState.Inactive},
            {106, OutputState.Inactive},
            {107, OutputState.Inactive},
            {108, OutputState.Inactive},
            {109, OutputState.Inactive},
            {110, OutputState.Inactive},
            {111, OutputState.Inactive},
            {112, OutputState.Inactive},
            {113, OutputState.Inactive},
            {114, OutputState.Inactive},
            {115, OutputState.Inactive},
            {116, OutputState.Inactive},
            {117, OutputState.Inactive},
            {118, OutputState.Inactive},
            {119, OutputState.Inactive},
            {120, OutputState.Inactive},
            {121, OutputState.Inactive},
            {122, OutputState.Inactive},
            {123, OutputState.Inactive},
            {124, OutputState.Inactive},
            {125, OutputState.Inactive},
            {126, OutputState.Inactive},
            {127, OutputState.Inactive},
            {128, OutputState.Inactive}
        };
            
        //Act
        var response = parser.ParseResponse(ipxResponse);
            
        //Assert
        Assert.Equal(expectedResponse, response);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    [InlineData("Some Invalid String")]
    public void GivenInvalidResponse_ParseResponse_ThrowsInvalidResponseException(string invalidresponse)
    {
        //Arrange
        var parser = new IPX800v4GetVirtualOutputsM2MResponseParser();

        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidresponse));
    }
}