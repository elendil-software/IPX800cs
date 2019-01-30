using System.Linq;
using software.elendil.IPX800;
using software.elendil.IPX800.Commands.Senders.HttpWebRequestBuilder;
using software.elendil.IPX800.Version;
using Xunit;

namespace IPX800cs.Test.Commands.Senders.HttpWebRequestBuilder
{
    public class DefaultHttpWebRequestBuilderTest
    {
        [Fact]
        public void WhenUserAndPasswordAreSet_GeneratedUri_ContainsAuthorizationHeader()
        {
            //Arrange
            var context = new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3, "USER", "PASS");
            var defaultHttpWebRequestBuilder = new DefaultHttpWebRequestBuilder(context);

            //Act
            var request = defaultHttpWebRequestBuilder.Build("Get=R");

            //Assert
            Assert.Equal(1, request.Headers.AllKeys.Count(k => k == "Authorization"));
        }

        [Fact]
        public void WhenApiKeyIsNotSet_GeneratedUri_NotContainsKeyParameter()
        {
            //Arrange
            var context = new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3);
            var defaultHttpWebRequestBuilder = new DefaultHttpWebRequestBuilder(context);

            //Act
            var request = defaultHttpWebRequestBuilder.Build("Get=R");

            //Assert
            Assert.Equal(0, request.Headers.AllKeys.Count(k => k == "Authorization"));
        }
    }
}