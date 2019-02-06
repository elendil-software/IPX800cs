using IPX800cs.Commands.Builders.v4.Http;
using IPX800cs.IO;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v4.Http
{
    public class IPX800v4GetVirtualAnalogInputHttpCommandBuilderTest
    {   
        [Fact]
        public void BuildCommandString_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new IPX800v4GetVirtualAnalogInputHttpCommandBuilder();
            var input = new Input {Type = InputType.AnalogInput, Number = 2, };
            
            //Act
            string command = commandBuilder.BuildCommandString(input);
            
            //Assert
            Assert.Equal("/api/xdevices.json?Get=VA", command);       
        }
    }
}