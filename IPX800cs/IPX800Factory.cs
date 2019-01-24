using software.elendil.IPX800.Exceptions;
using software.elendil.IPX800.Version;

namespace software.elendil.IPX800
{
	public class IPX800Factory
	{
		/// <summary>
		/// Gets the IPX800 implementation by guess. 
		/// First it try to get the IPX800 firmware version and the corresponding implementation. 
		/// If it fails <see cref="TryToGuess"/> is called
		/// </summary>
		/// <param name="ip">The ip</param>
		/// <param name="port">The port</param>
		/// <param name="ipx800Version">The version of the IPX800</param>
		/// <param name="pass">password</param>
		/// <returns>An IIPX800 implementation.</returns>
		/// <exception cref="IPX800UnknownVersionException">Thrown if unable to guess the version</exception>
		
		public static IIPX800 GetInstance(string ip, int port, IPX800Protocol protocol, IPX800Version ipx800Version, string user, string password)
        {
            Context context = new Context(ip, port, protocol, ipx800Version, user, password);

            if (ipx800Version == IPX800Version.V3)
            {
	            context = GetIPX800v3Context(ip, port, protocol, ipx800Version, user, password);
            }

            return new IPX800(context);
		}

		private static Context GetIPX800v3Context(string ip, int port, IPX800Protocol protocol, IPX800Version ipx800Version, string user, string password)
		{
			try
			{
				//by setting no firmware version, will consider it's >= 3.05.42
				Context context = new Context(ip, port, protocol, ipx800Version, user, password);
				IIPX800 ipx800 = new IPX800(context);
				System.Version firmwareVersion = ipx800.GetVersion();
				return new Context(ip, port, protocol, ipx800Version, user, password, firmwareVersion);
			}
			//if exception is thrown, we didn't try with the correct version and should by <= 3.05.38
			catch (IPX800UnknownVersionException)
			{
				//Version 3.05.38 is the version released before the 3.05.42
				Context context =  new Context(ip, port, protocol, ipx800Version, user, password, new System.Version(3, 5, 38));
				IIPX800 ipx800 = new IPX800(context);
				System.Version firmwareVersion = ipx800.GetVersion();
				return new Context(ip, port, protocol, ipx800Version, user, password, firmwareVersion);
			}
		}
	}
}