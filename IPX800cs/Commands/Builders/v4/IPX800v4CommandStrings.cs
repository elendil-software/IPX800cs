namespace IPX800cs.Commands.Builders.v4;

internal static class IPX800v4CommandStrings
{
    public const string HttpBaseRequest = "/api/xdevices.json?";
    public const string SetVirtualOutputInactive = "ClearVO=";
    public const string SetVirtualOutputActive = "SetVO=";
    public const string SetOutputActive = "SetR=";
    public const string SetOutputInactive = "ClearR=";
    public const string GetVirtualOutput = "Get=VO";
    public const string GetVirtualInput = "Get=VI";
    public const string GetVirtualAnalogInput = "Get=VA";
    public const string GetOutput = "Get=R";
    public const string GetDigitalInput = "Get=D";
    public const string GetAnalogInput = "Get=A";
}