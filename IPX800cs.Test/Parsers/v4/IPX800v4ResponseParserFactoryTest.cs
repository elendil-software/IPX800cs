using System;
using System.Collections.Generic;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v4;
using IPX800cs.Parsers.v4.Http;
using IPX800cs.Parsers.v4.M2M;
using IPX800cs.Version;
using Xunit;

namespace IPX800cs.Test.Parsers.v4
{
    public class IPX800v4ResponseParserFactoryTest
    {
        public static IEnumerable<object[]> GetAnalogInputParserTestCases => new[]
        {
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4), new Input { Type = InputType.AnalogInput }, typeof(IPX800v4GetAnalogInputHttpResponseParser) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4), new Input { Type = InputType.AnalogInput }, typeof(IPX800v4GetAnalogInputM2MResponseParser) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4), new Input { Type = InputType.VirtualAnalogInput }, typeof(IPX800v4GetVirtualAnalogInputHttpResponseParser) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4), new Input { Type = InputType.VirtualAnalogInput }, typeof(IPX800v4GetVirtualAnalogInputM2MResponseParser) }
        };

        [Theory]
        [MemberData(nameof(GetAnalogInputParserTestCases))]
        public void GetAnalogInputParser_ReturnsParserCorrespondingToContext(Context context, Input input, Type expectedType)
        {
            //Arrange
            var responseParserFactory = new IPX800v4ResponseParserFactory();

            //Act
            var parser = responseParserFactory.GetAnalogInputParser(context, input);

            //Assert
            Assert.Equal(expectedType, parser.GetType());
        }

        public static IEnumerable<object[]> GetInputParserTestCases => new[]
        {
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4), new Input { Type = InputType.DigitalInput }, typeof(IPX800v4GetInputHttpResponseParser) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4), new Input { Type = InputType.DigitalInput }, typeof(IPX800v4GetInputM2MResponseParser) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4), new Input { Type = InputType.VirtualDigitalInput }, typeof(IPX800v4GetVirtualInputHttpResponseParser) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4), new Input { Type = InputType.VirtualDigitalInput }, typeof(IPX800v4GetVirtualInputM2MResponseParser) }
        };

        [Theory]
        [MemberData(nameof(GetInputParserTestCases))]
        public void GetInputParser_ReturnsParserCorrespondingToContext(Context context, Input input, Type expectedType)
        {
            //Arrange
            var responseParserFactory = new IPX800v4ResponseParserFactory();

            //Act
            var parser = responseParserFactory.GetInputParser(context, input);

            //Assert
            Assert.Equal(expectedType, parser.GetType());
        }
        
        public static IEnumerable<object[]> GetInputsParserTestCases => new[]
        {
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4), new Input { Type = InputType.DigitalInput }, typeof(IPX800v4GetInputsHttpResponseParser) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4), new Input { Type = InputType.DigitalInput }, typeof(IPX800v4GetInputsM2MResponseParser) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4), new Input { Type = InputType.VirtualDigitalInput }, typeof(IPX800v4GetVirtualInputsHttpResponseParser) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4), new Input { Type = InputType.VirtualDigitalInput }, typeof(IPX800v4GetVirtualInputsM2MResponseParser) }
        };

        [Theory]
        [MemberData(nameof(GetInputsParserTestCases))]
        public void GetInputsParser_ReturnsParserCorrespondingToContext(Context context, Input input, Type expectedType)
        {
            //Arrange
            var responseParserFactory = new IPX800v4ResponseParserFactory();

            //Act
            var parser = responseParserFactory.GetInputsParser(context, input);

            //Assert
            Assert.Equal(expectedType, parser.GetType());
        }
        
        public static IEnumerable<object[]> GetAnalogInputsParserTestCases => new[]
        {
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4), new Input { Type = InputType.AnalogInput }, typeof(IPX800v4GetAnalogInputsHttpResponseParser) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4), new Input { Type = InputType.AnalogInput }, typeof(IPX800v4GetAnalogInputsM2MResponseParser) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4), new Input { Type = InputType.VirtualAnalogInput }, typeof(IPX800v4GetVirtualAnalogInputsHttpResponseParser) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4), new Input { Type = InputType.VirtualAnalogInput }, typeof(IPX800v4GetVirtualAnalogInputsM2MResponseParser) }
        };

        [Theory]
        [MemberData(nameof(GetAnalogInputsParserTestCases))]
        public void GetAnalogInputsParser_ReturnsParserCorrespondingToContext(Context context, Input input, Type expectedType)
        {
            //Arrange
            var responseParserFactory = new IPX800v4ResponseParserFactory();

            //Act
            var parser = responseParserFactory.GetAnalogInputsParser(context, input);

            //Assert
            Assert.Equal(expectedType, parser.GetType());
        }

        public static IEnumerable<object[]> GetOutputParserTestCases => new[]
        {
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4), new Output { Type = OutputType.Output }, typeof(IPX800v4GetOutputHttpResponseParser) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4), new Output { Type = OutputType.Output }, typeof(IPX800v4GetOutputM2MResponseParser) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4), new Output { Type = OutputType.VirtualOutput }, typeof(IPX800v4GetVirtualOutputHttpResponseParser) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4), new Output { Type = OutputType.VirtualOutput }, typeof(IPX800v4GetVirtualOutputM2MResponseParser) }
        };

        [Theory]
        [MemberData(nameof(GetOutputParserTestCases))]
        public void GetOutputParser_ReturnsParserCorrespondingToContext(Context context, Output output, Type expectedType)
        {
            //Arrange
            var responseParserFactory = new IPX800v4ResponseParserFactory();

            //Act
            var parser = responseParserFactory.GetOutputParser(context, output);

            //Assert
            Assert.Equal(expectedType, parser.GetType());
        }
        
        public static IEnumerable<object[]> GetOutputsParserTestCases => new[]
        {
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4), new Output { Type = OutputType.Output }, typeof(IPX800v4GetOutputsHttpResponseParser) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4), new Output { Type = OutputType.Output }, typeof(IPX800v4GetOutputsM2MResponseParser) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4), new Output { Type = OutputType.VirtualOutput }, typeof(IPX800v4GetVirtualOutputsHttpResponseParser) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4), new Output { Type = OutputType.VirtualOutput }, typeof(IPX800v4GetVirtualOutputsM2MResponseParser) }
        };

        [Theory]
        [MemberData(nameof(GetOutputsParserTestCases))]
        public void GetOutputsParser_ReturnsParserCorrespondingToContext(Context context, Output output, Type expectedType)
        {
            //Arrange
            var responseParserFactory = new IPX800v4ResponseParserFactory();

            //Act
            var parser = responseParserFactory.GetOutputsParser(context, output);

            //Assert
            Assert.Equal(expectedType, parser.GetType());
        }

        public static IEnumerable<object[]> SetOutputParserTestCases => new[]
        {
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4), new Output { Type = OutputType.Output }, typeof(IPX800v4SetOutputHttpResponseParser) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4), new Output { Type = OutputType.Output }, typeof(IPX800v4SetOutputM2MResponseParser) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4), new Output { Type = OutputType.VirtualOutput }, typeof(IPX800v4SetOutputHttpResponseParser) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4), new Output { Type = OutputType.VirtualOutput }, typeof(IPX800v4SetOutputM2MResponseParser) }
        };

        [Theory]
        [MemberData(nameof(SetOutputParserTestCases))]
        public void SetOutputParser_ReturnsParserCorrespondingToContext(Context context, Output output, Type expectedType)
        {
            //Arrange
            var responseParserFactory = new IPX800v4ResponseParserFactory();

            //Act
            var parser = responseParserFactory.GetSetOutputParser(context, output);

            //Assert
            Assert.Equal(expectedType, parser.GetType());
        }
    }
}