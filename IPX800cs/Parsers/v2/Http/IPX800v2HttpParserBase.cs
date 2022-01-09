using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using IPX800cs.Exceptions;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v2.Http;

internal abstract class IPX800v2HttpParserBase
{
    protected int ParseValue(string ipxResponse, string element)
    {
        XDocument xmlDoc = XDocument.Parse(ipxResponse);
        string value = xmlDoc.Element("response").Elements(element).First().Value;
        return int.Parse(value);
    }
    
    protected IEnumerable<XElement> GetElements(string ipxResponse, string element)
    {
        XDocument xmlDoc = XDocument.Parse(ipxResponse);
        var elements = xmlDoc.Element("response").Elements().Where(e => e.Name.LocalName.StartsWith(element));
        return elements;
    }
    
    protected InputState ParseInputStateString(string stateString)
    {
        return stateString switch
        {
            "up" => InputState.Inactive,
            "dn" => InputState.Active,
            _ => throw new IPX800InvalidResponseException(stateString)
        };
    }
    
    /// <summary>
    /// The status.xml file from IPX800 v2 return the inputs in wrong order.
    /// - btn0 contains state for input 4
    /// - btn1 contains state for input 3
    /// - etc.
    /// </summary>
    /// <param name="inputNumber">Wanted input number, counting from 1 to 4</param>
    /// <returns>Input number in status.xml response</returns>
    protected int ConvertInputNumberToBtnIndex(int inputNumber)
    {
        return inputNumber switch
        {
            1 => 3,
            2 => 2,
            3 => 1,
            4 => 0,
            _ => throw new IPX800InvalidContextException($"{inputNumber} is not a valid input number")
        };
    }
    
    protected int ConvertBtnIndexToInputNumber(int inputNumber)
    {
        return inputNumber switch
        {
            3 => 1,
            2 => 2,
            1 => 3,
            0 => 4,
            _ => throw new IPX800InvalidContextException($"{inputNumber} is not a valid btn number")
        };
    }
}