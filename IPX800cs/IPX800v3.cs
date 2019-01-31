using software.elendil.IPX800.ActionsExecutors;
using software.elendil.IPX800.Contracts;

namespace software.elendil.IPX800
{
    public class IPX800v3 : IPX800Base, IIPX800v3
    {
        private readonly GetVersionExecutor _getVersionExecutor;
        
        public IPX800v3(Context context) : base(context)
        {
            _getVersionExecutor = new GetVersionExecutor(context);
        }

        public System.Version GetVersion()
        {
            return _getVersionExecutor.Execute();
        }
    }
}