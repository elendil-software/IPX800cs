using IPX800cs.IO;

namespace IPX800cs.Parsers.v5;

public class IPX800V5GetOptoInputsResponseParser : IPX800V5GetInputsResponseParser
{
    public IPX800V5GetOptoInputsResponseParser()
    {
        MinId = 65560;
        MaxId = 65563;
        InputType = InputType.OptoInput;
    }
}