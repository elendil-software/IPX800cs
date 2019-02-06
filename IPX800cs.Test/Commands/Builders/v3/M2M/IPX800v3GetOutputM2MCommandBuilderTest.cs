using IPX800cs.Commands.Builders.v3.M2M;
using IPX800cs.IO;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v3.M2M
{
    public class IPX800v3GetOutputM2MCommandBuilderTest
    {   
        [Fact]
        public void BuildCommandString_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new IPX800v3GetOutputM2MCommandBuilder();
            var output = new Output {Type = OutputType.Output, Number = 2, IsDelayed = false, };
            
            //Act
            string command = commandBuilder.BuildCommandString(output);
            
            //Assert
            Assert.Equal("GetOut2", command);       
        }
    }
}