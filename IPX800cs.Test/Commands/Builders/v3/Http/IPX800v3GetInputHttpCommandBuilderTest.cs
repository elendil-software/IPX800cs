using IPX800cs.Commands.Builders.v3.Http;
using IPX800cs.IO;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v3.Http
{
    public class IPX800v3GetInputHttpCommandBuilderTest
    {   
        [Fact]
        public void BuildCommandString_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new IPX800v3GetInputHttpCommandBuilder();
            var input = new Input {Type = InputType.DigitalInput, Number = 2, };
            
            //Act
            string command = commandBuilder.BuildCommandString(input);
            
            //Assert
            Assert.Equal("globalstatus.xml", command);       
        }
    }
}