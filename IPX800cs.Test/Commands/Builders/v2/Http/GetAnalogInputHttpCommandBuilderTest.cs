using software.elendil.IPX800.Commands.Builders.v2.Http;
using software.elendil.IPX800.IO;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v2.Http
{
    public class GetAnalogInputHttpCommandBuilderTest
    {   
        [Fact]
        public void BuildCommandString_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new IPX800v2GetAnalogInputHttpCommandBuilder();
            var input = new Input {Type = InputType.AnalogInput, Number = 2};
            
            //Act
            string command = commandBuilder.BuildCommandString(input);
            
            //Assert
            Assert.Equal("status.xml", command);       
        }
    }
}