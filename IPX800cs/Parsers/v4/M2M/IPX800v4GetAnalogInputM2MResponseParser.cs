namespace software.elendil.IPX800.Parsers.v4.M2M
{
    internal class IPX800v4GetAnalogInputM2MResponseParser : ResponseParserBase, IAnalogInputResponseParser
    {
        public double ParseResponse(string ipxResponse, int inputNumber)
        {
            string result = ExtractValue(ipxResponse, inputNumber);

            if (int.TryParse(result, out int value))
            {
                return value;
            }
            else
            {
                var splitResult = result.Split('=');
                return double.Parse(splitResult[1]);
            }
        }
    }
}