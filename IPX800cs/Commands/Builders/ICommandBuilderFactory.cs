using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders
{
    public interface ICommandBuilderFactory
    {
        ISetCommandBuilder GetSetOutCommandBuilder(Context context, IPX800Output output);
        IGetOutCommandBuilder GetGetOutputCommandBuilder(Context context, IPX800Output input);
        IGetInCommandBuilder GetGetInputCommandBuilder(Context context, IPX800Input input);
    }
}