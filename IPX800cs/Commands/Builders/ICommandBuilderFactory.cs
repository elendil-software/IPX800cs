using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders
{
    public interface ICommandBuilderFactory
    {
        ISetOutputCommandBuilder GetSetOutputCommandBuilder(Context context, Output output);
        IGetOutputCommandBuilder GetGetOutputCommandBuilder(Context context, Output input);
        IGetInputCommandBuilder GetGetInputCommandBuilder(Context context, Input input);
        IGetVersionCommandBuilder GetGetVersionCommandBuilder(Context context);
    }
}