namespace Day_2;

public class Part1Parser
{
    public static int Parse(string filePath)
    {
        var totalScore = 0;
        using var reader = new StreamReader(filePath);
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            if (line == null) { break; }

            // Daisy-chain the replacements
            var opponentMoveName = line.Split(' ')[0].Replace("A", "Rock").Replace("B", "Paper").Replace("C", "Scissors");
            var playerMoveName = line.Split(' ')[1].Replace("X", "Rock").Replace("Y", "Paper").Replace("Z", "Scissors");

            var opponentConvertSuccess = Enum.TryParse(opponentMoveName, out Move opponentMove);
            var playerConvertSuccess = Enum.TryParse(playerMoveName, out Move playerMove);

            if (opponentConvertSuccess && playerConvertSuccess)
            {
                var roundScore = Parser.RoundResult(playerMove, opponentMove);
                roundScore += (int)playerMove;

                totalScore += roundScore;
            }
        }

        return totalScore;
    }
}