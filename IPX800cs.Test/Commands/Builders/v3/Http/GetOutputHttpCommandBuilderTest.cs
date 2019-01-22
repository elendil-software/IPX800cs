using software.elendil.IPX800.Commands.Builders.v3.Http;
using software.elendil.IPX800.IO;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v3.Http
{
    public class GetOutputHttpCommandBuilderTest
    {   
        [Fact]
        public void BuildCommandString_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new GetOutHttpCommandBuilder();
            var output = new IPX800Output {Type = OutputType.Output, Number = 2, IsDelayed = false, IsVirtual = false};
            
            //Act
            string command = commandBuilder.BuildCommandString(output);
            
            //Assert
            Assert.Equal("globalstatus.xml", command);       
        }
    }
}