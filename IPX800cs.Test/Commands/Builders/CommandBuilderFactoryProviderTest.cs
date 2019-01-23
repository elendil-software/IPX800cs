using System;
using System.Collections.Generic;
using software.elendil.IPX800;
using software.elendil.IPX800.Commands.Builders;
using software.elendil.IPX800.Commands.Builders.v2;
using software.elendil.IPX800.Commands.Builders.v3;
using software.elendil.IPX800.Commands.Builders.v4;
using software.elendil.IPX800.Exceptions;
using software.elendil.IPX800.Version;
using Xunit;

namespace IPX800cs.Test.Commands.Builders
{
    public class CommandBuilderFactoryProviderTest
    {
        public static IEnumerable<object[]> TestCases => new[]
        {
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V2), typeof(IPX800v2HttpCommandBuilderFactory) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V2), typeof(IPX800v2M2MCommandBuilderFactory) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3), typeof(IPX800v3HttpCommandBuilderFactory) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V3), typeof(IPX800v3M2MCommandBuilderFactory) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4), typeof(IPX800v4HttpCommandBuilderFactory) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4), typeof(IPX800v4M2MCommandBuilderFactory) },
        };

        [Theory]
        [MemberData(nameof(TestCases))]
        public void GetCommandBuilderFactory_ReturnsCommandBuilderFactory_CorrespondingToContext(Context context, Type type)
        {
            //Arrange
            var commandBuilderFactoryProvider = new CommandBuilderFactoryProvider();

            //Act
            ICommandBuilderFactory commandBuilderFactory = commandBuilderFactoryProvider.GetCommandBuilderFactory(context);

            //Assert
            Assert.Equal(type, commandBuilderFactory.GetType());
        }

        [Fact]
        public void GivenInvalidIPX800Version_GetCommandBuilderFactory_ThrowsIPX800UnknownVersionException()
        {
            //Arrange
            var commandBuilderFactoryProvider = new CommandBuilderFactoryProvider();
            var context = new Context("192.168.1.2", 80, IPX800Protocol.Http, (IPX800Version)100);

            //Act/Assert
            Assert.Throws<IPX800UnknownVersionException>(() => commandBuilderFactoryProvider.GetCommandBuilderFactory(context));
        }
    }
}