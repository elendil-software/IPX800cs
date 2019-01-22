using software.elendil.IPX800.Commands.Builders.v2.Http;
using software.elendil.IPX800.IO;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v2.Http
{
    public class SetOutputHttpCommandBuilderTest
    {   
        [Fact]
        public void BuildCommandString_ForActiveOutput_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new IPX800v2SetOutputHttpCommandBuilder();
            var output = new IPX800Output {Type = OutputType.Output, Number = 2, State = OutputState.Active, IsDelayed = false, IsVirtual = false};
            
            //Act
            string command = commandBuilder.BuildCommandString(output);
            
            //Assert
            Assert.Equal("preset.htm?led2=1", command);       
        }

        [Fact]
        public void BuildCommandString_ForActiveDelayedOutput_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new IPX800v2SetOutputHttpCommandBuilder();
            var output = new IPX800Output {Type = OutputType.Output, Number = 2, State = OutputState.Active, IsDelayed = true, IsVirtual = false};
            
            //Act
            string command = commandBuilder.BuildCommandString(output);
            
            //Assert
            Assert.Equal("preset.htm?RLY2=1", command);       
        }

        [Fact]
        public void BuildCommandString_ForInactiveOutput_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new IPX800v2SetOutputHttpCommandBuilder();
            var output = new IPX800Output {Type = OutputType.Output, Number = 2, State = OutputState.Inactive, IsDelayed = false, IsVirtual = false};
            
            //Act
            string command = commandBuilder.BuildCommandString(output);
            
            //Assert
            Assert.Equal("preset.htm?led2=0", command);       
        }

        [Fact]
        public void BuildCommandString_ForInactiveDelayedOutput_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new IPX800v2SetOutputHttpCommandBuilder();
            var output = new IPX800Output {Type = OutputType.Output, Number = 2, State = OutputState.Inactive, IsDelayed = true, IsVirtual = false};
            
            //Act
            string command = commandBuilder.BuildCommandString(output);
            
            //Assert
            Assert.Equal("preset.htm?led2=0", command);
        }
    }
}