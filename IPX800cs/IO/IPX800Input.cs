﻿namespace software.elendil.IPX800.IO
{
    public class IPX800Input
    {
        public InputType Type { get; set; }
        public InputState State { get; set; }
        public int Number { get; set; }
        public bool IsVirtual { get; set; }
    }
}