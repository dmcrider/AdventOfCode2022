namespace Day_2;
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        // Run the program
        var part1Score = Part1Parser.Parse("input.txt");
        var part2Score = Part2Parser.Parse("input.txt");

        // Print the results
        Console.WriteLine("Advent of Code 2022 - Day 2");
        Console.WriteLine("Solution by Daylon Crider");
        Console.WriteLine("https://adventofcode.com/2022/day/2");
        Console.WriteLine("===================================");
        // Output goes here
        Console.WriteLine("Part 1: Total Score = " + part1Score);
        Console.WriteLine("Part 2: Total Score = " + part2Score);
    }
}