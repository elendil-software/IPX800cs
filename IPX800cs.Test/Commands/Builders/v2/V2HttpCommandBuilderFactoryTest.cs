using System;
using System.Collections.Generic;
using software.elendil.IPX800;
using software.elendil.IPX800.Commands.Builders;
using software.elendil.IPX800.Commands.Builders.v2;
using software.elendil.IPX800.Commands.Builders.v2.Http;
using software.elendil.IPX800.IO;
using software.elendil.IPX800.Version;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v2
{
    public class V2HttpCommandBuilderFactoryTest
    {
        public static IEnumerable<object[]> InputTestCases => new[]
        {
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V2),
                new IPX800Input { Number = 2, Type = InputType.AnalogInput},
                typeof(IPX800v2GetAnalogInputHttpCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V2),
                new IPX800Input { Number = 2, Type = InputType.DigitalInput},
                typeof(IPX800v2GetInputHttpCommandBuilder)
            }
        };

        [Theory]
        [MemberData(nameof(InputTestCases))]
        public void GetGetInputCommandBuilder_ReturnsCommandBuilder_CorrespondingToContextAndInput(Context context, IPX800Input input, Type type)
        {
            //Arrange
            var v2HttpCommandBuilderFactory = new V2HttpCommandBuilderFactory();

            //Act
            IGetInputCommandBuilder commandBuilderFactory = v2HttpCommandBuilderFactory.GetGetInputCommandBuilder(context, input);

            //Assert
            Assert.Equal(type, commandBuilderFactory.GetType());
        }

        public static IEnumerable<object[]> GetOutputTestCases => new[]
        {
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V2),
                new IPX800Output { Number = 2, Type = OutputType.Output},
                typeof(IPX800v2GetOutputHttpCommandBuilder)
            }
        };

        [Theory]
        [MemberData(nameof(GetOutputTestCases))]
        public void GetGetOutputCommandBuilder_ReturnsCommandBuilder_CorrespondingToContextAndInput(Context context, IPX800Output output, Type type)
        {
            //Arrange
            var v2HttpCommandBuilderFactory = new V2HttpCommandBuilderFactory();

            //Act
            IGetOutputCommandBuilder commandBuilderFactory = v2HttpCommandBuilderFactory.GetGetOutputCommandBuilder(context, output);

            //Assert
            Assert.Equal(type, commandBuilderFactory.GetType());
        }

        public static IEnumerable<object[]> SetOutputTestCases => new[]
        {
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V2),
                new IPX800Output { Number = 2, Type = OutputType.Output},
                typeof(Ipx800V2SetOutputOutputHttpCommandBuilder)
            }
        };

        [Theory]
        [MemberData(nameof(SetOutputTestCases))]
        public void GetSetOutCommandBuilder_ReturnsCommandBuilder_CorrespondingToContextAndInput(Context context, IPX800Output output, Type type)
        {
            //Arrange
            var v2HttpCommandBuilderFactory = new V2HttpCommandBuilderFactory();

            //Act
            ISetOutputCommandBuilder outputCommandBuilderFactory = v2HttpCommandBuilderFactory.GetSetOutCommandBuilder(context, output);

            //Assert
            Assert.Equal(type, outputCommandBuilderFactory.GetType());
        }
    }
}