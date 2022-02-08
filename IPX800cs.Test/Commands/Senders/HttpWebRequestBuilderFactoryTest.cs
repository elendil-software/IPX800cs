using System;
using System.Collections.Generic;
using IPX800cs.Commands.Senders;
using IPX800cs.Commands.Senders.HttpWebRequestBuilder;
using IPX800cs.Version;
using Xunit;

namespace IPX800cs.Test.Commands.Senders;

public class HttpWebRequestBuilderFactoryTest
{
    public static IEnumerable<object[]> TestCases => new[]
    {
        new object[] { new Context("192.168.1.2", 8080, IPX800Protocol.Http, IPX800Version.V2), typeof(HttpRequestMessageBuilderBase) },
        new object[] { new Context("192.168.1.2", 8080, IPX800Protocol.Http, IPX800Version.V2, "USER", "PASS"), typeof(AuthorizedHttpRequestMessageBuilder) },
        new object[] { new Context("192.168.1.2", 8080, IPX800Protocol.Http, IPX800Version.V3), typeof(HttpRequestMessageBuilderBase) },
        new object[] { new Context("192.168.1.2", 8080, IPX800Protocol.Http, IPX800Version.V3, "USER", "PASS"), typeof(AuthorizedHttpRequestMessageBuilder) },
        new object[] { new Context("192.168.1.2", 8080, IPX800Protocol.Http, IPX800Version.V4), typeof(HttpRequestMessageBuilderBase) },
        new object[] { new Context("192.168.1.2", 8080, IPX800Protocol.Http, IPX800Version.V4, "", "APIKEY"), typeof(ApiKeyHttpRequestMessageBuilder) },
        new object[] { new Context("192.168.1.2", 8080, IPX800Protocol.Http, IPX800Version.V5, "", "APIKEY"), typeof(ApiKeyHttpWebRequestBuilder) }
    };

    [Theory]
    [MemberData(nameof(TestCases))]
    public void Create_Returns_ExpectedBuilder(Context context, Type type)
    {
        //Act
        IHttpRequestMessageBuilder httpRequestMessageBuilder = HttpWebRequestBuilderFactory.Create(context);

        //Assert
        Assert.Equal(type, httpRequestMessageBuilder.GetType());
    }
}