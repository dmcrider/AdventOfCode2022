namespace Day_5;
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        var topCrates = Parser.ParseTopCrates("input.txt");

        Console.WriteLine("Advent of Code 2022 - Day 5");
        Console.WriteLine("Solution by Daylon Crider");
        Console.WriteLine("https://adventofcode.com/2022/day/5");
        Console.WriteLine("===================================");
        Console.WriteLine("Top crates from each stack: " + topCrates);
    }
}
