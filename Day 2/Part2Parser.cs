namespace Day_2;

class Part2Parser
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
            var playerMoveName = line.Split(' ')[1].Replace("X", "Lose").Replace("Y", "Draw").Replace("Z", "Win");

            var opponentConvertSuccess = Enum.TryParse(opponentMoveName, out Move opponentMove);

            if (opponentConvertSuccess)
            {
                var playerMove = ConvertOutcomeToMove(playerMoveName, opponentMove);
                var roundScore = Parser.RoundResult(playerMove, opponentMove);
                roundScore += (int)playerMove;

                totalScore += roundScore;
            }
        }

        return totalScore;
    }

    private static Move ConvertOutcomeToMove(string player, Move opponent)
    {
        if(player == "Win")
        {
            return opponent switch
            {
                Move.Rock => Move.Paper,
                Move.Paper => Move.Scissors,
                Move.Scissors => Move.Rock,
                _ => Move.Rock
            };
        }
        else if(player == "Lose")
        {
            return opponent switch
            {
                Move.Rock => Move.Scissors,
                Move.Paper => Move.Rock,
                Move.Scissors => Move.Paper,
                _ => Move.Rock
            };
        }
        else
        {
            return opponent;
        }
    }
}