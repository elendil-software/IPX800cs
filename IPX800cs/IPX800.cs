using System;
using software.elendil.IPX800.Enum;
using software.elendil.IPX800.IO;

namespace software.elendil.IPX800
{
    public class IPX800 : IIPX800v4
    {
        private IPX800Version _version;
        private Version firmwareVersion;
        private IPX800Protocol _protocol;

        public InputState GetIn(uint inputNumber)
        {
            throw new NotImplementedException();
        }

        public OutputState GetOut(uint outputNumber)
        {
            throw new NotImplementedException();
        }

        public string SetOut(uint outputNumber, OutputState state, bool fugitive)
        {
            throw new NotImplementedException();
        }

        public string GetAn(uint inputNumber)
        {
            throw new NotImplementedException();
        }

        public InputState GetVirtualIn(uint inputNumber)
        {
            throw new NotImplementedException();
        }

        public OutputState GetVirtualOut(uint outputNumber)
        {
            throw new NotImplementedException();
        }

        public string SetVirtualOut(uint outputNumber, OutputState state, bool fugitive)
        {
            throw new NotImplementedException();
        }

        public string GetVirtualAn(uint inputNumber)
        {
            throw new NotImplementedException();
        }
    }
}