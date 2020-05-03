using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using Microsoft.Win32;

namespace TestConsoleApplication
{
    internal class SystemInfo
    {
        private readonly LogFile _logFile;

        public SystemInfo(LogFile logFile)
        {
            _logFile = logFile ?? throw new ArgumentNullException(nameof(logFile));
        }

        public void LogSystemInfo()
        {
            _logFile.LogTitle("System Info");
            LogWindowsVersion();
            LogDotNetVersions();
            LogCultureInfo();
            _logFile.LogEndLine();
        }

        private void LogWindowsVersion()
        {
            try
            {
                string productName = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName", "").ToString();
                string releaseId = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ReleaseId", "").ToString();

                _logFile.Log($"OS Version\n- {productName} {releaseId}\n");
            }
            catch (Exception ex)
            {
                _logFile.Log("Unable to find Windows version");
                _logFile.Log(ex);
            }
        }

        private void LogDotNetVersions()
        {
            try
            {
                StringBuilder strVersion = new StringBuilder();

                var proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "DotNetVersions/DotNetVersions.exe",
                        Arguments = "/b",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }

                };

                proc.Start();
                while (!proc.StandardOutput.EndOfStream)
                {
                    string line = proc.StandardOutput.ReadLine();
                    strVersion.Append("\n- ").Append(line).Append("; ");
                }


                _logFile.Log($".NET Framework Versions{strVersion.ToString()}\n");
            }
            catch (Exception ex)
            {
                _logFile.Log("Unable to find .NET Frameworks versions");
                _logFile.Log(ex);

            }
        }
        
        private void LogCultureInfo()
        {
            _logFile.Log($"Culture Info\n- {CultureInfo.CurrentCulture.Name}");
        }
    }
}