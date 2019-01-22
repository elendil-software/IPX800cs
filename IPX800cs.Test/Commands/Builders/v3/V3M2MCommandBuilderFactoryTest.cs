﻿using System;
using System.Collections.Generic;
using software.elendil.IPX800;
using software.elendil.IPX800.Commands.Builders;
using software.elendil.IPX800.Commands.Builders.v3;
using software.elendil.IPX800.Commands.Builders.v3.M2M;
using software.elendil.IPX800.IO;
using software.elendil.IPX800.Version;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v3
{
    public class V3M2MCommandBuilderFactoryTest
    {
        public static IEnumerable<object[]> InputTestCases => new[]
        {
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V3),
                new IPX800Input { Number = 2, Type = InputType.AnalogInput},
                typeof(GetAnalogInputCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V3),
                new IPX800Input { Number = 2, Type = InputType.DigitalInput},
                typeof(GetInCommandBuilder)
            }
        };

        [Theory]
        [MemberData(nameof(InputTestCases))]
        public void GetGetInputCommandBuilder_ReturnsCommandBuilder_CorrespondingToContextAndInput(Context context, IPX800Input input, Type type)
        {
            //Arrange
            var v3M2MCommandBuilderFactory = new V3M2MCommandBuilderFactory();

            //Act
            IGetInCommandBuilder commandBuilderFactory = v3M2MCommandBuilderFactory.GetGetInputCommandBuilder(context, input);

            //Assert
            Assert.Equal(type, commandBuilderFactory.GetType());
        }

        public static IEnumerable<object[]> GetOutputTestCases => new[]
        {
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V3),
                new IPX800Output { Number = 2, Type = OutputType.Output},
                typeof(GetOutCommandBuilder)
            }
        };

        [Theory]
        [MemberData(nameof(GetOutputTestCases))]
        public void GetGetOutputCommandBuilder_ReturnsCommandBuilder_CorrespondingToContextAndInput(Context context, IPX800Output output, Type type)
        {
            //Arrange
            var v3M2MCommandBuilderFactory = new V3M2MCommandBuilderFactory();

            //Act
            IGetOutCommandBuilder commandBuilderFactory = v3M2MCommandBuilderFactory.GetGetOutputCommandBuilder(context, output);

            //Assert
            Assert.Equal(type, commandBuilderFactory.GetType());
        }

        public static IEnumerable<object[]> SetOutputTestCases => new[]
        {
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V3),
                new IPX800Output { Number = 2, Type = OutputType.Output},
                typeof(SetOutCommandBuilder)
            }
        };

        [Theory]
        [MemberData(nameof(SetOutputTestCases))]
        public void GetSetOutCommandBuilder_ReturnsCommandBuilder_CorrespondingToContextAndInput(Context context, IPX800Output output, Type type)
        {
            //Arrange
            var v3M2MCommandBuilderFactory = new V3M2MCommandBuilderFactory();

            //Act
            ISetCommandBuilder commandBuilderFactory = v3M2MCommandBuilderFactory.GetSetOutCommandBuilder(context, output);

            //Assert
            Assert.Equal(type, commandBuilderFactory.GetType());
        }
    }
}