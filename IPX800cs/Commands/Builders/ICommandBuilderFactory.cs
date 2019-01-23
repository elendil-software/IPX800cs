using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders
{
    public interface ICommandBuilderFactory
    {
        ISetOutputCommandBuilder GetSetOutCommandBuilder(Context context, IPX800Output output);
        IGetOutputCommandBuilder GetGetOutputCommandBuilder(Context context, IPX800Output input);
        IGetInputCommandBuilder GetGetInputCommandBuilder(Context context, Input input);
    }
}