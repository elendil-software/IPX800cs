﻿namespace software.elendil.IPX800.IO
{
    public class IPX800Output
    {
        public OutputType Type { get; set; }
        public OutputState State { get; set; }
        public int Number { get; set; }
        public bool IsVirtual { get; set; }
        public bool IsDelayed { get; set; }
    }
}