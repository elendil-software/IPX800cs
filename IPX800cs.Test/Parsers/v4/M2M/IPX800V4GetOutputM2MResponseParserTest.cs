using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v4.M2M;
using Xunit;

namespace IPX800cs.Test.Parsers.v4.M2M;

public class IPX800V4GetOutputM2MResponseParserTest
{
    private const string HeadedResponse = "R01=0&R02=0&R03=1&R04=0&R05=0&R06=1&R07=1&R08=0&R09=0&R10=0&R11=0&R12=0&R13=0&R14=0&R15=0&R16=0&R17=0&R18=0&R19=0&R20=0&R21=0&R22=0&R23=0&R24=0&R25=0&R26=0&R27=0&R28=0&R29=0&R30=0&R31=0&R32=0&R33=0&R34=0&R35=0&R36=0&R37=0&R38=0&R39=0&R40=0&R41=0&R42=0&R43=0&R44=0&R45=0&R46=0&R47=0&R48=0&R49=0&R50=0&R51=0&R52=0&R53=0&R54=0&R55=0&R56=0";
    private const string Response = "00100110000000000000000000000000000000000000000000000000\r\n";

    [Theory]
    [InlineData(HeadedResponse)]
    [InlineData(Response)]
    public void GivenActiveOutput_ParseResponse_ReturnsActive(string ipxResponse)
    {
        //Arrange
        var parser = new IPX800V4GetOutputM2MResponseParser();

        //Act
        OutputState response = parser.ParseResponse(ipxResponse, 3);
            
        //Assert
        Assert.Equal(OutputState.Active, response);
    }

    [Theory]
    [InlineData(HeadedResponse)]
    [InlineData(Response)]
    public void GivenInactiveOutput_ParseResponse_ReturnsInactive(string ipxResponse)
    {
        //Arrange
        var parser = new IPX800V4GetOutputM2MResponseParser();

        //Act
        OutputState response = parser.ParseResponse(ipxResponse, 2);
            
        //Assert
        Assert.Equal(OutputState.Inactive, response);
    }
        
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    [InlineData("Some Invalid String")]
    public void GivenInvalidResponse_ParseResponse_ThrowsInvalidResponseException(string invalidresponse)
    {
        //Arrange
        var parser = new IPX800V4GetOutputM2MResponseParser();

        //Act/Assert
        Assert.Throws<IPX800InvalidResponseException>(() => parser.ParseResponse(invalidresponse, 2));
    }
}