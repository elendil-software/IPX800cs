using software.elendil.IPX800.Commands.Builders.v4.M2M;
using software.elendil.IPX800.IO;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v4.M2M
{
    public class GetInputM2MCommandBuilderTest
    {   
        [Fact]
        public void BuildCommandString_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new GetInCommandBuilder();
            var input = new IPX800Input {Type = InputType.DigitalInput, Number = 2, IsVirtual = false};
            
            //Act
            string command = commandBuilder.BuildCommandString(input);
            
            //Assert
            Assert.Equal("Get=D", command);       
        }
    }
}