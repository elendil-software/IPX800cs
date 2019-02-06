namespace IPX800cs.Parsers.v4.M2M
{
    internal class IPX800v4GetVirtualAnalogInputM2MResponseParser : ResponseParserBase, IAnalogInputResponseParser
    {
        public int ParseResponse(string ipxResponse, int inputNumber)
        {
            string result = ExtractValue(ipxResponse, inputNumber);

            if (int.TryParse(result, out int value))
            {
                return value;
            }
            else
            {
                var splitResult = result.Split('=');
                return int.Parse(splitResult[1]);
            }
        }
    }
}