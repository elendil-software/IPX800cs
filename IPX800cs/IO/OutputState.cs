namespace IPX800cs.IO;

/// <summary>
/// Represent the state of an output
/// </summary>
/// <seealso cref="Output"/>
/// <seealso cref="OutputResponse"/>
public enum OutputState
{
	/// <summary>
	/// The output is inactive
	/// </summary>
	Inactive = 0,
	
	/// <summary>
	/// The output is active
	/// </summary>
	Active = 1,
	
	Unknown = 2
}