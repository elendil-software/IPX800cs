using System;
using System.Collections.Generic;
using software.elendil.IPX800;
using software.elendil.IPX800.Commands.Builders;
using software.elendil.IPX800.Commands.Builders.v2;
using software.elendil.IPX800.Commands.Builders.v3;
using software.elendil.IPX800.Commands.Builders.v4;
using software.elendil.IPX800.Exceptions;
using software.elendil.IPX800.Parsers;
using software.elendil.IPX800.Parsers.v2;
using software.elendil.IPX800.Parsers.v3;
using software.elendil.IPX800.Parsers.v4;
using software.elendil.IPX800.Version;
using Xunit;

namespace IPX800cs.Test.Parsers
{
    public class ResponseParserFactoryProviderTest
    {
        public static IEnumerable<object[]> TestCases => new[]
        {
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V2), typeof(IPX800v2ResponseParserFactory) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V2), typeof(IPX800v2ResponseParserFactory) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3), typeof(IPX800v3ResponseParserFactory) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V3), typeof(IPX800v3ResponseParserFactory) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4), typeof(IPX800v4ResponseParserFactory) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4), typeof(IPX800v4ResponseParserFactory) },
        };

        [Theory]
        [MemberData(nameof(TestCases))]
        public void GetResponseParserFactory_ReturnsResponseParserFactory_CorrespondingToContext(Context context, Type type)
        {
            //Arrange
            var ResponseParserFactoryProvider = new ResponseParserFactoryProvider();

            //Act
            IResponseParserFactory ResponseParserFactory = ResponseParserFactoryProvider.GetResponseParserFactory(context);

            //Assert
            Assert.Equal(type, ResponseParserFactory.GetType());
        }

        [Fact]
        public void GivenInvalidIPX800Version_GetResponseParserFactory_ThrowsIPX800UnknownVersionException()
        {
            //Arrange
            var ResponseParserFactoryProvider = new ResponseParserFactoryProvider();
            var context = new Context("192.168.1.2", 80, IPX800Protocol.Http, (IPX800Version)100);

            //Act/Assert
            Assert.Throws<IPX800UnknownVersionException>(() => ResponseParserFactoryProvider.GetResponseParserFactory(context));
        }
    }
}