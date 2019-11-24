using System.Collections.Generic;
using IPX800cs.Exceptions;
using IPX800cs.IO;

namespace IPX800cs.Contracts
{
    public interface IGetAllIO
    {
        /// <summary>
        /// Gets the state of all inputs
        /// </summary>
        /// <returns>The current inputs state</returns>
        /// <exception cref="IPX800SendCommandException">Thrown if it was unable to send the command or if an error occured while sending the command</exception>
        /// <exception cref="IPX800InvalidResponseException">Thrown if the command has been successfully sent but the response can not be parsed</exception>
        Dictionary<int, InputState> GetInputs();
		
        /// <summary>
        /// Gets the state of all outputs
        /// </summary>
        /// <returns>The current outputs state</returns>
        /// <exception cref="IPX800SendCommandException">Thrown if it was unable to send the command or if an error occured while sending the command</exception>
        /// <exception cref="IPX800InvalidResponseException">Thrown if the command has been successfully sent but the response can not be parsed</exception>
        Dictionary<int, OutputState> GetOutputs();
    }
}