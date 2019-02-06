using System;
using System.Collections.Generic;
using IPX800cs.Commands.Builders;
using IPX800cs.Commands.Builders.v4;
using IPX800cs.Commands.Builders.v4.Http;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Version;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v4
{
    public class IPX800v4HttpCommandBuilderFactoryTest
    {
        public static IEnumerable<object[]> InputTestCases => new[]
        {
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4),
                new Input { Number = 2, Type = InputType.AnalogInput},
                typeof(IPX800v4GetAnalogInputHttpCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4),
                new Input { Number = 2, Type = InputType.DigitalInput},
                typeof(IPX800v4GetInputHttpCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4),
                new Input { Number = 2, Type = InputType.VirtualAnalogInput},
                typeof(IPX800v4GetVirtualAnalogInputHttpCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4),
                new Input { Number = 2, Type = InputType.VirtualDigitalInput},
                typeof(IPX800v4GetVirtualInputHttpCommandBuilder)
            }
        };

        [Theory]
        [MemberData(nameof(InputTestCases))]
        public void GetGetInputCommandBuilder_ReturnsCommandBuilder_CorrespondingToContextAndInput(Context context, Input input, Type type)
        {
            //Arrange
            var v4HttpCommandBuilderFactory = new IPX800v4HttpCommandBuilderFactory();

            //Act
            IGetInputCommandBuilder commandBuilderFactory = v4HttpCommandBuilderFactory.GetGetInputCommandBuilder(context, input);

            //Assert
            Assert.Equal(type, commandBuilderFactory.GetType());
        }

        public static IEnumerable<object[]> GetOutputTestCases => new[]
        {
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4),
                new Output { Number = 2, Type = OutputType.Output},
                typeof(IPX800v4GetOutputHttpCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4),
                new Output { Number = 2, Type = OutputType.VirtualOutput},
                typeof(IPX800v4GetVirtualOutputHttpCommandBuilder)
            }
        };

        [Theory]
        [MemberData(nameof(GetOutputTestCases))]
        public void GetGetOutputCommandBuilder_ReturnsCommandBuilder_CorrespondingToContextAndInput(Context context, Output output, Type type)
        {
            //Arrange
            var v4HttpCommandBuilderFactory = new IPX800v4HttpCommandBuilderFactory();

            //Act
            IGetOutputCommandBuilder commandBuilderFactory = v4HttpCommandBuilderFactory.GetGetOutputCommandBuilder(context, output);

            //Assert
            Assert.Equal(type, commandBuilderFactory.GetType());
        }

        public static IEnumerable<object[]> SetOutputTestCases => new[]
        {
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4),
                new Output { Number = 2, Type = OutputType.Output},
                typeof(IPX800v4SetOutputHttpCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4),
                new Output { Number = 2, Type = OutputType.VirtualOutput},
                typeof(IPX800v4SetVirtualOutputHttpCommandBuilder)
            }
        };

        [Theory]
        [MemberData(nameof(SetOutputTestCases))]
        public void GetSetOutCommandBuilder_ReturnsCommandBuilder_CorrespondingToContextAndInput(Context context, Output output, Type type)
        {
            //Arrange
            var v4HttpCommandBuilderFactory = new IPX800v4HttpCommandBuilderFactory();

            //Act
            ISetOutputCommandBuilder outputCommandBuilderFactory = v4HttpCommandBuilderFactory.GetSetOutputCommandBuilder(context, output);

            //Assert
            Assert.Equal(type, outputCommandBuilderFactory.GetType());
        }
        
        [Fact]
        public void GetGetVersionCommandBuilder_ThrowsIPX800NotSupportedCommandException()
        {
            //Arrange
            var context = new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V2);
            var ipx800V4HttpCommandBuilderFactory = new IPX800v4HttpCommandBuilderFactory();

            //Act/Assert
            Assert.Throws<IPX800NotSupportedCommandException>(() => ipx800V4HttpCommandBuilderFactory.GetGetVersionCommandBuilder(context));
        }

        [Fact]
        public void GivenInvalidOutputType_GetGetOutputCommandBuilder_ThrowsIPX800UnknownVersionException()
        {
            //Arrange
            var ipx800V4HttpCommandBuilderFactory = new IPX800v4HttpCommandBuilderFactory();
            var context = new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4);
            var output = new Output { Number = 2, Type = (OutputType)100 };

            //Act/Assert
            Assert.Throws<IPX800InvalidContextException>(() => ipx800V4HttpCommandBuilderFactory.GetGetOutputCommandBuilder(context, output));
        }

        [Fact]
        public void GivenInvalidOutputType_GetSetOutputCommandBuilder_ThrowsIPX800UnknownVersionException()
        {
            //Arrange
            var ipx800V4HttpCommandBuilderFactory = new IPX800v4HttpCommandBuilderFactory();
            var context = new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4);
            var output = new Output { Number = 2, Type = (OutputType)100 };

            //Act/Assert
            Assert.Throws<IPX800InvalidContextException>(() => ipx800V4HttpCommandBuilderFactory.GetSetOutputCommandBuilder(context, output));
        }

        [Fact]
        public void GivenInvalidOutputType_GetGetInputCommandBuilder_ThrowsIPX800UnknownVersionException()
        {
            //Arrange
            var ipx800V4HttpCommandBuilderFactory = new IPX800v4HttpCommandBuilderFactory();
            var context = new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4);
            var input = new Input() { Number = 2, Type = (InputType)100 };

            //Act/Assert
            Assert.Throws<IPX800InvalidContextException>(() => ipx800V4HttpCommandBuilderFactory.GetGetInputCommandBuilder(context, input));
        }
    }
}