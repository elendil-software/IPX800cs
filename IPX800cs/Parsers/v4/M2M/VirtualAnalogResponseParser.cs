﻿namespace software.elendil.IPX800.Parsers.v4.M2M
{
    public class VirtualAnalogResponseParser : HeadedResponseParserBase, IAnalogInputResponseParser
    {
        public double ParseResponse(string ipxResponse, int inputNumber)
        {
            var result = ExtractValue(ipxResponse, inputNumber);
            return double.Parse(result);
        }

        protected override string BuildRegexPatternString(int inputOutputNumber)
        {
            //TODO remplacer la concaténation par une interpolation de chaine
            return "VA" + inputOutputNumber.ToString("D1") + "=([0-9\\.,]*)";
        }
    }
}