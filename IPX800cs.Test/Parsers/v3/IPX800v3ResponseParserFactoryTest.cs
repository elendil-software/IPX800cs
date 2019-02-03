using System;
using System.Collections.Generic;
using software.elendil.IPX800;
using software.elendil.IPX800.IO;
using software.elendil.IPX800.Parsers.v3;
using software.elendil.IPX800.Parsers.v3.Http;
using software.elendil.IPX800.Parsers.v3.Legacy.M2M;
using software.elendil.IPX800.Parsers.v3.M2M;
using software.elendil.IPX800.Version;
using Xunit;

namespace IPX800cs.Test.Parsers.v3
{
    public class IPX800v3ResponseParserFactoryTest
    {
        public static IEnumerable<object[]> GetVersionResponseParserTestCases => new[]
        {
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3), typeof(IPX800v3GetVersionHttpResponseParser) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V3), typeof(IPX800v3GetVersionM2MResponseParser) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V3, new System.Version(3,5,38)), typeof(IPX800v3LegacyGetVersionM2MResponseParser) }
        };

        [Theory]
        [MemberData(nameof(GetVersionResponseParserTestCases))]
        public void GetVersionResponseParser_ReturnsParserCorrespondingToContext(Context context, Type expectedType)
        {
            //Arrange
            var responseParserFactory = new IPX800v3ResponseParserFactory();

            //Act
            var parser = responseParserFactory.GetVersionResponseParser(context);

            //Assert
            Assert.Equal(expectedType, parser.GetType());
        }

        public static IEnumerable<object[]> GetAnalogInputParserTestCases => new[]
        {
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3), new Input { Type = InputType.AnalogInput }, typeof(IPX800v3AnalogInputHttpResponseParser) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V3), new Input { Type = InputType.AnalogInput }, typeof(IPX800v3GetAnalogInputM2MResponseParser) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V3, new System.Version(3,5,38)), new Input { Type = InputType.AnalogInput }, typeof(IPX800v3LegacyGetAnalogInputM2MResponseParser) },
        };

        [Theory]
        [MemberData(nameof(GetAnalogInputParserTestCases))]
        public void GetAnalogInputParser_ReturnsParserCorrespondingToContext(Context context, Input input, Type expectedType)
        {
            //Arrange
            var responseParserFactory = new IPX800v3ResponseParserFactory();

            //Act
            var parser = responseParserFactory.GetAnalogInputParser(context, input);

            //Assert
            Assert.Equal(expectedType, parser.GetType());
        }

        public static IEnumerable<object[]> GetInputParserTestCases => new[]
        {
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3), new Input { Type = InputType.DigitalInput }, typeof(IPX800v3GetInputHttpResponseParser) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V3), new Input { Type = InputType.DigitalInput }, typeof(IPX800v3GetInputM2MResponseParser) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V3, new System.Version(3,5,38)), new Input { Type = InputType.DigitalInput }, typeof(IPX800v3LegacyGetInputM2MResponseParser) }
        };

        [Theory]
        [MemberData(nameof(GetInputParserTestCases))]
        public void GetInputParser_ReturnsParserCorrespondingToContext(Context context, Input input, Type expectedType)
        {
            //Arrange
            var responseParserFactory = new IPX800v3ResponseParserFactory();

            //Act
            var parser = responseParserFactory.GetInputParser(context, input);

            //Assert
            Assert.Equal(expectedType, parser.GetType());
        }

        public static IEnumerable<object[]> GetOutputParserTestCases => new[]
        {
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3), new Output { Type = OutputType.Output }, typeof(IPX800v3GetOutputHttpResponseParser) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V3), new Output { Type = OutputType.Output }, typeof(IPX800v3GetOutputM2MResponseParser) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V3, new System.Version(3,5,38)), new Output { Type = OutputType.Output }, typeof(IPX800v3LegacyGetOutputM2MResponseParser) }
        };

        [Theory]
        [MemberData(nameof(GetOutputParserTestCases))]
        public void GetOutputParser_ReturnsParserCorrespondingToContext(Context context, Output output, Type expectedType)
        {
            //Arrange
            var responseParserFactory = new IPX800v3ResponseParserFactory();

            //Act
            var parser = responseParserFactory.GetOutputParser(context, output);

            //Assert
            Assert.Equal(expectedType, parser.GetType());
        }

        public static IEnumerable<object[]> SetOutputParserTestCases => new[]
        {
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3), new Output { Type = OutputType.Output }, typeof(IPX800v3SetOutputHttpResponseParser) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V3), new Output { Type = OutputType.Output }, typeof(IPX800v3SetOutputM2MResponseParser) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V3, new System.Version(3,5,38)), new Output { Type = OutputType.Output }, typeof(IPX800v3LegacySetOutputM2MResponseParser) },
        };

        [Theory]
        [MemberData(nameof(SetOutputParserTestCases))]
        public void SetOutputParser_ReturnsParserCorrespondingToContext(Context context, Output output, Type expectedType)
        {
            //Arrange
            var responseParserFactory = new IPX800v3ResponseParserFactory();

            //Act
            var parser = responseParserFactory.GetSetOutputParser(context, output);

            //Assert
            Assert.Equal(expectedType, parser.GetType());
        }
    }
}