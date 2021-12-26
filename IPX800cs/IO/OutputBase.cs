namespace IPX800cs.IO;

public abstract class OutputBase
{
    public OutputType Type { get; set; }
    public OutputState State { get; set; }
    public int Number { get; set; }
}