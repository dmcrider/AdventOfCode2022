namespace Day_3;
class Parser
{
    private static readonly char[] lower = new char[]{'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
    private static readonly char[] upper = new char[]{'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};

    public static int ParsePriorities(string filePath)
    {
        var sumOfPriorities = 0;
        using var reader = new StreamReader(filePath);
        while(!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            if(line == null) { break; }

            var compartment1 = line.Substring(0, line.Length / 2);
            var compartment2 = line.Substring(line.Length / 2);

            List<char> overlapping = new List<char>();
            foreach(var letter in compartment1)
            {
                if(compartment2.Contains(letter) && !overlapping.Contains(letter))
                {
                    overlapping.Add(letter);
                }
            }

            if(!overlapping.Any()) { return 0; }

            foreach(var letter in overlapping)
            {
                sumOfPriorities += GetLetterValue(letter);
            }
        }

        return sumOfPriorities;
    }

    public static int ParseBadges(string filePath)
    {
        var currentGroup = new List<string>();
        var badgePrioritiesTotal = 0;
        using var reader = new StreamReader(filePath);
        while(!reader.EndOfStream)
        {
            while(currentGroup.Count() < 3)
            {
                currentGroup.Add(reader.ReadLine() ?? "");
            }

            var first = currentGroup[0];
            var second = currentGroup[1];
            var third = currentGroup[2];

            var foundLetters = new List<char>();
            foreach(var letter in first)
            {
                if(second.Contains(letter) && third.Contains(letter) && !foundLetters.Contains(letter))
                {
                    foundLetters.Add(letter);
                    badgePrioritiesTotal += GetLetterValue(letter);
                }
            }
            currentGroup.Clear();
        }

        return badgePrioritiesTotal;
    }

    private static int GetLetterValue(char letter)
    {
        if(lower.Contains(letter))
        {
            return Array.IndexOf(lower,letter) + 1;
        }
        else if(upper.Contains(letter))
        {
            return Array.IndexOf(upper, letter) + 27;
        }

        return 0;
    }
}