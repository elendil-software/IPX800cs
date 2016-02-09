using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using Microsoft.Win32;
using software.elendil.IPX800;
using software.elendil.IPX800.Enum;
using software.elendil.IPX800.Factories;
using software.elendil.IPX800.Version;

namespace TestApplication
{
	internal class Program
	{
		private static IIPX800 ipx800M2M;
		private static IIPX800 ipx800Http;
		private static string ip;
		private static ushort port;
		private static ushort portHttp;
		private static string user = "";
		private static string pass = "";

		private static uint numOutput;
		private static uint numOutputFugitive;
		private static int durationOutputFugitive;
		private static uint numInput;
		private static uint numAnInput;

		private static Version version;
		private static Version versionHttp;

		private readonly StringBuilder stringBuilder = new StringBuilder();
		private readonly StringBuilder configString = new StringBuilder();

		private static IPX800Version ipx800Version;

		private static void Main()
		{
			var prog = new Program();

			try
			{
				//This is a test application that can be useful to test the IPX800 C# lib against a specific IPX800 version or firmware version

				//default setup can be useful for repetitive tests. complete the method with your default settings
				SetDefaultSetup();
				//if you want to use default setup, comment this line.
				prog.Setup();

				prog.PrintConfig();

				Console.WriteLine("Press a key to start...");
				Console.WriteLine("");
				Console.ReadKey();

				prog.TestCheckVersion();

				prog.TestFactories();

				if (ipx800M2M != null)
				{
					prog.PrintAndAppend("Test IPX800 with M2M protocol");
					prog.PrintAndAppend("-------------------------------------------\n");

					prog.PrintAndAppend("Read test");
					prog.PrintAndAppend("---------------");
					prog.TestRead(ipx800M2M);
					prog.ResetOutputs(ipx800M2M);
					Thread.Sleep(500);

					prog.PrintAndAppend("\nActivate/deactivate test");
					prog.PrintAndAppend("-------------------------------");
					prog.TestOutput(ipx800M2M, numOutput);
					prog.ResetOutputs(ipx800M2M);
					Thread.Sleep(500);

					//prog.PrintAndAppend("\nActivate/deactivate test (fugitive mode)");
					//prog.PrintAndAppend("----------------------------------------------");
					//prog.TestOutput(ipx800M2M, numOutputFugitive);
					//prog.ResetOutputs(ipx800M2M);
					//Thread.Sleep(500);

					prog.PrintAndAppend("\nTest fugitive output");
					prog.PrintAndAppend("------------------------");
					prog.TestFugitiveOutput(ipx800M2M);
					prog.ResetOutputs(ipx800M2M);

					prog.PrintAppendEndTestLine();
					Thread.Sleep(500);
				}
				else
				{
					prog.PrintAndAppend("The M2M implementation is unknown is unknown, test skipped");
					prog.PrintAppendEndTestLine();
				}

				if (ipx800Http != null)
				{
					prog.PrintAndAppend("Test IPX800 with HTTP protocol");
					prog.PrintAndAppend("--------------------------------------------\n");

					prog.PrintAndAppend("Read test");
					prog.PrintAndAppend("---------------");
					prog.TestRead(ipx800Http);
					prog.ResetOutputs(ipx800Http);
					Thread.Sleep(500);

					prog.PrintAndAppend("\nActivate/deactivate test");
					prog.PrintAndAppend("-------------------------------");
					prog.TestOutput(ipx800Http, numOutput);
					prog.ResetOutputs(ipx800Http);
					Thread.Sleep(500);

					//prog.PrintAndAppend("\nActivate/deactivate test (fugitive mode)");
					//prog.PrintAndAppend("----------------------------------------------");
					//prog.TestOutput(ipx800Http, numOutputFugitive);
					//prog.ResetOutputs(ipx800Http);
					//Thread.Sleep(500);

					prog.PrintAndAppend("\nTest fugitive output");
					prog.PrintAndAppend("------------------------");
					prog.TestFugitiveOutput(ipx800Http);
					prog.ResetOutputs(ipx800Http);
					prog.PrintAppendEndTestLine();
					Thread.Sleep(500);
				}
				else
				{
					prog.PrintAndAppend("The HTTP implementation is unknown, test skipped");
					prog.PrintAppendEndTestLine();
				}
			}
			catch (Exception e)
			{
				prog.PrintAndAppend("An error occurred during the test : " + e.Message);
				prog.PrintAndAppend(e.StackTrace);
			}

			prog.SaveTest();

			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("Press a key to close application...");
			Console.ReadKey();
		}

