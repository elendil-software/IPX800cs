﻿using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v3.M2M
{
    public class IPX800v3GetInputM2MCommandBuilder : IGetInCommandBuilder
    {
        public string BuildCommandString(IPX800Input input)
        {
            return $"{IPX800v3M2MCommandStrings.GetDigitalInput}{input.Number}";
        }
    }
}