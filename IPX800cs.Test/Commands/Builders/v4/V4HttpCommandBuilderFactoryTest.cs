using System;
using System.Collections.Generic;
using software.elendil.IPX800;
using software.elendil.IPX800.Commands.Builders;
using software.elendil.IPX800.Commands.Builders.v4;
using software.elendil.IPX800.Commands.Builders.v4.Http;
using software.elendil.IPX800.IO;
using software.elendil.IPX800.Version;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v4
{
    public class V4HttpCommandBuilderFactoryTest
    {
        public static IEnumerable<object[]> InputTestCases => new[]
        {
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4),
                new IPX800Input { Number = 2, Type = InputType.AnalogInput},
                typeof(IPX800v4GetAnalogInputHttpCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4),
                new IPX800Input { Number = 2, Type = InputType.DigitalInput},
                typeof(IPX800v4GetInputHttpCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4),
                new IPX800Input { Number = 2, Type = InputType.VirtualAnalogInput, IsVirtual = true},
                typeof(GetVirtualAnalogInputHttpCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4),
                new IPX800Input { Number = 2, Type = InputType.VirtualDigitalInput, IsVirtual = true},
                typeof(GetVirtualInHttpCommandBuilder)
            }
        };

        [Theory]
        [MemberData(nameof(InputTestCases))]
        public void GetGetInputCommandBuilder_ReturnsCommandBuilder_CorrespondingToContextAndInput(Context context, IPX800Input input, Type type)
        {
            //Arrange
            var v4HttpCommandBuilderFactory = new V4HttpCommandBuilderFactory();

            //Act
            IGetInCommandBuilder commandBuilderFactory = v4HttpCommandBuilderFactory.GetGetInputCommandBuilder(context, input);

            //Assert
            Assert.Equal(type, commandBuilderFactory.GetType());
        }

        public static IEnumerable<object[]> GetOutputTestCases => new[]
        {
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4),
                new IPX800Output { Number = 2, Type = OutputType.Output},
                typeof(IPX800v4GetOutputHttpCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4),
                new IPX800Output { Number = 2, Type = OutputType.Output, IsVirtual = true},
                typeof(GetVirtualOutHttpCommandBuilder)
            }
        };

        [Theory]
        [MemberData(nameof(GetOutputTestCases))]
        public void GetGetOutputCommandBuilder_ReturnsCommandBuilder_CorrespondingToContextAndInput(Context context, IPX800Output output, Type type)
        {
            //Arrange
            var v4HttpCommandBuilderFactory = new V4HttpCommandBuilderFactory();

            //Act
            IGetOutCommandBuilder commandBuilderFactory = v4HttpCommandBuilderFactory.GetGetOutputCommandBuilder(context, output);

            //Assert
            Assert.Equal(type, commandBuilderFactory.GetType());
        }

        public static IEnumerable<object[]> SetOutputTestCases => new[]
        {
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4),
                new IPX800Output { Number = 2, Type = OutputType.Output},
                typeof(SetOutHttpCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4),
                new IPX800Output { Number = 2, Type = OutputType.VirtualOutput, IsVirtual = true},
                typeof(SetVirtualOutHttpCommandBuilder)
            }
        };

        [Theory]
        [MemberData(nameof(SetOutputTestCases))]
        public void GetSetOutCommandBuilder_ReturnsCommandBuilder_CorrespondingToContextAndInput(Context context, IPX800Output output, Type type)
        {
            //Arrange
            var v4HttpCommandBuilderFactory = new V4HttpCommandBuilderFactory();

            //Act
            ISetCommandBuilder commandBuilderFactory = v4HttpCommandBuilderFactory.GetSetOutCommandBuilder(context, output);

            //Assert
            Assert.Equal(type, commandBuilderFactory.GetType());
        }
    }
}