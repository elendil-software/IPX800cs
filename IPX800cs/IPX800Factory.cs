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
                System.Version firmwareVersion = VersionChecker.GetVersion(context);

                if (firmwareVersion != null)
                {
                    context = new Context(ip, port, protocol, ipx800Version, user, password, firmwareVersion);
                }
                else
                {
                    context = TryToGuess(context);
                }
            }

            return new IPX800(context);
		}
        
		/// <summary>
		/// Gets the instance by guess. It try to read the first output state to identify the appropriate implementation
		/// </summary>
		/// <param name="ip">The ip</param>
		/// <param name="port">The port</param>
		/// <param name="pass">password</param>
		/// <returns>An IIPX800 implementation.</returns>
		/// <exception cref="IPX800UnknownVersionException">Unable to guess the version</exception>
		private static Context TryToGuess(Context context)
		{
            if (IsLegacy(context))
            {
                return new Context(context.IP.ToString(), context.Port, context.Protocol, context.Version, "", context.Password, new System.Version(3,5,38)); 
            }
            else if (Is30542OrNewer(context))
            {
                return new Context(context.IP.ToString(), context.Port, context.Protocol, context.Version, "", context.Password, new System.Version(3, 5, 42));
            }
			else
			{
				throw new IPX800UnknownVersionException("Unable to guess the version");
			}
		}

        /// <summary>
        /// Try implementation for firmware older than 3.05.42
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private static bool IsLegacy(Context context)
        {
            try
            {
                //Version 3.05.38 is the version released before the 3.05.42
                Context version30538Context = new Context(context.IP.ToString(), context.Port, context.Protocol, context.Version, "", context.Password, new System.Version(3,5,38));
                var ipx800 = new IPX800(version30538Context);
                ipx800.GetOut(1);
                return true;
            }
            catch (IPX800Exception)
            {
                return false;
            }
        }

        private static bool Is30542OrNewer(Context context)
        {
            try
            {
                Context version30542Context = new Context(context.IP.ToString(), context.Port, context.Protocol, context.Version, "", context.Password, new System.Version(3, 5, 42));
                var ipx800 = new IPX800(version30542Context);
                ipx800.GetOut(1);
                return true;
            }
            catch (IPX800Exception)
            {
                return false;
            }
        }
	}
}