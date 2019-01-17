using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Parsers.v4.M2M
{
    public class InputResponseParser : HeadedResponseParserBase, IInputResponseParser<InputState>
    {
        public InputState ParseResponse(string ipxResponse, int inputNumber)
        {
            var result = ExtractValue(ipxResponse, inputNumber);
            return (InputState)System.Enum.Parse(typeof(InputState), result);
        }

        protected override string BuildRegexPatternString(int inputOutputNumber)
        {
            //TODO remplacer la concaténation par une interpolation de chaine
            return "D" + inputOutputNumber.ToString("D2") + "=([0-9\\.,]*)";
        }
    }
}