using IPX800cs.Commands.Builders.v3.Legacy.Http;
using IPX800cs.IO;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v3.Legacy.Http
{
    public class IPX800v3LegacyGetAnalogInputHttpCommandBuilderTest
    {   
        [Fact]
        public void BuildCommandString_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new IPX800v3LegacyGetAnalogInputHttpCommandBuilder();
            var input = new Input {Type = InputType.AnalogInput, Number = 2, };
            
            //Act
            string command = commandBuilder.BuildCommandString(input);
            
            //Assert
            Assert.Equal("status.xml", command);       
        }
    }
}