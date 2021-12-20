using System.Collections.Generic;

namespace TestConsoleApplication.Configuration;

public class RootConfig
{
    public IPX800Config IPX800Config { get; set; }
    public List<TestCase> TestCases { get; set; }
}