		#region Setup

		private static void SetDefaultSetup()
		{
			ip = "192.168.1.41";
			port = 9870;
			portHttp = 80;
			user = "1234";
			pass = "1234";
			numOutput = 1;
			numOutputFugitive = 2;
			durationOutputFugitive = 2;
			numInput = 3;
			numAnInput = 1;
			ipx800Version = IPX800Version.V3;
		}

		private void Setup()
		{
			Console.WriteLine("Entrez la version de votre IPX800 (2, 3 or 4)\nEnter the version of your IPX800 (2, 3 or 4) : ");
			var numVersion = Console.ReadLine();
			switch (numVersion)
			{
				case "2":
					ipx800Version = IPX800Version.V2;
					break;

				case "3":
					ipx800Version = IPX800Version.V3;
					break;

				case "4":
					ipx800Version = IPX800Version.V4;
					break;

				default:
					throw new Exception("This version of the IPX800 is not valid : " + numVersion);
			}

			Console.WriteLine("Entrez l'adresse IP de votre IPX\nEnter the IP of your IPX : ");
			ip = Console.ReadLine();

			Console.WriteLine(
				"\nEntrez le numéro du port pour les commandes M2M (valeur par défaut : 9870)\nEnter the port number for M2M command (default 9870) : ");
			var portM2MRead = Console.ReadLine();
			if (portM2MRead == null || portM2MRead.Trim().Length == 0)
			{
				port = 9870;
			}
			else
			{
				port = Convert.ToUInt16(portM2MRead);
			}

			Console.WriteLine(
				"\nEntrez le numéro du port pour les commandes HTTP (valeur par défaut : 80)\nEnter the port number for HTTP command (default 80) : ");
			var portRead = Console.ReadLine();
			if (portRead == null || portRead.Trim().Length == 0)
			{
				portHttp = 80;
			}
			else
			{
				portHttp = Convert.ToUInt16(portRead);
			}

			Console.WriteLine(
				"\nEntrez le nom d'utilisateur (facultatif si non configuré ou si  IPX800 v4)\n" +
				"Enter the username (optional if not configured or if IPX800 v4) : ");
			user = Console.ReadLine();

			Console.WriteLine(
				"\nEntrez le mot de passe/clé (facultatif si non configuré)\nEnter the password/key (optional if not configured) : ");
			pass = Console.ReadLine();

			Console.WriteLine("\nEntrez un numéro de sortie.\nEnter an output number : ");
			numOutput = Convert.ToUInt16(Console.ReadLine());

			Console.WriteLine(
				"\nEntrez un numéro de sortie configuré en mode fugitif (impulsion).\nEnter an output number that is configured in fugitive mode : ");
			numOutputFugitive = Convert.ToUInt16(Console.ReadLine());

			Console.WriteLine(
				"\nEntrez la durée d'impulsion, en secondes, configuré pour la sortie en mode fugitif\nEnter the impulsion duration (in seconds) of the output configured in fugitive mode : ");
			durationOutputFugitive = Convert.ToUInt16(Console.ReadLine());

			Console.WriteLine("\nEntrez un numéro d'entrée numérique :\nEnter a digital input number : ");
			numInput = Convert.ToUInt16(Console.ReadLine());

			Console.WriteLine("\nEntrez un numéro d'entrée analogique\nEnter an analog input number : ");
			numAnInput = Convert.ToUInt16(Console.ReadLine());
		}

		#endregion

		private void TestFugitiveOutput(IIPX800 ipx800)
		{
			try
			{
				var resSet = ipx800.SetOut(numOutputFugitive, OutputState.Active, true);
				Thread.Sleep(200);
				var resGet = ipx800.GetOut(numOutputFugitive);
				PrintAndAppend("Activate output " + numOutputFugitive + ", response : " + resSet.Trim() + ", state : " + resGet);

				PrintAndAppend("Wait for impulsion end (" + durationOutputFugitive + "s)");
				Thread.Sleep(durationOutputFugitive*1000 + 2000);

				resGet = ipx800.GetOut(numOutputFugitive);
				PrintAndAppend("Check output state : " + resGet);
			}
			catch (Exception e)
			{
				PrintAndAppend("An error occurred during TestFugitiveOutput : " + e.Message);
				PrintAndAppend(e.StackTrace);
			}
		}

