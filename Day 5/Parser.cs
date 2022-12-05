namespace Day_5;
class Parser
{
    public static string ParseTopCrates(string fileInput)
    {
        var stacksAndInstructions = GetStacksAndInstructions(fileInput);
        var stacks = stacksAndInstructions.Item1;
        var instructions = stacksAndInstructions.Item2;

        var movedStacks = MoveStacks(stacks, instructions);
        var topCrates = "";
        foreach(var stack in movedStacks)
        {
            topCrates += stack.Pop();
        }

        return topCrates;
    }

    public static string ParseOrderedCrates(string fileInput)
    {
        var stacksAndInstructions = GetStacksAndInstructions(fileInput);
        var stacks = stacksAndInstructions.Item1;
        var instructions = stacksAndInstructions.Item2;

        var movedStacks = MoveStacksInOrder(stacks, instructions);
        var topCrates = "";
        foreach(var stack in movedStacks)
        {
            topCrates += stack.Pop();
        }

        return topCrates;
    }

    private static Tuple<List<Stack<char>>, List<CraneInstruction>> GetStacksAndInstructions(string fileInput)
    {
        var diagram = GetDiagram(fileInput);
        var columnCount = GetColumns(diagram);
        var backwardsStacks = GetStacks(diagram, columnCount);
        var stacks = new List<Stack<char>>();

        foreach(var backwardsStack in backwardsStacks)
        {
            stacks.Add(ReverseStack(backwardsStack));
        }

        var instructions = GetInstructions(fileInput);

        return new Tuple<List<Stack<char>>, List<CraneInstruction>>(stacks, instructions);
    }

    private static List<string> GetDiagram(string fileInput)
    {
        using var reader = new StreamReader(fileInput);
        var diagram = new List<string>();
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            if (line == null || line == "") { break; }

            diagram.Add(line);
        }

        return diagram;
    }

    private static List<CraneInstruction> GetInstructions(string fileInput)
    {
        using var reader = new StreamReader(fileInput);
        var instructions = new List<CraneInstruction>();
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            if (line == null) { break; }
            if(!line.StartsWith("move")) { continue; }

            var instruction = new CraneInstruction(line);
            instructions.Add(instruction);
        }

        return instructions;
    }

    private static int GetColumns(List<string> diagram)
    {
        var columnsCount = "";
        foreach (var line in diagram)
        {
            // Get the number of columns in the diagram
            foreach(var charset in line.Replace(" ", "").ToCharArray())
            {
                if(Char.IsNumber(charset))
                {
                    columnsCount = line;
                    break;
                }
            }

            if(columnsCount != "")
            {
                var numbersString = columnsCount.Split(" ");
                var numbers = new List<int>();
                foreach(var number in numbersString.Where(x => x != ""))
                {
                    numbers.Add(int.Parse(number));
                }

                return numbers.Count;
            }
        }

        return 0;
    }

    private static List<Stack<char>> GetStacks(List<string> diagram, int columnCount)
    {
        var stacks = new List<Stack<char>>();
        for (var i = 0; i < columnCount; i++)
        {
            stacks.Add(new Stack<char>());
        }

        foreach (var line in diagram)
        {
            if(!line.Contains('[')){ continue; }
            var dataset = line.Replace(" ", ".").Replace("....",".").Replace("[", "").Replace("]", "").Split(".");
            var currentStack = 0;
            foreach(var columnValue in dataset)
            {
                if(columnValue == "")
                {
                    currentStack++;
                    continue;
                }

                stacks[currentStack].Push(char.Parse(columnValue));
                currentStack++;
            }
        }

        return stacks;
    }

    private static Stack<char> ReverseStack(Stack<char> input)
    {
        var output = new Stack<char>();
        while (input.Count > 0)
        {
            output.Push(input.Pop());
        }

        return output;
    }

    private static List<Stack<char>> MoveStacks(List<Stack<char>> stacks, List<CraneInstruction> instructions)
    {
        var movedStacks = new List<Stack<char>>();
        foreach(var stack in stacks)
        {
            movedStacks.Add(ReverseStack(new Stack<char>(stack)));
        }

        foreach(var inst in instructions)
        {
            // The instructions are 1-based, but the stacks are 0-based
            var fromStack = movedStacks[inst.From - 1];
            var toStack = movedStacks[inst.To - 1];
            var amount = inst.Amount;

            for(var i = 0; i < amount; i++)
            {
                toStack.Push(fromStack.Pop());
            }
        }

        return movedStacks;
    }

    private static List<Stack<char>> MoveStacksInOrder(List<Stack<char>> stacks, List<CraneInstruction> instructions)
    {
        var movedStacks = new List<Stack<char>>();
        foreach(var stack in stacks)
        {
            movedStacks.Add(ReverseStack(new Stack<char>(stack)));
        }

        foreach(var inst in instructions)
        {
            // The instructions are 1-based, but the stacks are 0-based
            var fromStack = movedStacks[inst.From - 1];
            var toStack = movedStacks[inst.To - 1];
            var amount = inst.Amount;

            var tempStack = new Stack<char>();
            for(var i = 0; i < amount; i++)
            {
                tempStack.Push(fromStack.Pop());
            }
            foreach(var elm in tempStack)
            {
                toStack.Push(elm);
            }
        }

        return movedStacks;
    }
}