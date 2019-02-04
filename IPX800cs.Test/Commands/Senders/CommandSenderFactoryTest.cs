using System;
using System.Collections.Generic;
using software.elendil.IPX800;
using software.elendil.IPX800.Commands.Senders;
using software.elendil.IPX800.Version;
using Xunit;

namespace IPX800cs.Test.Commands.Senders
{
    public class CommandSenderFactoryTest
    {
        public static IEnumerable<object[]> TestCases => new[]
        {
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V2), typeof(CommandSenderHttp) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V2), typeof(CommandSenderM2M) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3), typeof(CommandSenderHttp) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V3), typeof(CommandSenderM2M) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4), typeof(CommandSenderHttp) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4), typeof(CommandSenderM2M) },
        };

        [Theory]
        [MemberData(nameof(TestCases))]
        public void GetCommandBuilderFactory_ReturnsCommandBuilderFactory_CorrespondingToContext(Context context, Type type)
        {
            //Arrange
            var commandSenderFactory = new CommandSenderFactory();

            //Act
            ICommandSender commandSender = commandSenderFactory.GetCommandSender(context);

            //Assert
            Assert.Equal(type, commandSender.GetType());
        }
    }
}