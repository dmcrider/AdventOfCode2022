namespace Day_4;
class Parser
{
    public static int ParseContains(string filePath)
    {
        var contains = 0;
        var assignments = GetAllAssignments(filePath);
        foreach(var pair in assignments)
        {
            var elf1 = pair[0];
            var elf2 = pair[1];
            if(elf1.IsContainedBy(elf2) || elf2.IsContainedBy(elf1))
            {
                contains++;
            }
        }
        return contains;
    }

    public static int ParseOverlaps(string filePath)
    {
        var overlaps = 0;
        var assignments = GetAllAssignments(filePath);
        foreach(var pair in assignments)
        {
            var elf1 = pair[0];
            var elf2 = pair[1];

            if(elf1.Areas.Any(x => elf2.Areas.Contains(x)))
            {
                overlaps++;
            }
        }

        return overlaps;
    }

    private static List<List<CleaningAssignment>> GetAllAssignments(string filePath)
    {
        var retval = new List<List<CleaningAssignment>>();
        using var reader = new StreamReader(filePath);
        while(!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            if(line == null){ break; }

            var elf1 = line.Split(",")[0];
            var elf2 = line.Split(",")[1];

            var pair = new List<CleaningAssignment>();
            pair.Add(new CleaningAssignment(elf1));
            pair.Add(new CleaningAssignment(elf2));

            retval.Add(pair);
        }

        return retval;
    }
}