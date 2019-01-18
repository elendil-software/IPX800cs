using System;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using software.elendil.IPX800.Commands.Senders;
using software.elendil.IPX800.ipx800csV1.Exceptions;

namespace software.elendil.IPX800.Version
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
		public static System.Version GetVersion(Context context)
		{
			var commandSender = new CommandSenderM2M(context);
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
		public static System.Version GetVersionByHttp(Context context)
		{
			var commandSender = new CommandSenderHttp(context);
			string versionString;

			try
			{
				var response = commandSender.ExecuteCommand("globalstatus.xml");
				XDocument xmlDoc = XDocument.Load(response);
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
						versionString = GetVersionByHttpLegacy(context);
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
				versionString = GetVersionByHttpLegacy(context);
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
		private static string GetVersionByHttpLegacy(Context context)
		{
			var commandSender = new CommandSenderHttp(context);
			string versionString;

			try
			{
				var response = commandSender.ExecuteCommand("status.xml");
				XDocument xmlDoc = XDocument.Load(response);
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