﻿using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v4.M2M
{
    public class IPX800v4GetVirtualAnalogInputM2MCommandBuilder : IGetInCommandBuilder
    {
        public string BuildCommandString(IPX800Input input)
        {
            return IPX800v4CommandStrings.GetVirtualAnalogInput;
        }
    }
}