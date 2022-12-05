namespace Day_5;
class CraneInstruction
{
    public int From { get; set; }
    public int To { get; set; }
    public int Amount { get; set; }

    public CraneInstruction(string instruction)
    {
        // Instructions are in the form of:
        // [0]   [1]   [2]  [3] [4] [5]
        // move AMOUNT from FROM to TO
        var instructionParts = instruction.Split(" ");
        Amount = int.Parse(instructionParts[1]);
        From = int.Parse(instructionParts[3]);
        To = int.Parse(instructionParts[5]);
    }

    public override string ToString()
    {
        return "Move " + Amount + " from " + From + " to " + To;
    }
}