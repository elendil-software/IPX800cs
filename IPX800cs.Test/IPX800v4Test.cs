using IPX800cs.ActionsExecutors;
using IPX800cs.IO;
using Moq;
using Xunit;

namespace IPX800cs.Test
{
    public class IPX800v4Test
    {
        [Fact]
        public void GetOutput_SendCorrectOutputObject()
        {
            //Arrange
            var setOutputExecutor = new Mock<ISetOutputExecutor>(); 
            var getOutputExecutor = new Mock<IGetOutputExecutor>();
            var getOutputsExecutor = new Mock<IGetOutputsExecutor>();
            var getInputExecutor = new Mock<IGetInputExecutor>();
            var getInputsExecutor = new Mock<IGetInputsExecutor>();
            var getAnalogInputExecutor = new Mock<IGetAnalogInputExecutor>();
            
            var ipx800 = new IPX800v4(setOutputExecutor.Object, getOutputExecutor.Object, getOutputsExecutor.Object, 
                getInputExecutor.Object, getInputsExecutor.Object, getAnalogInputExecutor.Object);

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
        public void GetVirtualOutput_SendCorrectOutputObject()
        {
            //Arrange
            var setOutputExecutor = new Mock<ISetOutputExecutor>(); 
            var getOutputExecutor = new Mock<IGetOutputExecutor>();
            var getOutputsExecutor = new Mock<IGetOutputsExecutor>();
            var getInputExecutor = new Mock<IGetInputExecutor>();
            var getInputsExecutor = new Mock<IGetInputsExecutor>();
            var getAnalogInputExecutor = new Mock<IGetAnalogInputExecutor>();
            
            var ipx800 = new IPX800v4(setOutputExecutor.Object, getOutputExecutor.Object, getOutputsExecutor.Object, 
                getInputExecutor.Object, getInputsExecutor.Object, getAnalogInputExecutor.Object);

            //Act
            ipx800.GetVirtualOutput(2);

            //Assert
            getOutputExecutor.Verify(m => m.Execute(
                It.Is<Output>(
                    o => o.Number == 2 &&
                         o.Type == OutputType.VirtualOutput && 
                         o.IsDelayed == false
                )));
        }

        [Fact]
        public void SetDelayedOutput_SendCorrectOutputObject()
        {
            //Arrange
            var setOutputExecutor = new Mock<ISetOutputExecutor>(); 
            var getOutputExecutor = new Mock<IGetOutputExecutor>();
            var getOutputsExecutor = new Mock<IGetOutputsExecutor>();
            var getInputExecutor = new Mock<IGetInputExecutor>();
            var getInputsExecutor = new Mock<IGetInputsExecutor>();
            var getAnalogInputExecutor = new Mock<IGetAnalogInputExecutor>();
            
            var ipx800 = new IPX800v4(setOutputExecutor.Object, getOutputExecutor.Object, getOutputsExecutor.Object, 
                getInputExecutor.Object, getInputsExecutor.Object, getAnalogInputExecutor.Object);

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
        public void SetDelayedVirtualOutput_SendCorrectOutputObject()
        {
            //Arrange
            var setOutputExecutor = new Mock<ISetOutputExecutor>(); 
            var getOutputExecutor = new Mock<IGetOutputExecutor>();
            var getOutputsExecutor = new Mock<IGetOutputsExecutor>();
            var getInputExecutor = new Mock<IGetInputExecutor>();
            var getInputsExecutor = new Mock<IGetInputsExecutor>();
            var getAnalogInputExecutor = new Mock<IGetAnalogInputExecutor>();
            
            var ipx800 = new IPX800v4(setOutputExecutor.Object, getOutputExecutor.Object, getOutputsExecutor.Object, 
                getInputExecutor.Object, getInputsExecutor.Object, getAnalogInputExecutor.Object);

            //Act
            ipx800.SetDelayedVirtualOutput(2);

            //Assert
            setOutputExecutor.Verify(m => m.Execute(
                It.Is<Output>(
                    o => o.Number == 2 && 
                         o.Type == OutputType.VirtualOutput &&
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
            var getOutputsExecutor = new Mock<IGetOutputsExecutor>();
            var getInputExecutor = new Mock<IGetInputExecutor>();
            var getInputsExecutor = new Mock<IGetInputsExecutor>();
            var getAnalogInputExecutor = new Mock<IGetAnalogInputExecutor>();
            
            var ipx800 = new IPX800v4(setOutputExecutor.Object, getOutputExecutor.Object, getOutputsExecutor.Object, 
                getInputExecutor.Object, getInputsExecutor.Object, getAnalogInputExecutor.Object);

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
        public void SetVirtualOutputActive_SendCorrectOutputObject()
        {
            //Arrange
            var setOutputExecutor = new Mock<ISetOutputExecutor>(); 
            var getOutputExecutor = new Mock<IGetOutputExecutor>();
            var getOutputsExecutor = new Mock<IGetOutputsExecutor>();
            var getInputExecutor = new Mock<IGetInputExecutor>();
            var getInputsExecutor = new Mock<IGetInputsExecutor>();
            var getAnalogInputExecutor = new Mock<IGetAnalogInputExecutor>();
            
            var ipx800 = new IPX800v4(setOutputExecutor.Object, getOutputExecutor.Object, getOutputsExecutor.Object, 
                getInputExecutor.Object, getInputsExecutor.Object, getAnalogInputExecutor.Object);

            //Act
            ipx800.SetVirtualOutput(2, OutputState.Active);

            //Assert
            setOutputExecutor.Verify(m => m.Execute(
                It.Is<Output>(
                    o => o.Number == 2 && 
                         o.Type == OutputType.VirtualOutput &&
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
            var getOutputsExecutor = new Mock<IGetOutputsExecutor>();
            var getInputExecutor = new Mock<IGetInputExecutor>();
            var getInputsExecutor = new Mock<IGetInputsExecutor>();
            var getAnalogInputExecutor = new Mock<IGetAnalogInputExecutor>();
            
            var ipx800 = new IPX800v4(setOutputExecutor.Object, getOutputExecutor.Object, getOutputsExecutor.Object, 
                getInputExecutor.Object, getInputsExecutor.Object, getAnalogInputExecutor.Object);

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
        public void SetVirtualOutputInactive_SendCorrectOutputObject()
        {
            //Arrange
            var setOutputExecutor = new Mock<ISetOutputExecutor>(); 
            var getOutputExecutor = new Mock<IGetOutputExecutor>();
            var getOutputsExecutor = new Mock<IGetOutputsExecutor>();
            var getInputExecutor = new Mock<IGetInputExecutor>();
            var getInputsExecutor = new Mock<IGetInputsExecutor>();
            var getAnalogInputExecutor = new Mock<IGetAnalogInputExecutor>();
            
            var ipx800 = new IPX800v4(setOutputExecutor.Object, getOutputExecutor.Object, getOutputsExecutor.Object, 
                getInputExecutor.Object, getInputsExecutor.Object, getAnalogInputExecutor.Object);

            //Act
            ipx800.SetVirtualOutput(2, OutputState.Inactive);

            //Assert
            setOutputExecutor.Verify(m => m.Execute(
                It.Is<Output>(
                    o => o.Number == 2 && 
                         o.Type == OutputType.VirtualOutput &&
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
            var getOutputsExecutor = new Mock<IGetOutputsExecutor>();
            var getInputExecutor = new Mock<IGetInputExecutor>();
            var getInputsExecutor = new Mock<IGetInputsExecutor>();
            var getAnalogInputExecutor = new Mock<IGetAnalogInputExecutor>();
            
            var ipx800 = new IPX800v4(setOutputExecutor.Object, getOutputExecutor.Object, getOutputsExecutor.Object, 
                getInputExecutor.Object, getInputsExecutor.Object, getAnalogInputExecutor.Object);

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
        public void GetVirtualInput_SendCorrectInputObject()
        {
            //Arrange
            var setOutputExecutor = new Mock<ISetOutputExecutor>(); 
            var getOutputExecutor = new Mock<IGetOutputExecutor>();
            var getOutputsExecutor = new Mock<IGetOutputsExecutor>();
            var getInputExecutor = new Mock<IGetInputExecutor>();
            var getInputsExecutor = new Mock<IGetInputsExecutor>();
            var getAnalogInputExecutor = new Mock<IGetAnalogInputExecutor>();
            
            var ipx800 = new IPX800v4(setOutputExecutor.Object, getOutputExecutor.Object, getOutputsExecutor.Object, 
                getInputExecutor.Object, getInputsExecutor.Object, getAnalogInputExecutor.Object);

            //Act
            ipx800.GetVirtualInput(2);

            //Assert
            getInputExecutor.Verify(m => m.Execute(
                It.Is<Input>(
                    o => o.Number == 2 &&
                         o.Type == InputType.VirtualDigitalInput
                )));
        }

        [Fact]
        public void GetAnalogInput_SendCorrectInputObject()
        {
            //Arrange
            var setOutputExecutor = new Mock<ISetOutputExecutor>(); 
            var getOutputExecutor = new Mock<IGetOutputExecutor>();
            var getOutputsExecutor = new Mock<IGetOutputsExecutor>();
            var getInputExecutor = new Mock<IGetInputExecutor>();
            var getInputsExecutor = new Mock<IGetInputsExecutor>();
            var getAnalogInputExecutor = new Mock<IGetAnalogInputExecutor>();
            
            var ipx800 = new IPX800v4(setOutputExecutor.Object, getOutputExecutor.Object, getOutputsExecutor.Object, 
                getInputExecutor.Object, getInputsExecutor.Object, getAnalogInputExecutor.Object);

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
        public void GetVirtualAnalogInput_SendCorrectInputObject()
        {
            //Arrange
            var setOutputExecutor = new Mock<ISetOutputExecutor>(); 
            var getOutputExecutor = new Mock<IGetOutputExecutor>();
            var getOutputsExecutor = new Mock<IGetOutputsExecutor>();
            var getInputExecutor = new Mock<IGetInputExecutor>();
            var getInputsExecutor = new Mock<IGetInputsExecutor>();
            var getAnalogInputExecutor = new Mock<IGetAnalogInputExecutor>();
            
            var ipx800 = new IPX800v4(setOutputExecutor.Object, getOutputExecutor.Object, getOutputsExecutor.Object, 
                getInputExecutor.Object, getInputsExecutor.Object, getAnalogInputExecutor.Object);

            //Act
            ipx800.GetVirtualAnalogInput(2);

            //Assert
            getAnalogInputExecutor.Verify(m => m.Execute(
                It.Is<Input>(
                    o => o.Number == 2 &&
                         o.Type == InputType.VirtualAnalogInput
                )));
        }
    }
}