namespace IPX800cs.IO;

/// <summary>
/// Represent the state of an input
/// </summary>
/// <seealso cref="Input"/>
/// <seealso cref="InputResponse"/>
public enum InputState
{
	/// <summary>
	/// The input is inactive
	/// </summary>
	Inactive = 0,
	
	/// <summary>
	/// The input is active
	/// </summary>
	Active = 1
}