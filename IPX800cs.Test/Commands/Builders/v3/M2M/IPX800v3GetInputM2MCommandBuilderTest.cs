using IPX800cs.Commands.Builders.v3.M2M;
using IPX800cs.IO;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v3.M2M
{
    public class IPX800v3GetInputM2MCommandBuilderTest
    {   
        [Fact]
        public void BuildCommandString_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new IPX800v3GetInputM2MCommandBuilder();
            var input = new Input {Type = InputType.DigitalInput, Number = 2, };
            
            //Act
            string command = commandBuilder.BuildCommandString(input);
            
            //Assert
            Assert.Equal("GetIn2", command);       
        }
    }
}