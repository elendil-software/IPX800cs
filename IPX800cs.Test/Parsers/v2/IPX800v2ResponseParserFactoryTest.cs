using System;
using System.Collections.Generic;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v2;
using IPX800cs.Parsers.v2.Http;
using IPX800cs.Parsers.v2.M2M;
using IPX800cs.Version;
using Xunit;

namespace IPX800cs.Test.Parsers.v2
{
    public class IPX800v2ResponseParserFactoryTest
    {
        public static IEnumerable<object[]> GetAnalogInputParserTestCases => new[]
        {
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V2), new Input { Type = InputType.AnalogInput }, typeof(IPX800v2GetAnalogInputHttpResponseParser) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V2), new Input { Type = InputType.AnalogInput }, typeof(IPX800v2GetAnalogInputM2MResponseParser) }
        };

        [Theory]
        [MemberData(nameof(GetAnalogInputParserTestCases))]
        public void GetAnalogInputParser_ReturnsParserCorrespondingToContext(Context context, Input input, Type expectedType)
        {
            //Arrange
            var responseParserFactory = new IPX800v2ResponseParserFactory();

            //Act
            var parser = responseParserFactory.GetAnalogInputParser(context, input);

            //Assert
            Assert.Equal(expectedType, parser.GetType());
        }

        public static IEnumerable<object[]> GetInputParserTestCases => new[]
        {
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V2), new Input { Type = InputType.DigitalInput }, typeof(IPX800v2GetInputHttpResponseParser) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V2), new Input { Type = InputType.DigitalInput }, typeof(IPX800v2GetInputM2MResponseParser) }
        };

        [Theory]
        [MemberData(nameof(GetInputParserTestCases))]
        public void GetInputParser_ReturnsParserCorrespondingToContext(Context context, Input input, Type expectedType)
        {
            //Arrange
            var responseParserFactory = new IPX800v2ResponseParserFactory();

            //Act
            var parser = responseParserFactory.GetInputParser(context, input);

            //Assert
            Assert.Equal(expectedType, parser.GetType());
        }

        public static IEnumerable<object[]> GetOutputParserTestCases => new[]
        {
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V2), new Output { Type = OutputType.Output }, typeof(IPX800v2GetOutputHttpResponseParser) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V2), new Output { Type = OutputType.Output }, typeof(IPX800v2GetOutputM2MResponseParser) }
        };

        [Theory]
        [MemberData(nameof(GetOutputParserTestCases))]
        public void GetOutputParser_ReturnsParserCorrespondingToContext(Context context, Output output, Type expectedType)
        {
            //Arrange
            var responseParserFactory = new IPX800v2ResponseParserFactory();

            //Act
            var parser = responseParserFactory.GetOutputParser(context, output);

            //Assert
            Assert.Equal(expectedType, parser.GetType());
        }

        public static IEnumerable<object[]> SetOutputParserTestCases => new[]
        {
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V2), new Output { Type = OutputType.Output }, typeof(IPX800v2SetOutputHttpResponseParser) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V2), new Output { Type = OutputType.Output }, typeof(IPX800v2SetOutputM2MResponseParser) }
        };

        [Theory]
        [MemberData(nameof(SetOutputParserTestCases))]
        public void SetOutputParser_ReturnsParserCorrespondingToContext(Context context, Output output, Type expectedType)
        {
            //Arrange
            var responseParserFactory = new IPX800v2ResponseParserFactory();

            //Act
            var parser = responseParserFactory.GetSetOutputParser(context, output);

            //Assert
            Assert.Equal(expectedType, parser.GetType());
        }
    }
}