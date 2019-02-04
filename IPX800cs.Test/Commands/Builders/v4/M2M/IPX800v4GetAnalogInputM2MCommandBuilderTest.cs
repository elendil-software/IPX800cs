using software.elendil.IPX800.Commands.Builders.v4.M2M;
using software.elendil.IPX800.IO;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v4.M2M
{
    public class IPX800v4GetAnalogInputM2MCommandBuilderTest
    {   
        [Fact]
        public void BuildCommandString_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new IPX800v4GetAnalogInputM2MCommandBuilder();
            var input = new Input {Type = InputType.AnalogInput, Number = 2, };
            
            //Act
            string command = commandBuilder.BuildCommandString(input);
            
            //Assert
            Assert.Equal("Get=A", command);       
        }
    }
}