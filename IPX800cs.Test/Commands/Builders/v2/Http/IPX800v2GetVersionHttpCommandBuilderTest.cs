using IPX800cs.Commands.Builders.v2.Http;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v2.Http
{
    public class IPX800v2GetVersionHttpCommandBuilderTest
    {   
        [Fact]
        public void BuildCommandString_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new IPX800v2GetVersionHttpCommandBuilder();
            
            //Act
            string command = commandBuilder.BuildCommandString();
            
            //Assert
            Assert.Equal("status.xml", command);       
        }
    }
}