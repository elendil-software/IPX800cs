using System;
using System.Collections.Generic;
using IPX800cs.Commands.Senders;
using IPX800cs.Version;
using Xunit;

namespace IPX800cs.Test.Commands.Senders;

public class CommandSenderFactoryTest
{
    public static IEnumerable<object[]> TestCases => new[]
    {
        new object[] {new Context("http://192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V2), typeof(CommandSenderHttp) },
        new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V2), typeof(CommandSenderM2M) },
        new object[] {new Context("http://192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3), typeof(CommandSenderHttp) },
        new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V3), typeof(CommandSenderM2M) },
        new object[] {new Context("http://192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4), typeof(CommandSenderHttp) },
        new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4), typeof(CommandSenderM2M) },
        new object[] {new Context("http://192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V5), typeof(CommandSenderIPX800V5) },
    };

    [Theory]
    [MemberData(nameof(TestCases))]
    public void GetCommandBuilderFactory_ReturnsCommandBuilderFactory_CorrespondingToContext(Context context, Type type)
    {
        //Act
        ICommandSender commandSender = CommandSenderFactory.GetCommandSender(context);

        //Assert
        Assert.Equal(type, commandSender.GetType());
    }
}