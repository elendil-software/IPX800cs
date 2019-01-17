﻿using software.elendil.IPX800.Exceptions;
using software.elendil.IPX800.IO;

namespace software.elendil.IPX800
{
    /// <summary>
    /// Contract providing methods to communicate with an IPX800 v4
    /// </summary>
    public interface IIPX800v4 : IIPX800
    {
        /// <summary>
        /// Gets the state of a virtual input
        /// </summary>
        /// <param name="inputNumber">The virtual input number.</param>
        /// <returns>The input state.</returns>
        /// <exception cref="IPX800Exception">Thrown if it was unable to  get a response</exception>
        /// <exception cref="IPX800ExecuteException">Thrown if it was unable to send the request or in case of timeout while waiting for response</exception>
        /// <exception cref="IPX800ConnectionException">Thrown if the connexion with the IPX800 failed</exception>
        InputState GetVirtualIn(uint inputNumber);
        
        /// <summary>
        /// Gets the state of a virtual output
        /// </summary>
        /// <param name="outputNumber">The virtual output number.</param>
        /// <returns>The output state.</returns>
        /// <exception cref="IPX800Exception">Thrown if it was unable to  get a response</exception>
        /// <exception cref="IPX800ExecuteException">Thrown if it was unable to send the request or in case of timeout while waiting for response</exception>
        /// <exception cref="IPX800ConnectionException">Thrown if the connexion with the IPX800 failed</exception>
        OutputState GetVirtualOut(uint outputNumber);
        
        /// <summary>
        /// Sets the state of a virtual output.
        /// </summary>
        /// <param name="outputNumber">The virtual output number.</param>
        /// <param name="state">The state.</param>
        /// <param name="fugitive">if set to <c>true</c>, the 'fugitive' mode will be used.</param>
        /// <returns><c>true</c> if successful, <c>false</c> otherwise.</returns>
        /// <exception cref="IPX800Exception">Thrown if it was unable to  get a response</exception>
        /// <exception cref="IPX800ExecuteException">Thrown if it was unable to send the request or in case of timeout while waiting for response</exception>
        /// <exception cref="IPX800ConnectionException">Thrown if the connexion with the IPX800 failed</exception>
        string SetVirtualOut(uint outputNumber, OutputState state, bool fugitive);
        
        /// <summary>
        /// Gets the value of a virtual analog input
        /// </summary>
        /// <param name="inputNumber">The virtual input number.</param>
        /// <returns>The value</returns>
        /// <exception cref="IPX800Exception">Thrown if it was unable to  get a response</exception>
        /// <exception cref="IPX800ExecuteException">Thrown if it was unable to send the request or in case of timeout while waiting for response</exception>
        /// <exception cref="IPX800ConnectionException">Thrown if the connexion with the IPX800 failed</exception>
        string GetVirtualAn(uint inputNumber);
    }
}