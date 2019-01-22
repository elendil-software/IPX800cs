using System;
using System.Collections.Generic;
using software.elendil.IPX800;
using software.elendil.IPX800.Commands.Builders;
using software.elendil.IPX800.Commands.Builders.v4;
using software.elendil.IPX800.Commands.Builders.v4.M2M;
using software.elendil.IPX800.IO;
using software.elendil.IPX800.Version;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v4
{
    public class V4M2MCommandBuilderFactoryTest
    {
        public static IEnumerable<object[]> InputTestCases => new[]
        {
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4),
                new IPX800Input { Number = 2, Type = InputType.AnalogInput},
                typeof(IPX800v4GetAnalogInputM2MCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4),
                new IPX800Input { Number = 2, Type = InputType.DigitalInput},
                typeof(IPX800v4GetInputM2MCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4),
                new IPX800Input { Number = 2, Type = InputType.VirtualAnalogInput, IsVirtual = true},
                typeof(IPX800v4GetVirtualAnalogInputM2MCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4),
                new IPX800Input { Number = 2, Type = InputType.VirtualDigitalInput, IsVirtual = true},
                typeof(IPX800v4GetVirtualInputM2MCommandBuilder)
            }
        };

        [Theory]
        [MemberData(nameof(InputTestCases))]
        public void GetGetInputCommandBuilder_ReturnsCommandBuilder_CorrespondingToContextAndInput(Context context, IPX800Input input, Type type)
        {
            //Arrange
            var v4M2MCommandBuilderFactory = new V4M2MCommandBuilderFactory();

            //Act
            IGetInCommandBuilder commandBuilderFactory = v4M2MCommandBuilderFactory.GetGetInputCommandBuilder(context, input);

            //Assert
            Assert.Equal(type, commandBuilderFactory.GetType());
        }

        public static IEnumerable<object[]> GetOutputTestCases => new[]
        {
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4),
                new IPX800Output { Number = 2, Type = OutputType.Output},
                typeof(IPX800v4GetOutputM2MCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4),
                new IPX800Output { Number = 2, Type = OutputType.VirtualOutput, IsVirtual = true},
                typeof(GetVirtualOutCommandBuilder)
            }
        };

        [Theory]
        [MemberData(nameof(GetOutputTestCases))]
        public void GetGetOutputCommandBuilder_ReturnsCommandBuilder_CorrespondingToContextAndInput(Context context, IPX800Output output, Type type)
        {
            //Arrange
            var v4M2MCommandBuilderFactory = new V4M2MCommandBuilderFactory();

            //Act
            IGetOutCommandBuilder commandBuilderFactory = v4M2MCommandBuilderFactory.GetGetOutputCommandBuilder(context, output);

            //Assert
            Assert.Equal(type, commandBuilderFactory.GetType());
        }

        public static IEnumerable<object[]> SetOutputTestCases => new[]
        {
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4),
                new IPX800Output { Number = 2, Type = OutputType.Output},
                typeof(SetOutCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4),
                new IPX800Output { Number = 2, Type = OutputType.VirtualOutput, IsVirtual = true},
                typeof(SetVirtualOutCommandBuilder)
            }
        };

        [Theory]
        [MemberData(nameof(SetOutputTestCases))]
        public void GetSetOutCommandBuilder_ReturnsCommandBuilder_CorrespondingToContextAndInput(Context context, IPX800Output output, Type type)
        {
            //Arrange
            var v4M2MCommandBuilderFactory = new V4M2MCommandBuilderFactory();

            //Act
            ISetCommandBuilder commandBuilderFactory = v4M2MCommandBuilderFactory.GetSetOutCommandBuilder(context, output);

            //Assert
            Assert.Equal(type, commandBuilderFactory.GetType());
        }
    }
}