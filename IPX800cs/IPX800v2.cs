using software.elendil.IPX800.ActionsExecutors;
using software.elendil.IPX800.Contracts;

namespace software.elendil.IPX800
{
    public class IPX800v2 : IPX800v3, IIPX800v2
    {
        private readonly GetVersionExecutor _getVersionExecutor;
        
        public IPX800v2(Context context) : base(context)
        {
            _getVersionExecutor = new GetVersionExecutor(context);
        }
    }
}