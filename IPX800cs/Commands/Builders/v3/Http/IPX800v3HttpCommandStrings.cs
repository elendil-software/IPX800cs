namespace IPX800cs.Commands.Builders.v3.Http
{
    internal static class IPX800v3HttpCommandStrings
    {
        public const string HttpJsonBaseRequest = "api/xdevices.json?";
        public const string GetVersion = "globalstatus.xml";
        public const string SetOutput = "preset.htm?set";
        public const string SetOutputDelayed = "leds.cgi?led";
        public const string GetOutput = "cmd=20";
        public const string GetOutputs = "cmd=20";
        public const string GetDigitalInput = "cmd=10";
        public const string GetDigitalInputs = "cmd=10";
        public const string GetAnalogInput = "cmd=30";
    }
}