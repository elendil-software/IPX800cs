using software.elendil.IPX800.Commands.Builders.v3.M2M;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v3.M2M
{
    public class IPX800v3GetVersionM2MCommandBuilderTest
    {   
        [Fact]
        public void BuildCommandString_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new IPX800v3GetVersionM2MCommandBuilder();
            
            //Act
            string command = commandBuilder.BuildCommandString();
            
            //Assert
            Assert.Equal("GetVersion", command);       
        }
    }
}