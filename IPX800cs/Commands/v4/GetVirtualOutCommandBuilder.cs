namespace software.elendil.IPX800.Commands.v4.M2M
{
    public class GetVirtualOutCommandBuilder
    {
        protected string BuildCommandString(int inputNumber, bool isVirtual)
        {
            return "Get=VO";
        }
    }
}
