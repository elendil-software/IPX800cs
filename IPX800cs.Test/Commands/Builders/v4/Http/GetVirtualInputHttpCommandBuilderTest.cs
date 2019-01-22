using software.elendil.IPX800.Commands.Builders.v4.Http;
using software.elendil.IPX800.IO;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v4.Http
{
    public class GetVirtualInputHttpCommandBuilderTest
    {   
        [Fact]
        public void BuildCommandString_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new GetVirtualInHttpCommandBuilder();
            var input = new IPX800Input {Type = InputType.DigitalInput, Number = 2, IsVirtual = false};
            
            //Act
            string command = commandBuilder.BuildCommandString(input);
            
            //Assert
            Assert.Equal("/api/xdevices.json?Get=VI", command);       
        }
    }
}