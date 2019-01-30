﻿using System;
using System.Collections.Generic;
using software.elendil.IPX800;
using software.elendil.IPX800.Exceptions;
using software.elendil.IPX800.IO;
using software.elendil.IPX800.Parsers.v4;
using software.elendil.IPX800.Parsers.v4.Http;
using software.elendil.IPX800.Parsers.v4.M2M;
using software.elendil.IPX800.Version;
using Xunit;

namespace IPX800cs.Test.Parsers.v4
{
    public class IPX800v4ResponseParserFactoryTest
    {
        [Fact]
        public void GetVersionResponseParser_ReturnsParserCorrespondingToContext()
        {
            //Arrange
            Context context = new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4);
            var responseParserFactory = new IPX800v4ResponseParserFactory();

            //Act/Assert
            Assert.Throws<IPX800NotSupportedCommandException>(() => responseParserFactory.GetVersionResponseParser(context));
        }

        public static IEnumerable<object[]> GetAnalogInputParserTestCases => new[]
        {
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4), new Input { Type = InputType.AnalogInput }, typeof(IPX800v4GetAnalogInputHttpResponseParser) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4), new Input { Type = InputType.AnalogInput }, typeof(IPX800v4GetAnalogInputM2MResponseParser) }
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
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4), new Input { Type = InputType.DigitalInput }, typeof(IPX800v4GetInputM2MResponseParser) }
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

        public static IEnumerable<object[]> GetOutputParserTestCases => new[]
        {
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4), new Output { Type = OutputType.Output }, typeof(IPX800v4GetOutputHttpResponseParser) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4), new Output { Type = OutputType.Output }, typeof(IPX800v4GetOutputM2MResponseParser) }
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

        public static IEnumerable<object[]> SetOutputParserTestCases => new[]
        {
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4), new Output { Type = OutputType.Output }, typeof(IPX800v4SetOutputHttpResponseParser) },
            new object[] {new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4), new Output { Type = OutputType.Output }, typeof(IPX800v4SetOutputM2MResponseParser) }
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