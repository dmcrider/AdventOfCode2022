namespace Day_3;
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        var sumOfPriorities = Parser.Parse("input.txt");

        Console.WriteLine("Advent of Code 2022 - Day 3");
        Console.WriteLine("Solution by Daylon Crider");
        Console.WriteLine("https://adventofcode.com/2022/day/3");
        Console.WriteLine("===================================");
        Console.WriteLine("Sum of overlapping item priorities: " + sumOfPriorities);
    }
}
