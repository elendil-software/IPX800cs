using IPX800cs.IO;

namespace IPX800cs.Commands.Builders
{
    public interface ICommandBuilderFactory
    {
        ISetOutputCommandBuilder GetSetOutputCommandBuilder(Context context, Output output);
        IGetOutputCommandBuilder GetGetOutputCommandBuilder(Context context, Output input);
        IGetInputCommandBuilder GetGetInputCommandBuilder(Context context, Input input);
        IGetVersionCommandBuilder GetGetVersionCommandBuilder(Context context);
    }
}