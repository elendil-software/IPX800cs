using System;
using System.Collections.Generic;
using IPX800cs.IO;
using IPX800cs.Parsers.v3;
using IPX800cs.Parsers.v3.Http;
using IPX800cs.Parsers.v3.M2M;
using IPX800cs.Version;
using Xunit;

namespace IPX800cs.Test.Parsers.v3
{
    public class IPX800v3ResponseParserFactoryTest
    {
        public static IEnumerable<object[]> GetAnalogInputParserTestCases => new[]
        {
            new object[] { new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3), new Input { Type = InputType.AnalogInput }, typeof(IPX800v3GetAnalogInputHttpResponseParser) },
            new object[] { new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V3), new Input { Type = InputType.AnalogInput }, typeof(IPX800v3GetAnalogInputM2MResponseParser) }
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
        
        public static IEnumerable<object[]> GetInputsParserTestCases => new[]
        {
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3), new Input { Type = InputType.DigitalInput }, typeof(IPX800v3GetInputsHttpResponseParser) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V3), new Input { Type = InputType.DigitalInput }, typeof(IPX800v3GetInputsM2MResponseParser) }
        };

        [Theory]
        [MemberData(nameof(GetInputsParserTestCases))]
        public void GetInputsParser_ReturnsParserCorrespondingToContext(Context context, Input input, Type expectedType)
        {
            //Arrange
            var responseParserFactory = new IPX800v3ResponseParserFactory();

            //Act
            var parser = responseParserFactory.GetInputsParser(context, input);

            //Assert
            Assert.Equal(expectedType, parser.GetType());
        }

        public static IEnumerable<object[]> GetOutputParserTestCases => new[]
        {
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3), new Output { Type = OutputType.Output }, typeof(IPX800v3GetOutputHttpResponseParser) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V3), new Output { Type = OutputType.Output }, typeof(IPX800v3GetOutputM2MResponseParser) }
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

        public static IEnumerable<object[]> GetOutputsParserTestCases => new[]
        {
            new object[] { new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3), new Output { Type = OutputType.Output }, typeof(IPX800v3GetOutputsHttpResponseParser) },
            new object[] { new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V3), new Output { Type = OutputType.Output }, typeof(IPX800v3GetOutputsM2MResponseParser) }
        };

        [Theory]
        [MemberData(nameof(GetOutputsParserTestCases))]
        public void GetOutputsParser_ReturnsParserCorrespondingToContext(Context context, Output output, Type expectedType)
        {
            //Arrange
            var responseParserFactory = new IPX800v3ResponseParserFactory();

            //Act
            var parser = responseParserFactory.GetOutputsParser(context, output);

            //Assert
            Assert.Equal(expectedType, parser.GetType());
        }

        
        public static IEnumerable<object[]> SetOutputParserTestCases => new[]
        {
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3), new Output { Type = OutputType.Output }, typeof(IPX800v3SetOutputHttpResponseParser) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V3), new Output { Type = OutputType.Output }, typeof(IPX800v3SetOutputM2MResponseParser) }
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