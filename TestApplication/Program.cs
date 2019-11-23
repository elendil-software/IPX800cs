using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using IPX800cs;
using IPX800cs.Contracts;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Version;
using Microsoft.Win32;

namespace TestApplication
{
	internal class Program
	{
		private static IIPX800 _ipx800M2M;
		private static IIPX800 _ipx800Http;
		private static string _ip;
		private static int _port;
		private static int _portHttp;
		private static string _user = "";
		private static string _pass = "";

		private static int _numOutput;
		private static int _numOutputFugitive;
		private static int _durationOutputFugitive;
		private static int _numInput;
		private static int _numAnInput;
		
		private static int _numVirtualOutput;
		private static int _numVirtualOutputFugitive;
		private static int _durationVirtualOutputFugitive;
		private static int _numVirtualInput;
		private static int _numVirtualAnInput;

		private readonly StringBuilder _stringBuilder = new StringBuilder();
		private readonly StringBuilder _configString = new StringBuilder();

		private static IPX800Version _ipx800Version;

		private static FileStream _fileStream;
		private static StreamWriter _streamWriter;
		private static readonly TextWriter OldOutput = Console.Out;
		

		/// <summary>
		/// This is a test application that can be useful to test the IPX800 C# lib against a specific IPX800 version or firmware version
		/// </summary>
		private static void Main()
		{
			var prog = new Program();

			try
			{
				_fileStream = new FileStream("./console.txt", FileMode.OpenOrCreate, FileAccess.Write);
				_streamWriter = new StreamWriter(_fileStream);
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

				prog.SetIPX800Instances();

			    if (_ipx800M2M != null)
				{
					prog.PrintAndAppend("Test IPX800 with M2M protocol");
					prog.PrintAndAppend("-------------------------------------------\n");

					prog.PrintAndAppend("Test Firmware Version");
					prog.PrintAndAppend("--------------------------");
					prog.TestGetVersion(_ipx800M2M);
					
					prog.PrintAndAppend("Read test");
					prog.PrintAndAppend("---------------");
					prog.TestRead(_ipx800M2M);
					prog.ResetOutputs(_ipx800M2M);
					Thread.Sleep(500);

					prog.PrintAndAppend("\nActivate/deactivate test");
					prog.PrintAndAppend("-------------------------------");
					prog.TestOutput(_ipx800M2M, _numOutput, _numVirtualOutput);
					prog.ResetOutputs(_ipx800M2M);
					Thread.Sleep(500);

					prog.PrintAndAppend("\nTest fugitive output");
					prog.PrintAndAppend("------------------------");
					prog.TestFugitiveOutput(_ipx800M2M);
					prog.ResetOutputs(_ipx800M2M);

					prog.PrintAppendEndTestLine();
					Thread.Sleep(500);
				}
				else
				{
					prog.PrintAndAppend("The M2M implementation is unknown is unknown, test skipped");
					prog.PrintAppendEndTestLine();
				}

				if (_ipx800Http != null)
				{
					prog.PrintAndAppend("Test IPX800 with HTTP protocol");
					prog.PrintAndAppend("--------------------------------------------\n");

					prog.PrintAndAppend("Test Firmware Version");
					prog.PrintAndAppend("--------------------------");
					prog.TestGetVersion(_ipx800Http);
					
					prog.PrintAndAppend("Read test");
					prog.PrintAndAppend("---------------");
					prog.TestRead(_ipx800Http);
					prog.ResetOutputs(_ipx800Http);
					Thread.Sleep(500);

					prog.PrintAndAppend("\nActivate/deactivate test");
					prog.PrintAndAppend("-------------------------------");
					prog.TestOutput(_ipx800Http, _numOutput, _numVirtualOutput);
					prog.ResetOutputs(_ipx800Http);
					Thread.Sleep(500);

					prog.PrintAndAppend("\nTest fugitive output");
					prog.PrintAndAppend("------------------------");
					prog.TestFugitiveOutput(_ipx800Http);
					prog.ResetOutputs(_ipx800Http);
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
				prog.PrintAndAppend($"An error occurred during the test : {e.Message}");
				prog.PrintAndAppend(e.StackTrace);
			}

			prog.SaveTest();

			Console.SetOut(OldOutput);
			_streamWriter.Close();
			_fileStream.Close();

			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("Press a key to close application...");
			Console.ReadKey();
		}

		#region Setup

		private static void SetDefaultSetup()
		{
			_ip = "192.168.1.130";
			_port = 9870;
			_portHttp = 80;
			_user = "";
		    _pass = "apikey";
			
			_numOutput = 1;
			_numOutputFugitive = 3;
			_durationOutputFugitive = 3;
			_numInput = 1;
			_numAnInput = 1;
			
			_numVirtualOutput = 3;
			_numVirtualOutputFugitive = 4;
			_durationVirtualOutputFugitive = 2;
			_numVirtualInput = 1;
			_numVirtualAnInput = 1;
			
			_ipx800Version = IPX800Version.V4;
		}

		private void Setup()
		{
			Console.WriteLine("Entrez la version de votre IPX800 (2, 3 or 4)\nEnter the version of your IPX800 (2, 3 or 4) : ");
			var numVersion = Console.ReadLine();
			switch (numVersion)
			{
				case "2":
					_ipx800Version = IPX800Version.V2;
					break;

				case "3":
					_ipx800Version = IPX800Version.V3;
					break;

				case "4":
					_ipx800Version = IPX800Version.V4;
					break;

				default:
					throw new IPX800UnknownVersionException($"This version of the IPX800 is not valid : {numVersion}");
			}

			Console.WriteLine("Entrez l'adresse IP de votre IPX\nEnter the IP of your IPX : ");
			_ip = Console.ReadLine();

			Console.WriteLine(
				"\nEntrez le numéro du port pour les commandes M2M (valeur par défaut : 9870)\nEnter the port number for M2M command (default 9870) : ");
			var portM2MRead = Console.ReadLine();
			if (portM2MRead == null || portM2MRead.Trim().Length == 0)
			{
				_port = 9870;
			}
			else
			{
				_port = Convert.ToInt32(portM2MRead);
			}

			Console.WriteLine(
				"\nEntrez le numéro du port pour les commandes HTTP (valeur par défaut : 80)\nEnter the port number for HTTP command (default 80) : ");
			var portRead = Console.ReadLine();
			if (portRead == null || portRead.Trim().Length == 0)
			{
				_portHttp = 80;
			}
			else
			{
				_portHttp = Convert.ToInt32(portRead);
			}

			Console.WriteLine(
				"\nEntrez le nom d'utilisateur (facultatif si non configuré ou si  IPX800 v4)\nEnter the username (optional if not configured or if IPX800 v4) : ");
			_user = Console.ReadLine();

			Console.WriteLine(
				"\nEntrez le mot de passe/clé (facultatif si non configuré)\nEnter the password/key (optional if not configured) : ");
			_pass = Console.ReadLine();

			Console.WriteLine("\nEntrez un numéro de sortie.\nEnter an output number : ");
			_numOutput = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine(
				"\nEntrez un numéro de sortie configuré en mode fugitif (impulsion).\nEnter an output number that is configured in fugitive mode : ");
			_numOutputFugitive = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine(
				"\nEntrez la durée d'impulsion, en secondes, configuré pour la sortie en mode fugitif\nEnter the impulsion duration (in seconds) of the output configured in fugitive mode : ");
			_durationOutputFugitive = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine("\nEntrez un numéro d'entrée numérique :\nEnter a digital input number : ");
			_numInput = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine("\nEntrez un numéro d'entrée analogique\nEnter an analog input number : ");
			_numAnInput = Convert.ToInt32(Console.ReadLine());

			if (_ipx800Version == IPX800Version.V4)
			{
				Console.WriteLine("\nEntrez un numéro de sortie virtuelle.\nEnter an output number : ");
				_numVirtualOutput = Convert.ToInt32(Console.ReadLine());

				Console.WriteLine(
					"\nEntrez un numéro de sortie virtuelle configuré en mode fugitif (impulsion).\nEnter an output number that is configured in fugitive mode : ");
				_numVirtualOutputFugitive = Convert.ToInt32(Console.ReadLine());

				Console.WriteLine(
					"\nEntrez la durée d'impulsion, en secondes, configuré pour la sortie virtuelle en mode fugitif\nEnter the impulsion duration (in seconds) of the output configured in fugitive mode : ");
				_durationVirtualOutputFugitive = Convert.ToInt32(Console.ReadLine());
				
				Console.WriteLine("\nEntrez un numéro d'entrée numérique virtuelle :\nEnter a digital virtual input number : ");
				_numVirtualInput = Convert.ToInt32(Console.ReadLine());
				
				Console.WriteLine("\nEntrez un numéro d'entrée analogique virtuelle\nEnter a virtual analog input number : ");
				_numVirtualAnInput = Convert.ToInt32(Console.ReadLine());
			}
		}

		#endregion

		private void TestFugitiveOutput(IIPX800 ipx800)
		{
			try
			{
				Console.SetOut(_streamWriter);
				var resSet = ipx800.SetDelayedOutput(_numOutputFugitive);
				Thread.Sleep(200);
				var resGet = ipx800.GetOutput(_numOutputFugitive);
				Console.SetOut(OldOutput);
				PrintAndAppend($"Activate output {_numOutputFugitive}, response : {resSet}, state : {resGet}");

				PrintAndAppend($"Wait for impulsion end ({_durationOutputFugitive} s)");
				Thread.Sleep(_durationOutputFugitive*1000 + 2000);

				Console.SetOut(_streamWriter);
				resGet = ipx800.GetOutput(_numOutputFugitive);
				Console.WriteLine("");
				Console.SetOut(OldOutput);
				PrintAndAppend($"Check output state : {resGet}");

				if (_ipx800Version == IPX800Version.V4)
				{
					Console.SetOut(_streamWriter);
					resSet = ((IIPX800v4)ipx800).SetDelayedVirtualOutput(_numVirtualOutputFugitive);
					Thread.Sleep(200);
					resGet = ((IIPX800v4)ipx800).GetVirtualOutput(_numVirtualOutputFugitive);
					Console.SetOut(OldOutput);
					PrintAndAppend($"Activate virtual output {_numVirtualOutputFugitive}, response : {resSet}, state : {resGet}");

					PrintAndAppend($"Wait for impulsion end ({_durationVirtualOutputFugitive} s)");
					Thread.Sleep(_durationOutputFugitive*1000 + 2000);

					Console.SetOut(_streamWriter);
					resGet = ((IIPX800v4)ipx800).GetVirtualOutput(_numVirtualOutputFugitive);
					Console.WriteLine("");
					Console.SetOut(OldOutput);
					PrintAndAppend($"Check virtual output state : {resGet}");
				}
			}
			catch (Exception e)
			{
				PrintAndAppend($"An error occurred during TestFugitiveOutput : {e.Message}");
				PrintAndAppend(e.StackTrace);
			}
		}

		private void TestOutput(IIPX800 ipx800, int num, int numVirtual)
		{
			try
			{
				Console.SetOut(_streamWriter);
				var resSet = ipx800.SetOutput(num, OutputState.Active);
				Thread.Sleep(200);
				var resGet = ipx800.GetOutput(num);
				Console.SetOut(OldOutput);
				PrintAndAppend($"Activate output {num}, response : {resSet}, state : {resGet}");

				Console.SetOut(_streamWriter);
				resSet = ipx800.SetOutput(num, OutputState.Inactive);
				Thread.Sleep(200);
				resGet = ipx800.GetOutput(num);
				Console.WriteLine("");
				Console.SetOut(OldOutput);
				PrintAndAppend($"Deactivate output {num}, response : {resSet}, state : {resGet}");

				if (_ipx800Version == IPX800Version.V4)
				{
					Console.SetOut(_streamWriter);
					resSet = ((IIPX800v4)ipx800).SetVirtualOutput(numVirtual, OutputState.Active);
					Thread.Sleep(200);
					resGet = ((IIPX800v4)ipx800).GetVirtualOutput(numVirtual);
					Console.SetOut(OldOutput);
					PrintAndAppend($"Activate virtual output {numVirtual}, response : {resSet}, state : {resGet}");

					Console.SetOut(_streamWriter);
					resSet = ((IIPX800v4)ipx800).SetVirtualOutput(numVirtual, OutputState.Inactive);
					Thread.Sleep(200);
					resGet = ((IIPX800v4)ipx800).GetVirtualOutput(numVirtual);
					Console.WriteLine("");
					Console.SetOut(OldOutput);
					PrintAndAppend($"Deactivate virtual output {numVirtual}, response : {resSet}, state : {resGet}");
				}
			}
			catch (Exception e)
			{
				PrintAndAppend($"An error occurred during TestOutput : {e.Message}");
				PrintAndAppend(e.StackTrace);
			}
		}

		private void TestRead(IIPX800 ipx800)
		{
			try
			{
				Console.SetOut(_streamWriter);
				var result = ipx800.GetOutput(_numOutput);
				Console.SetOut(OldOutput);
				PrintAndAppend($"Output {_numOutput} : {result}");
				Thread.Sleep(500);

				Console.SetOut(_streamWriter);
				var result2 = ipx800.GetInput(_numInput);
				Console.SetOut(OldOutput);
				PrintAndAppend($"Input (numeric) {_numInput} : {result2}");

                Thread.Sleep(500);

				Console.SetOut(_streamWriter);
				var result3 = ipx800.GetAnalogInput(_numAnInput);
				Console.WriteLine("");
				Console.SetOut(OldOutput);
				PrintAndAppend($"Input (analog) {_numAnInput} : {result3}");

				if (_ipx800Version == IPX800Version.V4)
				{
					Console.SetOut(_streamWriter);
					var result4 = ((IIPX800v4)ipx800).GetVirtualOutput(_numVirtualOutput);
					Console.SetOut(OldOutput);
					PrintAndAppend($"Virtual Output {_numVirtualOutput} : {result4}");
					Thread.Sleep(500);

					Console.SetOut(_streamWriter);
					var result5 = ((IIPX800v4)ipx800).GetVirtualInput(_numVirtualInput);
					Console.SetOut(OldOutput);
					PrintAndAppend($"Virtual Input (numeric) {_numVirtualInput} : {result5}");
					Thread.Sleep(500);

					Console.SetOut(_streamWriter);
					var result6 = ((IIPX800v4)ipx800).GetVirtualAnalogInput(_numVirtualAnInput);
					Console.WriteLine("");
					Console.SetOut(OldOutput);
					PrintAndAppend($"Virtual Input (analog) {_numVirtualAnInput} : {result6}");
				}

				if (_ipx800Version == IPX800Version.V3 || _ipx800Version == IPX800Version.V4)
				{
					Console.SetOut(_streamWriter);
					var result7 = ((IGetAllIO)ipx800).GetOutputs();
					Console.SetOut(OldOutput);
					PrintAndAppend($"Outputs : {result7}");
					Thread.Sleep(500);

					Console.SetOut(_streamWriter);
					var result8 = ((IGetAllIO)ipx800).GetInputs();
					Console.SetOut(OldOutput);
					PrintAndAppend($"Inputs : {result8}");
				}
			}
			catch (Exception e)
			{
				PrintAndAppend($"An error occurred during TestRead : {e.Message}");
				PrintAndAppend(e.StackTrace);
			}
		}

		private void TestGetVersion(IIPX800 ipx800)
		{
			IVersion ipx800WithGetVersion = ipx800 as IVersion;

			if (ipx800WithGetVersion != null)
			{
				try
				{
					Version version = ipx800WithGetVersion.GetVersion();
					PrintAndAppend($"IPX800 firmware version : {(version == null ? "UNKNOWN VERSION" : version.ToString())}");
				}
				catch (Exception e)
				{
					PrintAndAppend($"Unable to check version (Test M2M) : {e.Message}");
					PrintAndAppend(e.StackTrace);
				}
			}
			else
			{
				PrintAndAppend("GetVersion is not supported by this IPX800 version");
			}
			
			PrintAppendEndTestLine();
		}

		private void SetIPX800Instances()
		{
			try {
				PrintAndAppend("Set IPX800 instances");
				PrintAndAppend("--------------------------------------------------------------");
				
				switch (_ipx800Version)
				{
					case IPX800Version.V2:
						_ipx800Http = IPX800Factory.GetIPX800v2Instance(_ip, _portHttp, IPX800Protocol.Http, _user, _pass);
						_ipx800M2M = IPX800Factory.GetIPX800v2Instance(_ip, _port, IPX800Protocol.M2M, _user, _pass);
						break;

					case IPX800Version.V3:
						_ipx800Http = IPX800Factory.GetIPX800v3Instance(_ip, _portHttp, IPX800Protocol.Http, _user, _pass);
						_ipx800M2M = IPX800Factory.GetIPX800v3Instance(_ip, _port, IPX800Protocol.M2M, _user, _pass);
						break;

					case IPX800Version.V4:
						_ipx800Http = IPX800Factory.GetIPX800v4Instance(_ip, _portHttp, IPX800Protocol.Http, _user, _pass);
						_ipx800M2M = IPX800Factory.GetIPX800v4Instance(_ip, _port, IPX800Protocol.M2M, _user, _pass);
						break;
				}
				
				PrintAndAppend();
				PrintAndAppend($"implementation class M2M  : {(_ipx800M2M?.GetType().ToString() ?? " ? ")}");
				PrintAndAppend($"implementation class HTTP : {(_ipx800Http?.GetType().ToString() ?? " ? ")}");
			}
			catch (Exception e)
			{
				PrintAndAppend($"ERROR, {e.Message}");
				PrintAndAppend(e.StackTrace);
			}

			PrintAppendEndTestLine();
		}

		private void ResetOutputs(IIPX800 ipx800)
		{
			try
			{
				ipx800.SetOutput(_numOutput, OutputState.Inactive);
				Thread.Sleep(200);
				if (ipx800.GetOutput(_numOutput) == OutputState.Active)
				{
					PrintAndAppend("Output was not deactivated");
				}

				ipx800.SetOutput(_numOutputFugitive, OutputState.Inactive);
				Thread.Sleep(200);
				if (ipx800.GetOutput(_numOutputFugitive) == OutputState.Active)
				{
					PrintAndAppend("Fugitive output was not deactivated");
				}

			    if (_ipx800Version == IPX800Version.V4)
			    {
                    ((IIPX800v4)ipx800).SetVirtualOutput(_numVirtualOutput, OutputState.Inactive);
                    Thread.Sleep(200);
                    if (((IIPX800v4)ipx800).GetOutput(_numVirtualOutput) == OutputState.Active)
                    {
                        PrintAndAppend("Virtual output was not deactivated");
                    }

                    ((IIPX800v4)ipx800).SetVirtualOutput(_numVirtualOutputFugitive, OutputState.Inactive);
                    Thread.Sleep(200);
                    if (((IIPX800v4)ipx800).GetOutput(_numVirtualOutputFugitive) == OutputState.Active)
                    {
                        PrintAndAppend("Virtual fugitive output was not deactivated");
                    }
                }
			}
			catch (Exception e)
			{
				PrintAndAppend($"An error occurred during ResetOutputs : {e.Message}");
				PrintAndAppend(e.StackTrace);
			}
		}

		#region print/append/save

		private void PrintAndAppend(string str = "")
		{
			Console.WriteLine(str);
			_stringBuilder.AppendLine(str);
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
			_configString.AppendLine("");
			_configString.AppendLine("=========================================================================");
			_configString.AppendLine($"OS Version			: {Environment.OSVersion}");
			_configString.AppendLine($".NET Versions			: {DotNetVersion()}");
			_configString.AppendLine($"Culture Info			: {CultureInfo.CurrentCulture.Name}");
			_configString.AppendLine($"IPX800 version		: {_ipx800Version}");
			_configString.AppendLine($"IP				: {_ip}");
			_configString.AppendLine($"Port M2M			: {_port}");
			_configString.AppendLine($"Port HTTP			: {_portHttp}");
			_configString.AppendLine("user				: *****");
			_configString.AppendLine("pass				: *****");
			_configString.AppendLine($"numOutput			: {_numOutput}");
			_configString.AppendLine($"numOutputFugitive		: {_numOutputFugitive}");
			_configString.AppendLine($"durationOutputFugitive		: {_durationOutputFugitive}");
			_configString.AppendLine($"numInput			: {_numInput}");
			_configString.AppendLine($"numAnInput			: {_numAnInput}");
			_configString.AppendLine("=========================================================================");
			_configString.AppendLine("");

			Console.WriteLine(_configString.ToString());

			if (append)
			{
				_stringBuilder.Append(_configString);
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
				file.Write(_stringBuilder.ToString());
			}
		}

		#endregion
	}
}