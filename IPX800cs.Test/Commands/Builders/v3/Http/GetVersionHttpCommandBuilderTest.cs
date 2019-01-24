using software.elendil.IPX800.Commands.Builders.v3.Http;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v3.Http
{
    public class GetVersionHttpCommandBuilderTest
    {   
        [Fact]
        public void BuildCommandString_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new IPX800v3GetVersionHttpCommandBuilder();
            
            //Act
            string command = commandBuilder.BuildCommandString();
            
            //Assert
            Assert.Equal("globalstatus.xml", command);       
        }
    }
}