namespace Day_1;
class Parser
{
    /// <summary>Parse a file into a list of Elves.</summary>
    /// <param name="filePath">The path to the file to parse.</param>
    /// <returns>A list of Elves with filled backpacks.</returns>
    public static List<Elf> Parse(string filePath)
    {
        // Initialize the list of Elves
        var elves = new List<Elf>();
        // Read the input file - we assume it exists
        using(var reader = new StreamReader(filePath))
        {
            // Loop through each line until we reach the end of the file
            while(!reader.EndOfStream)
            {
                // Move to the next line
                var line = reader.ReadLine();
                // Create a new Elf
                var elf = new Elf(elves.Count + 1);
                // The Elves are separated by a blank line, so read through the file until we hit a blank line
                while(line != null && line.Length > 0)
                {
                    // Add each line to the Elf's backpack
                    elf.Backback.Add(int.Parse(line));
                    // Move to the next line
                    line = reader.ReadLine();
                }
                // Add the Elf to the list of Elves
                elves.Add(elf);
            }
        }
        return elves;
    }
}
