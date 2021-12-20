using System;
using System.IO;

namespace TestConsoleApplication;

internal class LogFile
{
    private readonly string _outputFile;

    public LogFile(string configFileName)
    {
        _outputFile = $"result_{Path.GetFileNameWithoutExtension(configFileName)}_{DateTime.Now:yyyy-MM-dd hh-mm-ss}.txt";
    }

    public void Log(string str)
    {
        Console.WriteLine(str);
        using (StreamWriter sw = File.AppendText(_outputFile)) 
        {
            sw.WriteLine(str);
        }	
    }
        
    public void Log(Exception ex)
    {
        Log("ERROR");
        Log(".....\n");
        Log($"Exception type : {ex.GetType().Name}");
        Log($"Exception message : {ex.Message}");
        if (ex.InnerException != null)
        {
            Log($"\nInner exception type : {ex.InnerException.GetType().Name}");
            Log($"Inner exception message : {ex.InnerException.Message}");
        }

        Log("\nStackTrace :");
        Log(ex.StackTrace);
        Log(".....\n");
    }
        
    public void LogTitle(string title)
    {
        Log(title.ToUpper());
        Log($"{new String('-', title.Length)}\n");
    }

    public void LogEndLine()
    {
        Log($"{new String('=', 80)}\n");
    }
}