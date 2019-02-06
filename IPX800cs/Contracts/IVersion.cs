namespace IPX800cs.Contracts
{
    public interface IVersion
    {
        /// <summary>
        /// Get the firmware version of the IPX800
        /// </summary>
        /// <returns>The firmware version</returns>
        System.Version GetVersion();
    }
}