using System.Text.RegularExpressions;

namespace IPX800cs.Version
{
    internal static class VersionParser
    {
        public static System.Version Parse(string versionString)
        {
            versionString = new Regex(@"[A-Za-z= ]").Replace(versionString, "");
            return System.Version.Parse(versionString);
        } 
    }
}