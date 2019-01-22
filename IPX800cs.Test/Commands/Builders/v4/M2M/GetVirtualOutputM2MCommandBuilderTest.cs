using software.elendil.IPX800.Commands.Builders.v4.M2M;
using software.elendil.IPX800.IO;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v4.M2M
{
    public class GetVirtualOutputM2MCommandBuilderTest
    {   
        [Fact]
        public void BuildCommandString_Returns_CorrectCommandString()
        {
            //Arrange
            var commandBuilder = new GetVirtualOutCommandBuilder();
            var output = new IPX800Output {Type = OutputType.Output, Number = 2, IsDelayed = false, IsVirtual = false};
            
            //Act
            string command = commandBuilder.BuildCommandString(output);
            
            //Assert
            Assert.Equal("Get=VO", command);       
        }
    }
}