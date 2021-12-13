using IPX800cs.IO;

namespace IPX800cs.Commands.Builders
{
    public interface ICommandBuilderFactory
    {
        ISetOutputCommandBuilder GetSetOutputCommandBuilder(Context context, Output output);
        IGetOutputCommandBuilder GetGetOutputCommandBuilder(Context context, Output output);
        IGetOutputsCommandBuilder GetGetOutputsCommandBuilder(Context context, Output output);
        IGetInputCommandBuilder GetGetInputCommandBuilder(Context context, Input input);
        IGetInputsCommandBuilder GetGetInputsCommandBuilder(Context context, Input input);
    }
}