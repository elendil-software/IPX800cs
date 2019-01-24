using System.Text.RegularExpressions;

namespace software.elendil.IPX800.Version
{
    public class VersionParser
    {
        public static System.Version Parse(string versionString)
        {
            versionString = new Regex(@"[A-Za-z= ]").Replace(versionString, "");
            return System.Version.Parse(versionString);
        } 
    }
}