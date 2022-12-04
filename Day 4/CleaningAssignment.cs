namespace Day_4;
class CleaningAssignment
{
    public int StartingArea {get;set;}
    public int EndingArea {get;set;}
    public int[] Areas {get;set;}

    public CleaningAssignment(string rangeInput)
    {
        StartingArea = int.Parse(rangeInput.Split("-")[0]);
        EndingArea = int.Parse(rangeInput.Split("-")[1]);

        Areas = new int[EndingArea - StartingArea + 1];
        for(int i = 0; i < Areas.Length; i++)
        {
            Areas[i] = StartingArea + i;
        }
    }

    public bool IsContainedBy(CleaningAssignment other)
    {
        if(this.StartingArea >= other.StartingArea && this.StartingArea <= other.EndingArea)
        {
            if(this.EndingArea >= other.StartingArea && this.EndingArea <= other.EndingArea)
            {
                return true;
            }
        }

        return false;
    }

    public override string ToString()
    {
        return $"Areas: {String.Join(",",Areas)}";
    }
}