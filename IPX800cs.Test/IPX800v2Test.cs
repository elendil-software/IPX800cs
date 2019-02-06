using IPX800cs.ActionsExecutors;
using IPX800cs.IO;
using Moq;
using Xunit;

namespace IPX800cs.Test
{
    public class IPX800v2Test
    {
        [Fact]
        public void GetOutput_SendCorrectOutputObject()
        {
            //Arrange
            var setOutputExecutor = new Mock<ISetOutputExecutor>(); 
            var getOutputExecutor = new Mock<IGetOutputExecutor>();
            var getInputExecutor = new Mock<IGetInputExecutor>();
            var getAnalogInputExecutor = new Mock<IGetAnalogInputExecutor>();
            var versionExecutor = new Mock<IGetVersionExecutor>();
            
            var ipx800 = new IPX800v2(setOutputExecutor.Object,
                getOutputExecutor.Object, getInputExecutor.Object,
                getAnalogInputExecutor.Object, versionExecutor.Object);

            //Act
            ipx800.GetOutput(2);

            //Assert
            getOutputExecutor.Verify(m => m.Execute(
                It.Is<Output>(
                    o => o.Number == 2 &&
                         o.Type == OutputType.Output && 
                         o.IsDelayed == false
                )));
        }

        [Fact]
        public void SetDelayedOutput_SendCorrectOutputObject()
        {
            //Arrange
            var setOutputExecutor = new Mock<ISetOutputExecutor>(); 
            var getOutputExecutor = new Mock<IGetOutputExecutor>();
            var getInputExecutor = new Mock<IGetInputExecutor>();
            var getAnalogInputExecutor = new Mock<IGetAnalogInputExecutor>();
            var versionExecutor = new Mock<IGetVersionExecutor>();
            
            var ipx800 = new IPX800v2(setOutputExecutor.Object,
                getOutputExecutor.Object, getInputExecutor.Object,
                getAnalogInputExecutor.Object, versionExecutor.Object);

            //Act
            ipx800.SetDelayedOutput(2);

            //Assert
            setOutputExecutor.Verify(m => m.Execute(
                It.Is<Output>(
                    o => o.Number == 2 && 
                         o.Type == OutputType.Output &&
                         o.State == OutputState.Active && 
                         o.IsDelayed
            )));
        }

        [Fact]
        public void SetOutputActive_SendCorrectOutputObject()
        {
            //Arrange
            var setOutputExecutor = new Mock<ISetOutputExecutor>(); 
            var getOutputExecutor = new Mock<IGetOutputExecutor>();
            var getInputExecutor = new Mock<IGetInputExecutor>();
            var getAnalogInputExecutor = new Mock<IGetAnalogInputExecutor>();
            var versionExecutor = new Mock<IGetVersionExecutor>();
            
            var ipx800 = new IPX800v2(setOutputExecutor.Object,
                getOutputExecutor.Object, getInputExecutor.Object,
                getAnalogInputExecutor.Object, versionExecutor.Object);

            //Act
            ipx800.SetOutput(2, OutputState.Active);

            //Assert
            setOutputExecutor.Verify(m => m.Execute(
                It.Is<Output>(
                    o => o.Number == 2 && 
                         o.Type == OutputType.Output &&
                         o.State == OutputState.Active && 
                         o.IsDelayed == false
            )));
        }

        [Fact]
        public void SetOutputInactive_SendCorrectOutputObject()
        {
            //Arrange
            var setOutputExecutor = new Mock<ISetOutputExecutor>(); 
            var getOutputExecutor = new Mock<IGetOutputExecutor>();
            var getInputExecutor = new Mock<IGetInputExecutor>();
            var getAnalogInputExecutor = new Mock<IGetAnalogInputExecutor>();
            var versionExecutor = new Mock<IGetVersionExecutor>();
            
            var ipx800 = new IPX800v2(setOutputExecutor.Object,
                getOutputExecutor.Object, getInputExecutor.Object,
                getAnalogInputExecutor.Object, versionExecutor.Object);

            //Act
            ipx800.SetOutput(2, OutputState.Inactive);

            //Assert
            setOutputExecutor.Verify(m => m.Execute(
                It.Is<Output>(
                    o => o.Number == 2 && 
                         o.Type == OutputType.Output &&
                         o.State == OutputState.Inactive && 
                         o.IsDelayed == false
            )));
        }

        [Fact]
        public void GetInput_SendCorrectInputObject()
        {
            //Arrange
            var setOutputExecutor = new Mock<ISetOutputExecutor>();
            var getOutputExecutor = new Mock<IGetOutputExecutor>();
            var getInputExecutor = new Mock<IGetInputExecutor>();
            var getAnalogInputExecutor = new Mock<IGetAnalogInputExecutor>();
            var versionExecutor = new Mock<IGetVersionExecutor>();

            var ipx800 = new IPX800v2(setOutputExecutor.Object,
                getOutputExecutor.Object, getInputExecutor.Object,
                getAnalogInputExecutor.Object, versionExecutor.Object);

            //Act
            ipx800.GetInput(2);

            //Assert
            getInputExecutor.Verify(m => m.Execute(
                It.Is<Input>(
                    o => o.Number == 2 &&
                         o.Type == InputType.DigitalInput
                )));
        }

        [Fact]
        public void GetAnalogInput_SendCorrectInputObject()
        {
            //Arrange
            var setOutputExecutor = new Mock<ISetOutputExecutor>();
            var getOutputExecutor = new Mock<IGetOutputExecutor>();
            var getInputExecutor = new Mock<IGetInputExecutor>();
            var getAnalogInputExecutor = new Mock<IGetAnalogInputExecutor>();
            var versionExecutor = new Mock<IGetVersionExecutor>();

            var ipx800 = new IPX800v2(setOutputExecutor.Object,
                getOutputExecutor.Object, getInputExecutor.Object,
                getAnalogInputExecutor.Object, versionExecutor.Object);

            //Act
            ipx800.GetAnalogInput(2);

            //Assert
            getAnalogInputExecutor.Verify(m => m.Execute(
                It.Is<Input>(
                    o => o.Number == 2 &&
                         o.Type == InputType.AnalogInput
                )));
        }

        [Fact]
        public void GetVersion_CallGetVersionOnce()
        {
            //Arrange
            var setOutputExecutor = new Mock<ISetOutputExecutor>();
            var getOutputExecutor = new Mock<IGetOutputExecutor>();
            var getInputExecutor = new Mock<IGetInputExecutor>();
            var getAnalogInputExecutor = new Mock<IGetAnalogInputExecutor>();
            var versionExecutor = new Mock<IGetVersionExecutor>();

            var ipx800 = new IPX800v2(setOutputExecutor.Object,
                getOutputExecutor.Object, getInputExecutor.Object,
                getAnalogInputExecutor.Object, versionExecutor.Object);

            //Act
            ipx800.GetVersion();

            //Assert
            versionExecutor.Verify(m => m.Execute(), Times.Once);
        }
    }
}