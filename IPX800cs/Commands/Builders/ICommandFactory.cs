using IPX800cs.IO;

namespace IPX800cs.Commands.Builders;

public interface ICommandFactory
{
    string CreateGetInputCommand(Input input);
    string CreateGetInputsCommand(InputType inputType);
    string CreateGetOutputCommand(Output output);
    string CreateGetOutputsCommand(OutputType outputType);
    string CreateSetOutputCommand(Output output);
}