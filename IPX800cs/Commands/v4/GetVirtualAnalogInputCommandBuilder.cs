namespace software.elendil.IPX800.Commands.v4.M2M
{
    public class GetVirtualAnalogInputCommandBuilder
    {
        protected string BuildCommandString(int inputNumber, bool isVirtual)
        {
            return "Get=VA";
        }
    }
}
