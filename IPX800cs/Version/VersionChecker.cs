namespace software.elendil.IPX800.Version
{
    public static class VersionChecker
    {
        public static bool IsLegacy(System.Version version)
        {
            if (version == null)
            {
                return false;
            }

            var version30542 = new System.Version("3.05.42");
            return version.CompareTo(version30542) < 0;
        }
    }
}