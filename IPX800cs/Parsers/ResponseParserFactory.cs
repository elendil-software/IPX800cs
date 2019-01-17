using System;
using software.elendil.IPX800.IO;
using software.elendil.IPX800.Parsers.v4.M2M;
using software.elendil.IPX800.Version;

namespace software.elendil.IPX800.Parsers
{
    public class ResponseParserFactory : IResponseParserFactory
    {
        public IInputResponseParser<InputState> GetInputParser(Context context, IPX800Input input)
        {
            if (context.Version == IPX800Version.V4)
            {
                if (input.Type == InputType.DigitalInput)
                {
                    if (input.IsVirtual)
                    {
                        return new VirtualInputResponseParser();
                    }
                    else
                    {
                        return new InputResponseParser();
                    }
                }
            }

            throw new Exception("Invalid context or input");
        }
    }
}