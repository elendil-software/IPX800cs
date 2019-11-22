using System.Collections.Generic;
using IPX800cs.Exceptions;
using IPX800cs.IO;

namespace IPX800cs.Contracts
{
    public interface   IIPX800v4 : IIPX800, IGetAllIO, IVirtualIO
    {
        /// <summary>
        /// Gets the state of all virtual inputs
        /// </summary>
        /// <returns>The current inputs state</returns>
        /// <exception cref="IPX800SendCommandException">Thrown if it was unable to send the command or if an error occured while sending the command</exception>
        /// <exception cref="IPX800InvalidResponseException">Thrown if the command has been successfully sent but the response can not be parsed</exception>
        Dictionary<int, InputState> GetVirtualInputs();
        
        /// <summary>
        /// Gets the state of all analog inputs
        /// </summary>
        /// <returns>The current inputs state</returns>
        /// <exception cref="IPX800SendCommandException">Thrown if it was unable to send the command or if an error occured while sending the command</exception>
        /// <exception cref="IPX800InvalidResponseException">Thrown if the command has been successfully sent but the response can not be parsed</exception>
        Dictionary<int, int> GetAnalogInputs();
        
        /// <summary>
        /// Gets the state of all virtual analog inputs
        /// </summary>
        /// <returns>The current inputs state</returns>
        /// <exception cref="IPX800SendCommandException">Thrown if it was unable to send the command or if an error occured while sending the command</exception>
        /// <exception cref="IPX800InvalidResponseException">Thrown if the command has been successfully sent but the response can not be parsed</exception>
        Dictionary<int, int> GetVirtualAnalogInputs();
		
        /// <summary>
        /// Gets the state of all virtual outputs
        /// </summary>
        /// <returns>The current outputs state</returns>
        /// <exception cref="IPX800SendCommandException">Thrown if it was unable to send the command or if an error occured while sending the command</exception>
        /// <exception cref="IPX800InvalidResponseException">Thrown if the command has been successfully sent but the response can not be parsed</exception>
        Dictionary<int, OutputState> GetVirtualOutputs();
    }
}