using software.elendil.IPX800.Commands.Builders.v2.M2M;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v2.M2M
{
    public class GetVersionM2MCommandBuilderTest
    {   
        [Fact]
        public void BuildCommandString_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new IPX800v2GetVersionM2MCommandBuilder();
            
            //Act
            string command = commandBuilder.BuildCommandString();
            
            //Assert
            Assert.Equal("GetVersion", command);       
        }
    }
}