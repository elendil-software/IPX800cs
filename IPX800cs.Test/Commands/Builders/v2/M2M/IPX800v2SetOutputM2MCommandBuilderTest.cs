using software.elendil.IPX800.Commands.Builders.v2.M2M;
using software.elendil.IPX800.IO;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v2.M2M
{
    public class IPX800v2SetOutputM2MCommandBuilderTest
    {   
        [Fact]
        public void BuildCommandString_ForActiveOutput_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new IPX800v2SetOutputM2MCommandBuilder();
            var output = new Output {Type = OutputType.Output, Number = 2, State = OutputState.Active, IsDelayed = false, };
            
            //Act
            string command = commandBuilder.BuildCommandString(output);
            
            //Assert
            Assert.Equal("Set21", command);       
        }

        [Fact]
        public void BuildCommandString_ForActiveDelayedOutput_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new IPX800v2SetOutputM2MCommandBuilder();
            var output = new Output {Type = OutputType.Output, Number = 2, State = OutputState.Active, IsDelayed = true, };
            
            //Act
            string command = commandBuilder.BuildCommandString(output);
            
            //Assert
            Assert.Equal("Set2F", command);       
        }

        [Fact]
        public void BuildCommandString_ForInactiveOutput_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new IPX800v2SetOutputM2MCommandBuilder();
            var output = new Output {Type = OutputType.Output, Number = 2, State = OutputState.Inactive, IsDelayed = false, };
            
            //Act
            string command = commandBuilder.BuildCommandString(output);
            
            //Assert
            Assert.Equal("Set20", command);       
        }

        [Fact]
        public void BuildCommandString_ForInactiveDelayedOutput_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new IPX800v2SetOutputM2MCommandBuilder();
            var output = new Output {Type = OutputType.Output, Number = 2, State = OutputState.Inactive, IsDelayed = true, };
            
            //Act
            string command = commandBuilder.BuildCommandString(output);
            
            //Assert
            Assert.Equal("Set20", command);
        }
    }
}