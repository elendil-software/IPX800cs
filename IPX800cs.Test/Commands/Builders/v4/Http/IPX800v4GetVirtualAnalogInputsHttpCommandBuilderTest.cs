using IPX800cs.Commands.Builders.v4.Http;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v4.Http
{
    public class IPX800v4GetVirtualAnalogInputsHttpCommandBuilderTest
    {
        [Fact]
        public void BuildCommandString_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new IPX800v4GetVirtualAnalogInputsHttpCommandBuilder();

            //Act
            string command = commandBuilder.BuildCommandString();

            //Assert
            Assert.Equal("/api/xdevices.json?Get=VA", command);
        }
    }
}