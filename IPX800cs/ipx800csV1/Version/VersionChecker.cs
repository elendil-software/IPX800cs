using System;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using software.elendil.IPX800.ipx800csV1.CommandSenders;
using software.elendil.IPX800.ipx800csV1.Exceptions;

namespace software.elendil.IPX800.ipx800csV1.Version
{
	/// <summary>
	/// Class VersionChecker.
	/// </summary>
	public static class VersionChecker
	{
		/// <summary>
		/// Gets the version of the IPX800 firmware
		/// </summary>
		/// <param name="ip">The ip.</param>
		/// <param name="port">The port.</param>
		/// <param name="pass">password (if configured in the IPX)</param>
		/// <returns> the version of the IPX800 firmware</returns>
		public static System.Version GetVersion(string ip, ushort port, string pass = "")
		{
			var commandSender = new CommandSenderM2M(ip, port, pass);
			var versionString = (string) commandSender.ExecuteCommand("GetVersion");
			var version = ParseVersion(versionString);
			return version;
		}

		/// <summary>
		/// Gets the version by HTTP.
		/// </summary>
		/// <param name="ip">The ip.</param>
		/// <param name="port">The port.</param>
		/// <param name="user">The user.</param>
		/// <param name="pass">The pass.</param>
		/// <returns>System.Version.</returns>
		public static System.Version GetVersionByHttp(string ip, ushort port, string user = null, string pass = null)
		{
			var commandSender = new CommandSenderHttp(ip, port, user, pass);
			string versionString;

			try
			{
				var xmlDoc = (XDocument) commandSender.ExecuteCommand("globalstatus.xml");
				versionString = xmlDoc.Element("response").Elements("version").FirstOrDefault().Value;
			}
			catch (IPX800ConnectionException connectionException)
			{
				if (connectionException.InnerException != null &&
				    connectionException.InnerException.GetType() == typeof (WebException))
				{
					var webException = (WebException) connectionException.InnerException;
					var response = (HttpWebResponse) webException.Response;

					if (response != null && response.StatusCode.Equals(HttpStatusCode.NotFound))
					{
						versionString = GetVersionByHttpLegacy(ip, port, user, pass);
					}
					else
					{
						throw;
					}
				}
				else
				{
					throw;
				}
			}
			catch (Exception)
			{
				versionString = GetVersionByHttpLegacy(ip, port, user, pass);
			}

			var version = ParseVersion(versionString);
			return version;
		}

		/// <summary>
		/// Gets the version by HTTP legacy.
		/// </summary>
		/// <param name="ip">The ip.</param>
		/// <param name="port">The port.</param>
		/// <param name="user">The user.</param>
		/// <param name="pass">The pass.</param>
		/// <returns>System.String.</returns>
		private static string GetVersionByHttpLegacy(string ip, ushort port, string user = null, string pass = null)
		{
			var commandSender = new CommandSenderHttp(ip, port, user, pass);
			string versionString;

			try
			{
				var xmlDoc = (XDocument) commandSender.ExecuteCommand("status.xml");
				versionString = xmlDoc.Element("response").Elements("version").FirstOrDefault().Value;
			}
			catch (IPX800ConnectionException connectionException)
			{
				if (connectionException.InnerException != null &&
				    connectionException.InnerException.GetType() == typeof (WebException))
				{
					var webException = (WebException) connectionException.InnerException;
					var response = (HttpWebResponse) webException.Response;

					if (response.StatusCode.Equals(HttpStatusCode.NotFound))
					{
						versionString = "UNKNOWN";
					}
					else
					{
						throw;
					}
				}
				else
				{
					throw;
				}
			}
			catch (Exception)
			{
				versionString = "UNKNOWN";
			}

			return versionString;
		}

		/// <summary>
		/// Parses the version.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <returns>Version instance, <c>null</c> if unable to parse the input string</returns>
		private static System.Version ParseVersion(string input)
		{
			if (string.IsNullOrEmpty(input))
			{
				return null;
			}

			input = input.Replace("GetVersion=", "").Trim();
			input = new Regex(@"[A-Za-z]").Replace(input, "");

			System.Version version;
			return System.Version.TryParse(input, out version) ? version : null;
		}
	}
}