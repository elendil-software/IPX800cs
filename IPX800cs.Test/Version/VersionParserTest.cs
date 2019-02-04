using software.elendil.IPX800.Version;
using Xunit;

namespace IPX800cs.Test.Version
{
    public class VersionParserTest
    {       
        [Theory]
        [InlineData("GetVersion=3.05.42", "3.5.42")]
        [InlineData("GetVersion = 3.05.42", "3.5.42")]
        [InlineData("3.05.42", "3.5.42")]
        [InlineData("3.00.29", "3.0.29")]
        public void GivenValidVersionString_Parse_ReturnsVersion(string versionString, string expectedParsedVersion)
        {
            System.Version version = VersionParser.Parse(versionString);
            Assert.Equal(expectedParsedVersion, version.ToString());
        }
    }
}