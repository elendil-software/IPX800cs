using IPX800cs.Commands.Builders.v4.Http;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v4.Http
{
    public class IPX800v4GetOutputsHttpCommandBuilderTest
    {   
        [Fact]
        public void BuildCommandString_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new IPX800v4GetOutputsHttpCommandBuilder();
            
            //Act
            string command = commandBuilder.BuildCommandString();
            
            //Assert
            Assert.Equal("/api/xdevices.json?Get=R", command);       
        }
    }
}