		private void TestOutput(IIPX800 ipx800, uint num)
		{
			try
			{
				var resSet = ipx800.SetOut(num, OutputState.Active, false);
				Thread.Sleep(200);
				var resGet = ipx800.GetOut(num);
				PrintAndAppend("Activate output " + num + ", response : " + resSet.Trim() + ", state : " + resGet);

				resSet = ipx800.SetOut(num, OutputState.Inactive, false);
				Thread.Sleep(200);
				resGet = ipx800.GetOut(num);
				PrintAndAppend("Deactivate output " + num + ", response : " + resSet.Trim() + ", state : " + resGet);
			}
			catch (Exception e)
			{
				PrintAndAppend("An error occurred during TestOutput : " + e.Message);
				PrintAndAppend(e.StackTrace);
			}
		}

		private void TestRead(IIPX800 ipx800)
		{
			try
			{
				PrintAndAppend("Output " + numOutput + " : " + ipx800.GetOut(numOutput));
				Thread.Sleep(500);
				PrintAndAppend("Input (numeric) " + numInput + " : " + ipx800.GetIn(numInput));
				Thread.Sleep(500);
				PrintAndAppend("Input (analog) " + numAnInput + " : " + ipx800.GetAn(numAnInput));
			}
			catch (Exception e)
			{
				PrintAndAppend("An error occurred during TestRead : " + e.Message);
				PrintAndAppend(e.StackTrace);
			}
		}

		private void TestCheckVersion()
		{
			PrintAndAppend("Check version");
			PrintAndAppend("--------------------------");

			try
			{
				version = VersionChecker.GetVersion(ip, Convert.ToUInt16(port), pass);
				PrintAndAppend("IPX800 firmware version (Test M2M) : " + (version == null ? "UNKNOWN VERSION" : version.ToString()));
			}
			catch (Exception e)
			{
				PrintAndAppend("Unable to check version (Test M2M) : " + e.Message);
				PrintAndAppend(e.StackTrace);
			}

			try
			{
				versionHttp = VersionChecker.GetVersionByHttp(ip, Convert.ToUInt16(portHttp), user, pass);
				PrintAndAppend("IPX800 firmware version (Test HTTP) : " +
				               (versionHttp == null ? "UNKNOWN VERSION" : versionHttp.ToString()));
			}
			catch (Exception e)
			{
				PrintAndAppend("Unable to check version Test HTTP) : " + e.Message);
				PrintAndAppend(e.StackTrace);
			}

			PrintAppendEndTestLine();
		}

		private void TestFactories()
		{
			PrintAndAppend("Test factories (M2M)");
			PrintAndAppend("--------------------------------------------------------------");

			try
			{
				if (version == null)
				{
					PrintAndAppend("IPX800M2MFactory.GetInstanceForVersion : SKIPPED, UNKNOWN VERSION");
				}
				else
				{
					ipx800M2M = IPX800M2MFactory.GetInstanceForVersion(ip, port, version, pass);
					PrintAndAppend("IPX800M2MFactory.GetInstanceForVersion : OK");
				}
			}
			catch (Exception e)
			{
				PrintAndAppend("IPX800M2MFactory.GetInstanceForVersion : ERROR, " + e.Message);
				PrintAndAppend(e.StackTrace);
			}

			try
			{
				ipx800M2M = IPX800M2MFactory.GetInstance(ip, port, ipx800Version, pass);
				PrintAndAppend("IPX800M2MFactory.GetInstance : OK");
			}
			catch (Exception e)
			{
				PrintAndAppend("IPX800M2MFactory.GetInstance : ERROR, " + e.Message);
				PrintAndAppend(e.StackTrace);
			}

			PrintAndAppend();
			PrintAndAppend("Test factories  (HTTP)");
			PrintAndAppend("--------------------------------------------------------------");
			PrintAndAppend("Authentication : " +
			               ((String.IsNullOrWhiteSpace(user) || String.IsNullOrWhiteSpace(pass)) ? "no" : "yes"));


			try
			{
				if (version == null)
				{
					PrintAndAppend("IPX800HttpFactory.GetInstanceForVersion : SKIPPED, UNKNOWN VERSION");
				}
				else
				{
					ipx800Http = IPX800HttpFactory.GetInstanceForVersion(ip, portHttp, version, user, pass);
					PrintAndAppend("IPX800HttpFactory.GetInstanceForVersion : OK");
				}
			}
			catch (Exception e)
			{
				PrintAndAppend("IPX800HttpFactory.GetInstanceForVersion : ERROR, " + e.Message);
				PrintAndAppend(e.StackTrace);
			}

			try
			{
				ipx800Http = IPX800HttpFactory.GetInstance(ip, portHttp, ipx800Version, user, pass);
				PrintAndAppend("IPX800HttpFactory.GetInstance : OK");
			}
			catch (Exception e)
			{
				PrintAndAppend("IPX800HttpFactory.GetInstance : ERROR, " + e.Message);
				PrintAndAppend(e.StackTrace);
			}

			PrintAndAppend();
			PrintAndAppend("implementation class M2M  : " + ((ipx800M2M != null) ? ipx800M2M.GetType().ToString() : "?"));
			PrintAndAppend("implementation class HTTP : " + ((ipx800Http != null) ? ipx800Http.GetType().ToString() : "?"));

			PrintAppendEndTestLine();
		}

