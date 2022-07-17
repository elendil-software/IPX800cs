using System.Net.Http;
#pragma warning disable CS1591

namespace IPX800cs.Commands;

public class Command
{
    private const string JsonContentType = "application/json";

    private Command(string queryString, HttpMethod method = null, string body = "", string contentType = "")
    {
        QueryString = queryString;
        Body = body;
        ContentType = contentType;
        Method = method;
    }

    public static Command CreateM2M(string command) => new(command);
    public static Command CreateGet(string command) => new(command, HttpMethod.Get);
    public static Command CreatePost(string command, string body) => new(command, HttpMethod.Post, body, JsonContentType);
    public static Command CreatePut(string command, string body) => new(command, HttpMethod.Put, body, JsonContentType);
    
    public string QueryString { get; }
    public string Body { get; }
    public string ContentType { get; }
    public HttpMethod Method  { get; }
}