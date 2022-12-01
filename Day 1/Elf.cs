namespace Day_1;
class Elf
{
    // The Elves don't have names, we assign a number based on the order they are in the input file
    public int Identifier { get; set; }
    // The Elves have a backpack with any number of items in it
    public List<int> Backback { get; set; }
    // We can just call this instead of iterating through the backpack. Makes the code cleaner.
    public int TotalCalories
    {
        get
        {
            return Backback.Sum();
        }
    }

    public Elf(int identifier)
    {
        Identifier = identifier;
        Backback = new List<int>();
    }
}
