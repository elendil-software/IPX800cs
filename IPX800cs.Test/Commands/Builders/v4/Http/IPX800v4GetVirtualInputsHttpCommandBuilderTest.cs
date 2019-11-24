using IPX800cs.Commands.Builders.v4.Http;
using IPX800cs.IO;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v4.Http
{
    public class IPX800v4GetVirtualInputsHttpCommandBuilderTest
    {
        [Fact]
        public void BuildCommandString_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new IPX800v4GetVirtualInputsHttpCommandBuilder();
            var input = new Input { Type = InputType.DigitalInput};

            //Act
            string command = commandBuilder.BuildCommandString();

            //Assert
            Assert.Equal("/api/xdevices.json?Get=VI", command);
        }
    }
}