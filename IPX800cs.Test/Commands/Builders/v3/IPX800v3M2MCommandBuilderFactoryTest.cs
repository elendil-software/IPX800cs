using System;
using System.Collections.Generic;
using software.elendil.IPX800;
using software.elendil.IPX800.Commands.Builders;
using software.elendil.IPX800.Commands.Builders.v3;
using software.elendil.IPX800.Commands.Builders.v3.M2M;
using software.elendil.IPX800.Commands.Builders.v4;
using software.elendil.IPX800.Exceptions;
using software.elendil.IPX800.IO;
using software.elendil.IPX800.Version;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v3
{
    public class IPX800v3M2MCommandBuilderFactoryTest
    {
        public static IEnumerable<object[]> InputTestCases => new[]
        {
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V3),
                new Input { Number = 2, Type = InputType.AnalogInput},
                typeof(IPX800v3GetAnalogInputM2MCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V3),
                new Input { Number = 2, Type = InputType.DigitalInput},
                typeof(IPX800v3GetInputM2MCommandBuilder)
            }
        };

        [Theory]
        [MemberData(nameof(InputTestCases))]
        public void GetGetInputCommandBuilder_ReturnsCommandBuilder_CorrespondingToContextAndInput(Context context, Input input, Type type)
        {
            //Arrange
            var ipx800V3M2MCommandBuilderFactory = new IPX800v3M2MCommandBuilderFactory();

            //Act
            IGetInputCommandBuilder commandBuilderFactory = ipx800V3M2MCommandBuilderFactory.GetGetInputCommandBuilder(context, input);

            //Assert
            Assert.Equal(type, commandBuilderFactory.GetType());
        }

        public static IEnumerable<object[]> GetOutputTestCases => new[]
        {
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V3),
                new Output { Number = 2, Type = OutputType.Output},
                typeof(IPX800v3GetOutputM2MCommandBuilder)
            }
        };

        [Theory]
        [MemberData(nameof(GetOutputTestCases))]
        public void GetGetOutputCommandBuilder_ReturnsCommandBuilder_CorrespondingToContextAndInput(Context context, Output output, Type type)
        {
            //Arrange
            var ipx800V3M2MCommandBuilderFactory = new IPX800v3M2MCommandBuilderFactory();

            //Act
            IGetOutputCommandBuilder commandBuilderFactory = ipx800V3M2MCommandBuilderFactory.GetGetOutputCommandBuilder(context, output);

            //Assert
            Assert.Equal(type, commandBuilderFactory.GetType());
        }

        public static IEnumerable<object[]> SetOutputTestCases => new[]
        {
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V3),
                new Output { Number = 2, Type = OutputType.Output},
                typeof(Ipx800V3SetOutputOutputM2MCommandBuilder)
            }
        };

        [Theory]
        [MemberData(nameof(SetOutputTestCases))]
        public void GetSetOutCommandBuilder_ReturnsCommandBuilder_CorrespondingToContextAndInput(Context context, Output output, Type type)
        {
            //Arrange
            var ipx800V3M2MCommandBuilderFactory = new IPX800v3M2MCommandBuilderFactory();

            //Act
            ISetOutputCommandBuilder outputCommandBuilderFactory = ipx800V3M2MCommandBuilderFactory.GetSetOutputCommandBuilder(context, output);

            //Assert
            Assert.Equal(type, outputCommandBuilderFactory.GetType());
        }

        [Fact]
        public void GivenInvalidOutputType_GetGetOutputCommandBuilder_ThrowsIPX800UnknownVersionException()
        {
            //Arrange
            var ipx800V3M2MCommandBuilderFactory = new IPX800v3M2MCommandBuilderFactory();
            var context = new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3);
            var output = new Output { Number = 2, Type = (OutputType)100 };

            //Act/Assert
            Assert.Throws<IPX800InvalidContextException>(() => ipx800V3M2MCommandBuilderFactory.GetGetOutputCommandBuilder(context, output));
        }

        [Fact]
        public void GivenInvalidOutputType_GetSetOutputCommandBuilder_ThrowsIPX800UnknownVersionException()
        {
            //Arrange
            var ipx800V3M2MCommandBuilderFactory = new IPX800v3M2MCommandBuilderFactory();
            var context = new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3);
            var output = new Output { Number = 2, Type = (OutputType)100 };

            //Act/Assert
            Assert.Throws<IPX800InvalidContextException>(() => ipx800V3M2MCommandBuilderFactory.GetSetOutputCommandBuilder(context, output));
        }

        [Fact]
        public void GivenInvalidOutputType_GetGetInputCommandBuilder_ThrowsIPX800UnknownVersionException()
        {
            //Arrange
            var ipx800V3M2MCommandBuilderFactory = new IPX800v3M2MCommandBuilderFactory();
            var context = new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3);
            var input = new Input() { Number = 2, Type = (InputType)100 };

            //Act/Assert
            Assert.Throws<IPX800InvalidContextException>(() => ipx800V3M2MCommandBuilderFactory.GetGetInputCommandBuilder(context, input));
        }
    }
}