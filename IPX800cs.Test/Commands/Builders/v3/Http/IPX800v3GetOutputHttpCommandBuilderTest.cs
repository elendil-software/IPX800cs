using software.elendil.IPX800.Commands.Builders.v3.Http;
using software.elendil.IPX800.IO;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v3.Http
{
    public class IPX800v3GetOutputHttpCommandBuilderTest
    {   
        [Fact]
        public void BuildCommandString_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new IPX800v3GetOutputHttpCommandBuilder();
            var output = new Output {Type = OutputType.Output, Number = 2, IsDelayed = false, };
            
            //Act
            string command = commandBuilder.BuildCommandString(output);
            
            //Assert
            Assert.Equal("globalstatus.xml", command);       
        }
    }
}