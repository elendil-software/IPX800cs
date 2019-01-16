using System;
using software.elendil.IPX800.ipx800csV1.Enum;
using software.elendil.IPX800.ipx800csV1.Exceptions;
using software.elendil.IPX800.ipx800csV1.v2.Http;
using software.elendil.IPX800.ipx800csV1.v3.Http;
using software.elendil.IPX800.ipx800csV1.Version;

namespace software.elendil.IPX800.ipx800csV1.Factories
{
	/// <summary>
	/// Class IPX800HttpFactory.
	/// </summary>
	public class IPX800HttpFactory
	{
		/// <summary>
		/// Gets the IPX800 implementation by guess.
		/// First it try to get the IPX800 firmware version and the corresponding implementation. 
		/// If it fails <see cref="TryToGuess"/> is called
		/// </summary>
		/// <param name="ip">The ip</param>
		/// <param name="port">The port</param>
		/// <param name="user">The user allowed to connect to the web interface</param>
		/// <param name="pass">The password allowed to connect to the web interface</param>
		/// <param name="ipx800Version">The version of the IPX800</param>
		/// <returns>An IIPX800 implementation.</returns>
		/// <exception cref="IPX800UnknownVersionException">Thrown if unable to guess the version</exception>
		public static IIPX800 GetInstance(string ip, ushort port, IPX800Version ipx800Version, string user = "",
			string pass = "")
		{
			if (IPX800Version.V2.Equals(ipx800Version))
			{
				return new IPX800V2Http(ip, port, user, pass);
			}

			if (IPX800Version.V4.Equals(ipx800Version))
			{
                return new v4.Http.IPX800Http(ip, port, pass);
			}

			System.Version version = VersionChecker.GetVersionByHttp(ip, port, user, pass);

			if (version != null)
			{
				var ipx800 = GetInstanceForFirmwareVersion(ip, port, version, user, pass);
				return ipx800;
			}
			else
			{
				var ipx800 = TryToGuess(ip, port, user, pass);
				return ipx800;
			}
		}

		/// <summary>
		/// Gets the IPX800 implementation corresponding to a firmware version
		/// </summary>
		/// <param name="ip">The ip of the IPX800</param>
		/// <param name="port">The http port</param>
		/// <param name="firmwareVersion">The firmware version.</param>
		/// <param name="user">The user allowed to connect to the web interface</param>
		/// <param name="pass">The password allowed to connect to the web interface</param>
		/// <returns>IIPX800 implementation corresponding to the given version</returns>
		[Obsolete("This method shouldn't be used anymore, use GetInstance instead. If GetInstance can't determinate the correct implementation it will call GetInstanceForFirmwareVersion as this method do. This method doesn't support IPX800 v4")]
		public static IIPX800 GetInstanceForVersion(string ip, ushort port, System.Version firmwareVersion, string user = "",
			string pass = "")
		{
			return GetInstanceForFirmwareVersion(ip, port, firmwareVersion, user, pass);
		}

		/// <summary>
		/// Gets the IPX800 implementation corresponding to a firmware version
		/// </summary>
		/// <param name="ip">The ip of the IPX800</param>
		/// <param name="port">The http port</param>
		/// <param name="firmwareVersion">The firmware version.</param>
		/// <param name="user">The user allowed to connect to the web interface</param>
		/// <param name="pass">The password allowed to connect to the web interface</param>
		/// <returns>IIPX800 implementation corresponding to the given version</returns>
		public static IIPX800 GetInstanceForFirmwareVersion(string ip, ushort port, System.Version firmwareVersion, string user = "",
			string pass = "")
		{
			var version30542 = new System.Version("3.05.42");
			var version30029 = new System.Version("3.00.29");

			if (firmwareVersion.CompareTo(version30029) <= 0)
			{
				return new IPX800V2Http(ip, port, user, pass);
			}

			if (firmwareVersion.CompareTo(version30542) >= 0)
			{
				return new IPX800Http(ip, port, user, pass);
			}

			return new IPX800HttpLegacy(ip, port, user, pass);
		}

		#region private methods

		/// <summary>
		/// Gets the instance by full guess. It try to read the first output state to identify the appropriate implementation
		/// </summary>
		/// <param name="ip">The ip</param>
		/// <param name="port">The port</param>
		/// <param name="user">The user allowed to connect to the web interface</param>
		/// <param name="pass">The password allowed to connect to the web interface</param>
		/// <returns>An IIPX800 implementation.</returns>
		/// <exception cref="IPX800UnknownVersionException">Unable to guess the version</exception>
		private static IIPX800 TryToGuess(string ip, ushort port, string user, string pass)
		{
			if (IsIPX800Http(ip, port, user, pass))
			{
				return new IPX800Http(ip, port, user, pass);
			}

			if (IsIPX800HttpLegacy(ip, port, user, pass))
			{
				return new IPX800HttpLegacy(ip, port, user, pass);
			}

			throw new IPX800UnknownVersionException("Unable to guess the version");
		}

		private static bool IsIPX800Http(string ip, ushort port, string user, string pass)
		{
			try
			{
				var ipx800 = new IPX800Http(ip, port, user, pass);
				ipx800.GetOut(1);
				return true;
			}
			catch (IPX800Exception)
			{
				return false;
			}
		}

		private static bool IsIPX800HttpLegacy(string ip, ushort port, string user, string pass)
		{
			try
			{
				var ipx800 = new IPX800HttpLegacy(ip, port, user, pass);
				ipx800.GetOut(1);
				return true;
			}
			catch (IPX800Exception)
			{
				return false;
			}
		}

		#endregion
	}
}