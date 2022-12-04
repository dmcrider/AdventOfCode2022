namespace Day_4;
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        var overlaps = Parser.Parse("input.txt");

        Console.WriteLine("Advent of Code 2022 - Day 3");
        Console.WriteLine("Solution by Daylon Crider");
        Console.WriteLine("https://adventofcode.com/2022/day/3");
        Console.WriteLine("===================================");
        Console.WriteLine("Total cleaning assignment overlaps: " + overlaps);
    }
}
