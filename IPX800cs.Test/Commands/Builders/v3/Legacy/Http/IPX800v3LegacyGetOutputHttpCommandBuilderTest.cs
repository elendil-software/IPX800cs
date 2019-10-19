using IPX800cs.Commands.Builders.v3.Legacy.Http;
using IPX800cs.IO;
using IPX800cs.Test.Commands.Builders.v2;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v3.Legacy.Http
{
    public class IPX800v3LegacyGetOutputHttpCommandBuilderTest
    {   
        [Fact]
        public void BuildCommandString_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new IPX800v3LegacyGetOutputHttpCommandBuilder();
            var output = new Output {Type = OutputType.Output, Number = 2, IsDelayed = false, };
            
            //Act
            string command = commandBuilder.BuildCommandString(output);
            
            //Assert
            Assert.Equal(IPX800TestConst.StatusXml, command);       
        }
    }
}