		private void ResetOutputs(IIPX800 ipx800)
		{
			try
			{
				ipx800.SetOut(numOutput, OutputState.Inactive, false);
				Thread.Sleep(200);
				if (ipx800.GetOut(numOutput) == OutputState.Active)
				{
					PrintAndAppend("Output was not deactivated");
				}

				ipx800.SetOut(numOutputFugitive, OutputState.Inactive, false);
				Thread.Sleep(200);
				if (ipx800.GetOut(numOutputFugitive) == OutputState.Active)
				{
					PrintAndAppend("Fugitive output was not deactivated");
				}
			}
			catch (Exception e)
			{
				PrintAndAppend("An error occurred during ResetOutputs : " + e.Message);
				PrintAndAppend(e.StackTrace);
			}
		}

		#region print/append/save

		private void PrintAndAppend(string str = "")
		{
			Console.WriteLine(str);
			stringBuilder.AppendLine(str);
		}

		private String DotNetVersion()
		{
			var installedVersions = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP");
			if (installedVersions != null)
			{
				string[] versionNames = installedVersions.GetSubKeyNames();

				StringBuilder strVersion = new StringBuilder();

				foreach (var versionStr in versionNames)
				{
					strVersion.Append(versionStr);
					strVersion.Append("; ");
				}

				return strVersion.ToString();
			}

			return "?";
		}

		private void PrintConfig(bool append = true)
		{
			configString.AppendLine("");
			configString.AppendLine("=========================================================================");
			configString.AppendLine("OS Version			: " + Environment.OSVersion);
			configString.AppendLine(".NET Versions			: " + DotNetVersion());
			configString.AppendLine("Culture Info			: " + CultureInfo.CurrentCulture.Name);
			configString.AppendLine("IPX800 version		: " + ipx800Version);
			configString.AppendLine("IP				: " + ip);
			configString.AppendLine("Port M2M			: " + port);
			configString.AppendLine("Port HTTP			: " + portHttp);
			configString.AppendLine("user				: *****");
			configString.AppendLine("pass				: *****");
			configString.AppendLine("numOutput			: " + numOutput);
			configString.AppendLine("numOutputFugitive		: " + numOutputFugitive);
			configString.AppendLine("durationOutputFugitive		: " + durationOutputFugitive);
			configString.AppendLine("numInput			: " + numInput);
			configString.AppendLine("numAnInput			: " + numAnInput);
			configString.AppendLine("=========================================================================");
			configString.AppendLine("");

			Console.WriteLine(configString.ToString());

			if (append)
			{
				stringBuilder.Append(configString);
			}
		}

		private void PrintAppendEndTestLine()
		{
			PrintAndAppend("=========================================================================\n\n");
		}

		private void SaveTest()
		{
			using (var file = new StreamWriter(@"./resultat.txt"))
			{
				file.Write(stringBuilder.ToString());
			}
		}

		#endregion
	}
}