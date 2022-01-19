using System.Net.Http;
using IPX800cs.Commands;
using Xunit;

namespace IPX800cs.Test.Commands;

public class CommandTest
{
    private const string JsonContentType = "application/json";
    
    [Fact]
    public void CreateM2MTest()
    {
        var command = Command.CreateM2M("command");
        
        Assert.Equal("command", command.QueryString);
        Assert.Equal("", command.Body);
        Assert.Equal("", command.ContentType);
        Assert.Null(command.Method);
    }
    
    [Fact]
    public void CreateGetTest()
    {
        var command = Command.CreateGet("command");
        
        Assert.Equal("command", command.QueryString);
        Assert.Equal("", command.Body);
        Assert.Equal("", command.ContentType);
        Assert.Equal(HttpMethod.Get, command.Method);
    }
    
    [Fact]
    public void CreatePostTest()
    {
        var command = Command.CreatePost("command", "{\"json\": \"object\"}");
        
        Assert.Equal("command", command.QueryString);
        Assert.Equal("{\"json\": \"object\"}", command.Body);
        Assert.Equal(JsonContentType, command.ContentType);
        Assert.Equal(HttpMethod.Post, command.Method);
    }
    
    [Fact]
    public void CreatePutTest()
    {
        var command = Command.CreatePut("command", "{\"json\": \"object\"}");
        
        Assert.Equal("command", command.QueryString);
        Assert.Equal("{\"json\": \"object\"}", command.Body);
        Assert.Equal(JsonContentType, command.ContentType);
        Assert.Equal(HttpMethod.Put, command.Method);
    }
}