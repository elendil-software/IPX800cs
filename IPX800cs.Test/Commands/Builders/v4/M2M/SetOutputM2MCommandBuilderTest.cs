using software.elendil.IPX800.Commands.Builders.v4.M2M;
using software.elendil.IPX800.IO;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v4.M2M
{
    public class SetOutputM2MCommandBuilderTest
    {   
        [Fact]
        public void BuildCommandString_ForActiveOutput_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new SetOutCommandBuilder();
            var output = new IPX800Output {Type = OutputType.Output, Number = 2, State = OutputState.Active, IsDelayed = false, IsVirtual = false};
            
            //Act
            string command = commandBuilder.BuildCommandString(output);
            
            //Assert
            Assert.Equal("SetR=02", command);       
        }

        [Fact]
        public void BuildCommandString_ForActiveDelayedOutput_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new SetOutCommandBuilder();
            var output = new IPX800Output {Type = OutputType.Output, Number = 2, State = OutputState.Active, IsDelayed = true, IsVirtual = false};
            
            //Act
            string command = commandBuilder.BuildCommandString(output);
            
            //Assert
            Assert.Equal("SetR=02", command);       
        }

        [Fact]
        public void BuildCommandString_ForInactiveOutput_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new SetOutCommandBuilder();
            var output = new IPX800Output {Type = OutputType.Output, Number = 2, State = OutputState.Inactive, IsDelayed = false, IsVirtual = false};
            
            //Act
            string command = commandBuilder.BuildCommandString(output);
            
            //Assert
            Assert.Equal("ClearR=02", command);       
        }

        [Fact]
        public void BuildCommandString_ForInactiveDelayedOutput_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new SetOutCommandBuilder();
            var output = new IPX800Output {Type = OutputType.Output, Number = 2, State = OutputState.Inactive, IsDelayed = true, IsVirtual = false};
            
            //Act
            string command = commandBuilder.BuildCommandString(output);
            
            //Assert
            Assert.Equal("ClearR=02", command);
        }
    }
}