namespace software.elendil.IPX800.Commands.Builders
{
    public interface ICommandBuilderFactoryProvider
    {
        ICommandBuilderFactory GetCommandBuilderFactory(Context context);
    }
}