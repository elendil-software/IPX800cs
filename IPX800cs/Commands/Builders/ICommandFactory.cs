using IPX800cs.IO;
#pragma warning disable CS1591

namespace IPX800cs.Commands.Builders;

public interface ICommandFactory
{
    Command CreateGetInputCommand(Input input);
    Command CreateGetInputsCommand(InputType inputType);
    Command CreateGetAnalogInputCommand(AnalogInput analogInput);
    Command CreateGetAnalogInputsCommand(AnalogInputType analogInputType);
    Command CreateGetOutputCommand(Output output);
    Command CreateGetOutputsCommand(OutputType outputType);
    Command CreateSetOutputCommand(Output output);
}