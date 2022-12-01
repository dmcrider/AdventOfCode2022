namespace Day_1;
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        // Parse the input into Objects we can work with
        var elves = Parser.Parse("input.txt");

        // Order By Descending to get the highest calorie count first
        var top1Calories = elves.OrderByDescending(e => e.TotalCalories).First();
        elves.Remove(top1Calories); // After we get the highest calorie count, remove it from the list
        var top2Calories = elves.OrderByDescending(e => e.TotalCalories).First();
        elves.Remove(top2Calories); // After we get the 2nd highest calorie count, remove it from the list
        var top3Calories = elves.OrderByDescending(e => e.TotalCalories).First();

        // Sum the total calories for the top 3
        var totalCalories = top1Calories.TotalCalories + top2Calories.TotalCalories + top3Calories.TotalCalories;

        // Print the results
        Console.WriteLine("Advent of Code 2022 - Day 1");
        Console.WriteLine("Solution by Daylon Crider");
        Console.WriteLine("https://adventofcode.com/2022/day/1");
        Console.WriteLine("===================================");
        Console.WriteLine($"Elf {top1Calories.Identifier} has the most calories with {top1Calories.TotalCalories}.");
        Console.WriteLine($"Elf {top2Calories.Identifier} has the 2nd most calories with {top2Calories.TotalCalories}.");
        Console.WriteLine($"Elf {top3Calories.Identifier} has the 3rd most calories with {top3Calories.TotalCalories}.");
        Console.WriteLine($"The total calories of the top 3 elves is {totalCalories}.");

        // Results for part 1 and part 2
        Console.WriteLine(Environment.NewLine);
        Console.WriteLine($"The solution to part 1 is {top1Calories.TotalCalories}.");
        Console.WriteLine($"The solution to part 2 is {totalCalories}.");
    }
}
