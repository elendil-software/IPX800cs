using System;
using System.Collections.Generic;
using IPX800cs.Commands.Builders;
using IPX800cs.Commands.Builders.v3;
using IPX800cs.Commands.Builders.v3.Http;
using IPX800cs.Commands.Builders.v3.Legacy.Http;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Version;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v3
{
    public class IPX800v3HttpCommandBuilderFactoryTest
    {
        public static IEnumerable<object[]> InputTestCases => new[]
        {
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3),
                new Input { Number = 2, Type = InputType.AnalogInput},
                typeof(IPX800v3GetAnalogInputHttpCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3),
                new Input { Number = 2, Type = InputType.DigitalInput},
                typeof(IPX800v3GetInputHttpCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3, new System.Version(3,05, 42)),
                new Input { Number = 2, Type = InputType.AnalogInput},
                typeof(IPX800v3GetAnalogInputHttpCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3, new System.Version(3,05, 42)),
                new Input { Number = 2, Type = InputType.DigitalInput},
                typeof(IPX800v3GetInputHttpCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3, new System.Version(3,05, 38)),
                new Input { Number = 2, Type = InputType.AnalogInput},
                typeof(IPX800v3LegacyGetAnalogInputHttpCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3, new System.Version(3,05, 38)),
                new Input { Number = 2, Type = InputType.DigitalInput},
                typeof(IPX800v3LegacyGetInputHttpCommandBuilder)
            }
        };

        [Theory]
        [MemberData(nameof(InputTestCases))]
        public void GetGetInputCommandBuilder_ReturnsCommandBuilder_CorrespondingToContextAndInput(Context context, Input input, Type type)
        {
            //Arrange
            var ipx800V3HttpCommandBuilderFactory = new IPX800v3HttpCommandBuilderFactory();

            //Act
            IGetInputCommandBuilder commandBuilderFactory = ipx800V3HttpCommandBuilderFactory.GetGetInputCommandBuilder(context, input);

            //Assert
            Assert.Equal(type, commandBuilderFactory.GetType());
        }

        public static IEnumerable<object[]> GetOutputTestCases => new[]
        {
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3),
                new Output { Number = 2, Type = OutputType.Output},
                typeof(IPX800v3GetOutputHttpCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3, new System.Version(3, 05, 42)),
                new Output { Number = 2, Type = OutputType.Output},
                typeof(IPX800v3GetOutputHttpCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3, new System.Version(3,05, 38)),
                new Output { Number = 2, Type = OutputType.Output},
                typeof(IPX800v3LegacyGetOutputHttpCommandBuilder)
            }
        };

        [Theory]
        [MemberData(nameof(GetOutputTestCases))]
        public void GetGetOutputCommandBuilder_ReturnsCommandBuilder_CorrespondingToContextAndInput(Context context, Output output, Type type)
        {
            //Arrange
            var ipx800V3HttpCommandBuilderFactory = new IPX800v3HttpCommandBuilderFactory();

            //Act
            IGetOutputCommandBuilder commandBuilderFactory = ipx800V3HttpCommandBuilderFactory.GetGetOutputCommandBuilder(context, output);

            //Assert
            Assert.Equal(type, commandBuilderFactory.GetType());
        }

        public static IEnumerable<object[]> SetOutputTestCases => new[]
        {
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3),
                new Output { Number = 2, Type = OutputType.Output},
                typeof(IPX800v3SetOutputHttpCommandBuilder)
            }
        };

        [Theory]
        [MemberData(nameof(SetOutputTestCases))]
        public void GetSetOutCommandBuilder_ReturnsCommandBuilder_CorrespondingToContextAndInput(Context context, Output output, Type type)
        {
            //Arrange
            var ipx800V3HttpCommandBuilderFactory = new IPX800v3HttpCommandBuilderFactory();

            //Act
            ISetOutputCommandBuilder outputCommandBuilderFactory = ipx800V3HttpCommandBuilderFactory.GetSetOutputCommandBuilder(context, output);

            //Assert
            Assert.Equal(type, outputCommandBuilderFactory.GetType());
        }
        
        public static IEnumerable<object[]> GetVersionTestCases => new[]
        {
            new object[] { new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3), typeof(IPX800v3GetVersionHttpCommandBuilder) },
            new object[] { new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3, new System.Version(3,5,38)), typeof(IPX800v3LegacyGetVersionHttpCommandBuilder) }
        };

        [Theory]
        [MemberData(nameof(GetVersionTestCases))]
        public void GetGetVersionCommandBuilder_ReturnsCommandBuilder_CorrespondingToContext(Context context, Type type)
        {
            //Arrange
            var ipx800V3HttpCommandBuilderFactory = new IPX800v3HttpCommandBuilderFactory();

            //Act
            IGetVersionCommandBuilder getVersionCommandBuilder = ipx800V3HttpCommandBuilderFactory.GetGetVersionCommandBuilder(context);

            //Assert
            Assert.Equal(type, getVersionCommandBuilder.GetType());
        }

        [Fact]
        public void GivenInvalidOutputType_GetGetOutputCommandBuilder_ThrowsIPX800UnknownVersionException()
        {
            //Arrange
            var ipx800V3HttpCommandBuilderFactory = new IPX800v3HttpCommandBuilderFactory();
            var context = new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3);
            var output = new Output { Number = 2, Type = (OutputType)100 };

            //Act/Assert
            Assert.Throws<IPX800InvalidContextException>(() => ipx800V3HttpCommandBuilderFactory.GetGetOutputCommandBuilder(context, output));
        }

        [Fact]
        public void GivenInvalidOutputType_GetSetOutputCommandBuilder_ThrowsIPX800UnknownVersionException()
        {
            //Arrange
            var ipx800V3HttpCommandBuilderFactory = new IPX800v3HttpCommandBuilderFactory();
            var context = new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3);
            var output = new Output { Number = 2, Type = (OutputType)100 };

            //Act/Assert
            Assert.Throws<IPX800InvalidContextException>(() => ipx800V3HttpCommandBuilderFactory.GetSetOutputCommandBuilder(context, output));
        }

        [Fact]
        public void GivenInvalidOutputType_GetGetInputCommandBuilder_ThrowsIPX800UnknownVersionException()
        {
            //Arrange
            var ipx800V3HttpCommandBuilderFactory = new IPX800v3HttpCommandBuilderFactory();
            var context = new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3);
            var input = new Input() { Number = 2, Type = (InputType)100 };

            //Act/Assert
            Assert.Throws<IPX800InvalidContextException>(() => ipx800V3HttpCommandBuilderFactory.GetGetInputCommandBuilder(context, input));
        }
    }
}