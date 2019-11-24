using IPX800cs.Commands.Builders.v4.M2M;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v4.M2M
{
    public class IPX800v4GetAnalogInputsM2MCommandBuilderTest
    {
        [Fact]
        public void BuildCommandString_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new IPX800v4GetAnalogInputsM2MCommandBuilder();

            //Act
            string command = commandBuilder.BuildCommandString();

            //Assert
            Assert.Equal("Get=A", command);
        }
    }
}