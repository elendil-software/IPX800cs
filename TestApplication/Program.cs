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
		
		private static uint numVirtualOutput;
		private static uint numVirtualOutputFugitive;
		private static int durationVirtualOutputFugitive;
		private static uint numVirtualInput;
		private static uint numVirtualAnInput;

		private static Version version;
		private static Version versionHttp;

		private readonly StringBuilder stringBuilder = new StringBuilder();
		private readonly StringBuilder configString = new StringBuilder();

		private static IPX800Version ipx800Version;

		private static FileStream fileStream;
		private static StreamWriter streamWriter;
		private static readonly TextWriter OldOutput = Console.Out;
		

		/// <summary>
		/// This is a test application that can be useful to test the IPX800 C# lib against a specific IPX800 version or firmware version
		/// </summary>
		private static void Main()
		{
			var prog = new Program();

			try
			{
				fileStream = new FileStream("./console.txt", FileMode.OpenOrCreate, FileAccess.Write);
				streamWriter = new StreamWriter(fileStream);
			}
			catch (Exception e)
			{
				Console.WriteLine("Cannot open console.txt for writing");
				Console.WriteLine(e.Message);
				return;
			}

			try
			{
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
					prog.TestOutput(ipx800M2M, numOutput, numVirtualOutput);
					prog.ResetOutputs(ipx800M2M);
					Thread.Sleep(500);

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
					prog.TestOutput(ipx800Http, numOutput, numVirtualOutput);
					prog.ResetOutputs(ipx800Http);
					Thread.Sleep(500);

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

			Console.SetOut(OldOutput);
			streamWriter.Close();
			fileStream.Close();

			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("Press a key to close application...");
			Console.ReadKey();
		}

		#region Setup

		private static void SetDefaultSetup()
		{
			ip = "192.168.1.130";
			port = 9870;
			portHttp = 80;
			user = "";
		    pass = "apikey";
			
			numOutput = 1;
			numOutputFugitive = 3;
			durationOutputFugitive = 3;
			numInput = 1;
			numAnInput = 1;
			
			numVirtualOutput = 3;
			numVirtualOutputFugitive = 4;
			durationVirtualOutputFugitive = 2;
			numVirtualInput = 1;
			numVirtualAnInput = 1;
			
			ipx800Version = IPX800Version.V4;
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

			if (ipx800Version == IPX800Version.V4)
			{
				Console.WriteLine("\nEntrez un numéro de sortie virtuelle.\nEnter an output number : ");
				numVirtualOutput = Convert.ToUInt16(Console.ReadLine());

				Console.WriteLine(
					"\nEntrez un numéro de sortie virtuelle configuré en mode fugitif (impulsion).\nEnter an output number that is configured in fugitive mode : ");
				numVirtualOutputFugitive = Convert.ToUInt16(Console.ReadLine());

				Console.WriteLine(
					"\nEntrez la durée d'impulsion, en secondes, configuré pour la sortie virtuelle en mode fugitif\nEnter the impulsion duration (in seconds) of the output configured in fugitive mode : ");
				durationVirtualOutputFugitive = Convert.ToUInt16(Console.ReadLine());
				
				Console.WriteLine("\nEntrez un numéro d'entrée numérique virtuelle :\nEnter a digital virtual input number : ");
				numVirtualInput = Convert.ToUInt16(Console.ReadLine());
				
				Console.WriteLine("\nEntrez un numéro d'entrée analogique virtuelle\nEnter a virtual analog input number : ");
				numVirtualAnInput = Convert.ToUInt16(Console.ReadLine());
			}
		}

		#endregion

		private void TestFugitiveOutput(IIPX800 ipx800)
		{
			try
			{
				Console.SetOut(streamWriter);
				var resSet = ipx800.SetOut(numOutputFugitive, OutputState.Active, true);
				Thread.Sleep(200);
				var resGet = ipx800.GetOut(numOutputFugitive);
				Console.SetOut(OldOutput);
				PrintAndAppend("Activate output " + numOutputFugitive + ", response : " + resSet.Trim() + ", state : " + resGet);

				PrintAndAppend("Wait for impulsion end (" + durationOutputFugitive + "s)");
				Thread.Sleep(durationOutputFugitive*1000 + 2000);

				Console.SetOut(streamWriter);
				resGet = ipx800.GetOut(numOutputFugitive);
				Console.WriteLine("");
				Console.SetOut(OldOutput);
				PrintAndAppend("Check output state : " + resGet);

				if (ipx800Version == IPX800Version.V4)
				{
					Console.SetOut(streamWriter);
					resSet = ((IIPX800v4)ipx800).SetVirtualOut(numVirtualOutputFugitive, OutputState.Active, true);
					Thread.Sleep(200);
					resGet = ((IIPX800v4)ipx800).GetVirtualOut(numVirtualOutputFugitive);
					Console.SetOut(OldOutput);
					PrintAndAppend("Activate virtual output " + numVirtualOutputFugitive + ", response : " + resSet.Trim() + ", state : " + resGet);

					PrintAndAppend("Wait for impulsion end (" + durationVirtualOutputFugitive + "s)");
					Thread.Sleep(durationOutputFugitive*1000 + 2000);

					Console.SetOut(streamWriter);
					resGet = ((IIPX800v4)ipx800).GetVirtualOut(numVirtualOutputFugitive);
					Console.WriteLine("");
					Console.SetOut(OldOutput);
					PrintAndAppend("Check virtual output state : " + resGet);
				}
			}
			catch (Exception e)
			{
				PrintAndAppend("An error occurred during TestFugitiveOutput : " + e.Message);
				PrintAndAppend(e.StackTrace);
			}
		}

		private void TestOutput(IIPX800 ipx800, uint num, uint numVirtual)
		{
			try
			{
				Console.SetOut(streamWriter);
				var resSet = ipx800.SetOut(num, OutputState.Active, false);
				Thread.Sleep(200);
				var resGet = ipx800.GetOut(num);
				Console.SetOut(OldOutput);
				PrintAndAppend("Activate output " + num + ", response : " + resSet.Trim() + ", state : " + resGet);

				Console.SetOut(streamWriter);
				resSet = ipx800.SetOut(num, OutputState.Inactive, false);
				Thread.Sleep(200);
				resGet = ipx800.GetOut(num);
				Console.WriteLine("");
				Console.SetOut(OldOutput);
				PrintAndAppend("Deactivate output " + num + ", response : " + resSet.Trim() + ", state : " + resGet);

				if (ipx800Version == IPX800Version.V4)
				{
					Console.SetOut(streamWriter);
					resSet = ((IIPX800v4)ipx800).SetVirtualOut(numVirtual, OutputState.Active, false);
					Thread.Sleep(200);
					resGet = ((IIPX800v4)ipx800).GetVirtualOut(numVirtual);
					Console.SetOut(OldOutput);
					PrintAndAppend("Activate virtual output " + numVirtual + ", response : " + resSet.Trim() + ", state : " + resGet);

					Console.SetOut(streamWriter);
					resSet = ((IIPX800v4)ipx800).SetVirtualOut(numVirtual, OutputState.Inactive, false);
					Thread.Sleep(200);
					resGet = ((IIPX800v4)ipx800).GetVirtualOut(numVirtual);
					Console.WriteLine("");
					Console.SetOut(OldOutput);
					PrintAndAppend("Deactivate virtual output " + numVirtual + ", response : " + resSet.Trim() + ", state : " + resGet);
				}
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
				Console.SetOut(streamWriter);
				var result = ipx800.GetOut(numOutput);
				Console.SetOut(OldOutput);
				PrintAndAppend("Output " + numOutput + " : " + result);
				Thread.Sleep(500);

				Console.SetOut(streamWriter);
				var result2 = ipx800.GetIn(numInput);
				Console.SetOut(OldOutput);
				PrintAndAppend("Input (numeric) " + numInput + " : " + result2);
				Thread.Sleep(500);

				Console.SetOut(streamWriter);
				var result3 = ipx800.GetAn(numAnInput);
				Console.WriteLine("");
				Console.SetOut(OldOutput);
				PrintAndAppend("Input (analog) " + numAnInput + " : " + result3);

				if (ipx800Version == IPX800Version.V4)
				{
					Console.SetOut(streamWriter);
					var result4 = ((IIPX800v4)ipx800).GetVirtualOut(numVirtualOutput);
					Console.SetOut(OldOutput);
					PrintAndAppend("Virtual Output " + numVirtualOutput + " : " + result4);
					Thread.Sleep(500);

					Console.SetOut(streamWriter);
					var result5 = ((IIPX800v4)ipx800).GetVirtualIn(numVirtualInput);
					Console.SetOut(OldOutput);
					PrintAndAppend("Virtual Input (numeric) " + numVirtualInput + " : " + result5);
					Thread.Sleep(500);

					Console.SetOut(streamWriter);
					var result6 = ((IIPX800v4)ipx800).GetVirtualAn(numVirtualAnInput);
					Console.WriteLine("");
					Console.SetOut(OldOutput);
					PrintAndAppend("Virtual Input (analog) " + numVirtualAnInput + " : " + result6);
				}
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
				ipx800Http = IPX800HttpFactory.GetInstance(ip, portHttp, ipx800Version, user, pass);
				PrintAndAppend("IPX800HttpFactory.GetInstance : OK");
			}
			catch (Exception e)
			{
				PrintAndAppend("IPX800HttpFactory.GetInstance : ERROR, " + e.Message);
				PrintAndAppend(e.StackTrace);
			}

			PrintAndAppend();
			PrintAndAppend("implementation class M2M  : " + (ipx800M2M?.GetType().ToString() ?? "?"));
			PrintAndAppend("implementation class HTTP : " + (ipx800Http?.GetType().ToString() ?? "?"));

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

			    if (ipx800Version == IPX800Version.V4)
			    {
                    ((IIPX800v4)ipx800).SetVirtualOut(numVirtualOutput, OutputState.Inactive, false);
                    Thread.Sleep(200);
                    if (((IIPX800v4)ipx800).GetOut(numVirtualOutput) == OutputState.Active)
                    {
                        PrintAndAppend("Virtual output was not deactivated");
                    }

                    ((IIPX800v4)ipx800).SetVirtualOut(numVirtualOutputFugitive, OutputState.Inactive, false);
                    Thread.Sleep(200);
                    if (((IIPX800v4)ipx800).GetOut(numVirtualOutputFugitive) == OutputState.Active)
                    {
                        PrintAndAppend("Virtual fugitive output was not deactivated");
                    }
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