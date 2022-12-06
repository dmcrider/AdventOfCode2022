namespace Day_6;
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        var startOfPacket = Parser.Parse("input.txt", 4); // Start-of-packet is 4 characters long
        var message = Parser.Parse("input.txt", 14); // Message is 14 characters long

        Console.WriteLine("Advent of Code 2022 - Day 6");
        Console.WriteLine("Solution by Daylon Crider");
        Console.WriteLine("https://adventofcode.com/2022/day/6");
        Console.WriteLine("===================================");
        Console.WriteLine("Start-of-Packet index: " + startOfPacket);
        Console.WriteLine("Message index: " + message);
    }
}
