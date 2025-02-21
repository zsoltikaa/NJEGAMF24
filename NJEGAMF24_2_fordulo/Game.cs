class Game
{

    public string[] Moves { get; set; }
    public bool DidWhiteWin { get; }
    public int KnightMoves { get; }

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