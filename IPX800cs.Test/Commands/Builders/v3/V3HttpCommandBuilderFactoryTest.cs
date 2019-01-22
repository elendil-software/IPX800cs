﻿using System;
using System.Collections.Generic;
using software.elendil.IPX800;
using software.elendil.IPX800.Commands.Builders;
using software.elendil.IPX800.Commands.Builders.v3;
using software.elendil.IPX800.Commands.Builders.v3.Http;
using software.elendil.IPX800.Commands.Builders.v3.Legacy.Http;
using software.elendil.IPX800.IO;
using software.elendil.IPX800.Version;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v3
{
    public class V3HttpCommandBuilderFactoryTest
    {
        public static IEnumerable<object[]> InputTestCases => new[]
        {
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3),
                new IPX800Input { Number = 2, Type = InputType.AnalogInput},
                typeof(GetAnalogInputHttpCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3),
                new IPX800Input { Number = 2, Type = InputType.DigitalInput},
                typeof(GetInHttpCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3, new Version(3,05, 42)),
                new IPX800Input { Number = 2, Type = InputType.AnalogInput},
                typeof(GetAnalogInputHttpCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3, new Version(3,05, 42)),
                new IPX800Input { Number = 2, Type = InputType.DigitalInput},
                typeof(GetInHttpCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3, new Version(3,05, 38)),
                new IPX800Input { Number = 2, Type = InputType.AnalogInput},
                typeof(GetAnalogInputHttpLegacyCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3, new Version(3,05, 38)),
                new IPX800Input { Number = 2, Type = InputType.DigitalInput},
                typeof(GetInHttpLegacyCommandBuilder)
            }
        };

        [Theory]
        [MemberData(nameof(InputTestCases))]
        public void GetGetInputCommandBuilder_ReturnsCommandBuilder_CorrespondingToContextAndInput(Context context, IPX800Input input, Type type)
        {
            //Arrange
            var v3HttpCommandBuilderFactory = new V3HttpCommandBuilderFactory();

            //Act
            IGetInCommandBuilder commandBuilderFactory = v3HttpCommandBuilderFactory.GetGetInputCommandBuilder(context, input);

            //Assert
            Assert.Equal(type, commandBuilderFactory.GetType());
        }

        public static IEnumerable<object[]> GetOutputTestCases => new[]
        {
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3),
                new IPX800Output { Number = 2, Type = OutputType.Output},
                typeof(GetOutHttpCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3, new Version(3, 05, 42)),
                new IPX800Output { Number = 2, Type = OutputType.Output},
                typeof(GetOutHttpCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3, new Version(3,05, 38)),
                new IPX800Output { Number = 2, Type = OutputType.Output},
                typeof(GetOutHttpLegacyCommandBuilder)
            }
        };

        [Theory]
        [MemberData(nameof(GetOutputTestCases))]
        public void GetGetOutputCommandBuilder_ReturnsCommandBuilder_CorrespondingToContextAndInput(Context context, IPX800Output output, Type type)
        {
            //Arrange
            var v3HttpCommandBuilderFactory = new V3HttpCommandBuilderFactory();

            //Act
            IGetOutCommandBuilder commandBuilderFactory = v3HttpCommandBuilderFactory.GetGetOutputCommandBuilder(context, output);

            //Assert
            Assert.Equal(type, commandBuilderFactory.GetType());
        }

        public static IEnumerable<object[]> SetOutputTestCases => new[]
        {
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V3),
                new IPX800Output { Number = 2, Type = OutputType.Output},
                typeof(SetOutHttpCommandBuilder)
            }
        };

        [Theory]
        [MemberData(nameof(SetOutputTestCases))]
        public void GetSetOutCommandBuilder_ReturnsCommandBuilder_CorrespondingToContextAndInput(Context context, IPX800Output output, Type type)
        {
            //Arrange
            var v3HttpCommandBuilderFactory = new V3HttpCommandBuilderFactory();

            //Act
            ISetCommandBuilder commandBuilderFactory = v3HttpCommandBuilderFactory.GetSetOutCommandBuilder(context, output);

            //Assert
            Assert.Equal(type, commandBuilderFactory.GetType());
        }
    }
}