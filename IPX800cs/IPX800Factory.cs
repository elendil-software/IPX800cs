using software.elendil.IPX800.Contracts;
using software.elendil.IPX800.Exceptions;
using software.elendil.IPX800.Version;

namespace software.elendil.IPX800
{
	public static class IPX800Factory
	{
		public static IIPX800v2 GetIPX800v2Instance(string ip, int port, IPX800Protocol protocol, string user = null, string password = null)
		{
			Context context = new Context(ip, port, protocol, IPX800Version.V2, user, password);
			return new IPX800v2(context);
		}
		
		public static IIPX800v4 GetIPX800v4Instance(string ip, int port, IPX800Protocol protocol, string user = null, string password = null)
		{
			Context context = new Context(ip, port, protocol, IPX800Version.V4, user, password);
			return new IPX800v4(context);
		}
		
		public static IIPX800v3 GetIPX800v3Instance(string ip, int port, IPX800Protocol protocol, string user = null, string password = null)
        {          
            Context context = GetIPX800v3Context(ip, port, protocol, IPX800Version.V3, user, password);
            return new IPX800v3(context);
		}

		private static Context GetIPX800v3Context(string ip, int port, IPX800Protocol protocol, IPX800Version ipx800Version, string user, string password)
		{
			try
			{
				//by setting no firmware version, will consider it's >= 3.05.42
				Context context = new Context(ip, port, protocol, ipx800Version, user, password);
				IIPX800v3 ipx800 = new IPX800v3(context);
				System.Version firmwareVersion = ipx800.GetVersion();
				return new Context(ip, port, protocol, ipx800Version, user, password, firmwareVersion);
			}
			//if exception is thrown, we didn't try with the correct version and should by <= 3.05.38
			catch (IPX800UnknownVersionException)
			{
				//Version 3.05.38 is the version released before the 3.05.42
				Context context =  new Context(ip, port, protocol, ipx800Version, user, password, new System.Version(3, 5, 38));
				IIPX800v3 ipx800 = new IPX800v3(context);
				System.Version firmwareVersion = ipx800.GetVersion();
				return new Context(ip, port, protocol, ipx800Version, user, password, firmwareVersion);
			}
		}
	}
}