namespace Day_2;

class Parser
{
    public static int RoundResult(Move player, Move opponent)
    {
        Move[] wins;
        Move[] loses;
        Move[] ties;

        switch(player)
        {
            case Move.Rock:
                wins = new[] { Move.Scissors };
                loses = new[] { Move.Paper };
                ties = new[] { Move.Rock };
                break;
            case Move.Paper:
                wins = new[] { Move.Rock };
                loses = new[] { Move.Scissors };
                ties = new[] { Move.Paper };
                break;
            case Move.Scissors:
                wins = new[] { Move.Paper };
                loses = new[] { Move.Rock };
                ties = new[] { Move.Scissors };
                break;
            default:
                return 0;
        }

        if (wins.Contains(opponent))
        {
            return 6;
        }
        else if (loses.Contains(opponent))
        {
            return 0;
        }
        else if (ties.Contains(opponent))
        {
            return 3;
        }
        else
        {
            return 0;
        }
    }
}