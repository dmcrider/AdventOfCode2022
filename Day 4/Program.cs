namespace Day_4;
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        var pairsContained = Parser.ParseContains("input.txt");
        var overlaps = Parser.ParseOverlaps("input.txt");

        Console.WriteLine("Advent of Code 2022 - Day 4");
        Console.WriteLine("Solution by Daylon Crider");
        Console.WriteLine("https://adventofcode.com/2022/day/4");
        Console.WriteLine("===================================");
        Console.WriteLine("Total pairs with cleaning assignment contained within the other: " + pairsContained);
        Console.WriteLine("Total pairs with cleaning assignment overlaps: " + overlaps);
    }
}
