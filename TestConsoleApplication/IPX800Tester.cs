using System;
using System.IO;
using IPX800cs;
using Newtonsoft.Json;
using TestConsoleApplication.Configuration;
using TestConsoleApplication.TestExecutors;

namespace TestConsoleApplication
{
    internal class IPX800Tester
    {
        private readonly RootConfig _rootConfig;
        private readonly LogFile _logFile;
        private readonly SystemInfo _systemInfo;
        private readonly IPX800Initializer _ipx800Initializer;
        private IIPX800 _ipx800;
        private TestExecutorFactory _testExecutorFactory;

        public IPX800Tester(string configFile)
        {
            _logFile = new LogFile(configFile);
            _systemInfo = new SystemInfo(_logFile);
            _rootConfig = ReadConfig(configFile);
            _ipx800Initializer = new IPX800Initializer(_rootConfig.IPX800Config, _logFile);
        }
        
        private static RootConfig ReadConfig(string configFile)
        {
            string json = File.ReadAllText(configFile);
            return JsonConvert.DeserializeObject<RootConfig>(json);
        }

        public void Execute()
        {
            try
            {
                _systemInfo.LogSystemInfo();
                _ipx800 = _ipx800Initializer.InitIPX800();
                _testExecutorFactory = new TestExecutorFactory(_ipx800, _logFile);
                ExecuteTests();
            }
            catch (Exception ex)
            {
                _logFile.Log(ex);
            }
        }

        private void ExecuteTests()
        {
            _logFile.LogTitle("Tests Execution");
            
            foreach (TestCase testCase in _rootConfig.TestCases)
            {
                try {
                    _logFile.Log(testCase.Command);
                    _logFile.Log(new string('-', testCase.Command.Length));
                    _testExecutorFactory.Create(testCase).Execute();
                }
                catch (Exception ex)
                {
                    _logFile.Log(ex);
                }
            }
            
            _logFile.LogEndLine();
        }
    }
}