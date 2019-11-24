using IPX800cs.Commands.Builders.v3.Legacy.Http;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v3.Legacy.Http
{
    public class IPX800v3LegacyGetInputsHttpCommandBuilderTest
    {   
        [Fact]
        public void BuildCommandString_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new IPX800v3LegacyGetInputsHttpCommandBuilder();
            
            //Act
            string command = commandBuilder.BuildCommandString();
            
            //Assert
            Assert.Equal(IPX800TestConst.StatusXml, command);       
        }
    }
}