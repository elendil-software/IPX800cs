using System;
using System.Collections.Generic;
using IPX800cs.Commands.Builders;
using IPX800cs.Commands.Builders.v4;
using IPX800cs.Commands.Builders.v4.M2M;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Version;
using Xunit;

namespace IPX800cs.Test.Commands.Builders.v4
{
    public class IPX800v4M2MCommandBuilderFactoryTest
    {
        public static IEnumerable<object[]> InputTestCases => new[]
        {
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4),
                new Input { Number = 2, Type = InputType.AnalogInput},
                typeof(IPX800v4GetAnalogInputM2MCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4),
                new Input { Number = 2, Type = InputType.DigitalInput},
                typeof(IPX800v4GetInputM2MCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4),
                new Input { Number = 2, Type = InputType.VirtualAnalogInput},
                typeof(IPX800v4GetVirtualAnalogInputM2MCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4),
                new Input { Number = 2, Type = InputType.VirtualDigitalInput},
                typeof(IPX800v4GetVirtualInputM2MCommandBuilder)
            }
        };

        [Theory]
        [MemberData(nameof(InputTestCases))]
        public void GetGetInputCommandBuilder_ReturnsCommandBuilder_CorrespondingToContextAndInput(Context context, Input input, Type type)
        {
            //Arrange
            var ipx800V4M2MCommandBuilderFactory = new IPX800v4M2MCommandBuilderFactory();

            //Act
            IGetInputCommandBuilder commandBuilderFactory = ipx800V4M2MCommandBuilderFactory.GetGetInputCommandBuilder(context, input);

            //Assert
            Assert.Equal(type, commandBuilderFactory.GetType());
        }
        
        public static IEnumerable<object[]> InputsTestCases => new[]
        {
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4),
                new Input { Number = 2, Type = InputType.AnalogInput},
                typeof(IPX800v4GetAnalogInputsM2MCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4),
                new Input { Type = InputType.DigitalInput},
                typeof(IPX800v4GetInputsM2MCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4),
                new Input { Number = 2, Type = InputType.VirtualAnalogInput},
                typeof(IPX800v4GetVirtualAnalogInputsM2MCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4),
                new Input { Number = 2, Type = InputType.VirtualDigitalInput},
                typeof(IPX800v4GetVirtualInputsM2MCommandBuilder)
            }
        };

        [Theory]
        [MemberData(nameof(InputsTestCases))]
        public void GetGetInputsCommandBuilder_ReturnsCommandBuilder_CorrespondingToContextAndInput(Context context, Input input, Type type)
        {
            //Arrange
            var ipx800V4M2MCommandBuilderFactory = new IPX800v4M2MCommandBuilderFactory();

            //Act
            IGetInputsCommandBuilder commandBuilderFactory = ipx800V4M2MCommandBuilderFactory.GetGetInputsCommandBuilder(context, input);

            //Assert
            Assert.Equal(type, commandBuilderFactory.GetType());
        }

        public static IEnumerable<object[]> GetOutputTestCases => new[]
        {
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4),
                new Output { Number = 2, Type = OutputType.Output},
                typeof(IPX800v4GetOutputM2MCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4),
                new Output { Number = 2, Type = OutputType.VirtualOutput},
                typeof(IPX800v4GetVirtualOutputM2MCommandBuilder)
            }
        };

        [Theory]
        [MemberData(nameof(GetOutputTestCases))]
        public void GetGetOutputCommandBuilder_ReturnsCommandBuilder_CorrespondingToContextAndInput(Context context, Output output, Type type)
        {
            //Arrange
            var ipx800V4M2MCommandBuilderFactory = new IPX800v4M2MCommandBuilderFactory();

            //Act
            IGetOutputCommandBuilder commandBuilderFactory = ipx800V4M2MCommandBuilderFactory.GetGetOutputCommandBuilder(context, output);

            //Assert
            Assert.Equal(type, commandBuilderFactory.GetType());
        }
        
        public static IEnumerable<object[]> GetOutputsTestCases => new[]
        {
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4),
                new Output { Type = OutputType.Output},
                typeof(IPX800v4GetOutputsM2MCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4),
                new Output { Type = OutputType.VirtualOutput},
                typeof(IPX800v4GetVirtualOutputsM2MCommandBuilder)
            }
        };

        [Theory]
        [MemberData(nameof(GetOutputsTestCases))]
        public void GetGetOutputsCommandBuilder_ReturnsCommandBuilder_CorrespondingToContextAndInput(Context context, Output output, Type type)
        {
            //Arrange
            var ipx800V4M2MCommandBuilderFactory = new IPX800v4M2MCommandBuilderFactory();

            //Act
            IGetOutputsCommandBuilder commandBuilderFactory = ipx800V4M2MCommandBuilderFactory.GetGetOutputsCommandBuilder(context, output);

            //Assert
            Assert.Equal(type, commandBuilderFactory.GetType());
        }

        public static IEnumerable<object[]> SetOutputTestCases => new[]
        {
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4),
                new Output { Number = 2, Type = OutputType.Output},
                typeof(IPX800v4SetOutputM2MCommandBuilder)
            },
            new object[]
            {
                new Context("192.168.1.2", 80, IPX800Protocol.M2M, IPX800Version.V4),
                new Output { Number = 2, Type = OutputType.VirtualOutput},
                typeof(IPX800v4SetVirtualOutputM2MCommandBuilder)
            }
        };

        [Theory]
        [MemberData(nameof(SetOutputTestCases))]
        public void GetSetOutCommandBuilder_ReturnsCommandBuilder_CorrespondingToContextAndInput(Context context, Output output, Type type)
        {
            //Arrange
            var ipx800V4M2MCommandBuilderFactory = new IPX800v4M2MCommandBuilderFactory();

            //Act
            ISetOutputCommandBuilder outputCommandBuilderFactory = ipx800V4M2MCommandBuilderFactory.GetSetOutputCommandBuilder(context, output);

            //Assert
            Assert.Equal(type, outputCommandBuilderFactory.GetType());
        }
        
        [Fact]
        public void GivenInvalidOutputType_GetGetOutputCommandBuilder_ThrowsIPX800InvalidContextException()
        {
            //Arrange
            var ipx800V4M2MCommandBuilderFactory = new IPX800v4M2MCommandBuilderFactory();
            var context = new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4);
            var output = new Output {Number = 2, Type = (OutputType) 100};

            //Act/Assert
            Assert.Throws<IPX800InvalidContextException>(() => ipx800V4M2MCommandBuilderFactory.GetGetOutputCommandBuilder(context, output));
        }
        
        [Fact]
        public void GivenInvalidOutputType_GetGetOutputsCommandBuilder_ThrowsIPX800InvalidContextException()
        {
            //Arrange
            var ipx800V4M2MCommandBuilderFactory = new IPX800v4M2MCommandBuilderFactory();
            var context = new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4);
            var output = new Output { Type = (OutputType) 100};

            //Act/Assert
            Assert.Throws<IPX800InvalidContextException>(() => ipx800V4M2MCommandBuilderFactory.GetGetOutputsCommandBuilder(context, output));
        }

        [Fact]
        public void GivenInvalidOutputType_GetSetOutputCommandBuilder_ThrowsIPX800InvalidContextException()
        {
            //Arrange
            var ipx800V4M2MCommandBuilderFactory = new IPX800v4M2MCommandBuilderFactory();
            var context = new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4);
            var output = new Output { Number = 2, Type = (OutputType)100 };

            //Act/Assert
            Assert.Throws<IPX800InvalidContextException>(() => ipx800V4M2MCommandBuilderFactory.GetSetOutputCommandBuilder(context, output));
        }

        [Fact]
        public void GivenInvalidOutputType_GetGetInputCommandBuilder_ThrowsIPX800InvalidContextException()
        {
            //Arrange
            var ipx800V4M2MCommandBuilderFactory = new IPX800v4M2MCommandBuilderFactory();
            var context = new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4);
            var input = new Input() { Number = 2, Type = (InputType)100 };

            //Act/Assert
            Assert.Throws<IPX800InvalidContextException>(() => ipx800V4M2MCommandBuilderFactory.GetGetInputCommandBuilder(context, input));
        }
        
        [Fact]
        public void GivenInvalidOutputType_GetGetInputsCommandBuilder_ThrowsIPX800InvalidContextException()
        {
            //Arrange
            var ipx800V4M2MCommandBuilderFactory = new IPX800v4M2MCommandBuilderFactory();
            var context = new Context("192.168.1.2", 80, IPX800Protocol.Http, IPX800Version.V4);
            var input = new Input() { Type = (InputType)100 };

            //Act/Assert
            Assert.Throws<IPX800InvalidContextException>(() => ipx800V4M2MCommandBuilderFactory.GetGetInputsCommandBuilder(context, input));
        }
    }
}