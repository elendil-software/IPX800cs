using IPX800cs.Commands.Builders.v3.Http;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v3.Http
{
    public class IPX800v3GetOutputsHttpCommandBuilderTest
    {   
        [Fact]
        public void BuildCommandString_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new IPX800v3GetOutputsHttpCommandBuilder();
            
            //Act
            string command = commandBuilder.BuildCommandString();
            
            //Assert
            Assert.Equal("/api/xdevices.json?cmd=20", command);       
        }
    }
}