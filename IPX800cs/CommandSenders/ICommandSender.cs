namespace software.elendil.IPX800.CommandSenders
{
	/// <summary>
	/// Interface ICommandSender. Provide method to send command to an IPX800
	/// </summary>
	public interface ICommandSender
	{
		/// <summary>
		/// Execute the given command
		/// </summary>
		/// <param name="command">the command to execute</param>
		/// <returns>the response to the executed</returns>
		/// <exception cref="software.elendil.IPX800.Exceptions.IPX800ExecuteException">Thrown if it was unable to send the request or in case of timeout while waiting for response</exception>
		object ExecuteCommand(string command);
	}
}