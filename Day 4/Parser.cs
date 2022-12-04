namespace Day_4;
class Parser
{
    public static int Parse(string filePath)
    {
        var overlaps = 0;
        using var reader = new StreamReader(filePath);
        while(!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            if(line == null) { break; }

            var elf1 = line.Split(",")[0];
            var elf2 = line.Split(",")[1];

            var elf1Assignment = new CleaningAssignment(elf1);
            var elf2Assignment = new CleaningAssignment(elf2);

            if(elf1Assignment.IsContainedBy(elf2Assignment) || elf2Assignment.IsContainedBy(elf1Assignment))
            {
                overlaps++;
            }
        }

        return overlaps;
    }
}