class Game
{

    public string[] Moves { get; set; }
    public bool DidWhiteWin { get; }
    public int KnightMoves { get; }

    public int RemainingPieces 
    {
        get
        {
            return 32 - Moves.Count(x => x.Contains('x'));
        }
    }

    public bool DidQueenDie 
    {
        get 
        {
            var whiteMoves = Moves.Reverse().Where((x, i) => i % 2 == 0 && x.StartsWith('V'));
            var lastMoveWhite = whiteMoves.Count() == 0 ? "xdxdxd" : whiteMoves.First().TrimStart('V');
            var lastMoveBlack = Moves.Reverse().Where((x, i) => i % 2 != 0 && x.StartsWith('V')).First().TrimStart('V');
            foreach (var move in Moves)
            {
                if (move.EndsWith($"x{lastMoveWhite}") || move.EndsWith($"x{lastMoveBlack}"))
                {
                    return true;
                }
            }
            return false;
        }
    }

    public int QueenMoves 
    {
        get
        {
            string letters = "abcdefgh";
            var whiteQueenMoves = Moves.Where((x, i) => i % 2 == 0 && x.StartsWith('V'));
            var blackQueenMoves = Moves.Where((x, i) => i % 2 != 0 && x.StartsWith('V'));

            string lastBlackQueenMove = "Vd8";
            string lastWhiteQueenMove = "Vd1";
            int totalMoves = 0;

            foreach (var move in whiteQueenMoves)
            {
                if (move[^1..] == lastWhiteQueenMove[^1..])
                {
                    totalMoves += Math.Abs(letters.IndexOf(move[^2..^1]) - letters.IndexOf(lastWhiteQueenMove[^2..^1]));
                }
                else
                {
                    totalMoves += Math.Abs(int.Parse(move[^1..]) - int.Parse(lastWhiteQueenMove[^1..]));
                }
                lastWhiteQueenMove = move;
            }

            foreach (var move in blackQueenMoves)
            {
                if (move[^1..] == lastBlackQueenMove[^1..])
                {
                    totalMoves += Math.Abs(letters.IndexOf(move[^2..^1]) - letters.IndexOf(lastBlackQueenMove[^2..^1]));
                }
                else
                {
                    totalMoves += Math.Abs(int.Parse(move[^1..]) - int.Parse(lastBlackQueenMove[^1..]));
                }
                lastBlackQueenMove = move;
            }

            return totalMoves;


        }
    }

    public Game(string line)
    {

        Moves = line.Trim().Split('\t');

        foreach (var move in Moves)
        {
            if (move.StartsWith("H"))
            {
                KnightMoves += 4;
            }
        }

        DidWhiteWin = Moves.Length % 2 != 0;

    }

}