namespace IPX800cs.Commands.Builders
{
    public interface ICommandBuilderFactoryProvider
    {
        ICommandBuilderFactory GetCommandBuilderFactory(Context context);
    }
}