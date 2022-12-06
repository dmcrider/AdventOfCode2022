namespace Day_6;
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        var startOfPacket = Parser.Parse("input.txt");

        Console.WriteLine("Advent of Code 2022 - Day 6");
        Console.WriteLine("Solution by Daylon Crider");
        Console.WriteLine("https://adventofcode.com/2022/day/6");
        Console.WriteLine("===================================");
        Console.WriteLine("Start of Packet: " + startOfPacket);
    }
}
