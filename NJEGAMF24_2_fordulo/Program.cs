Console.ForegroundColor = ConsoleColor.Green;

const string DIR = "H:\\asztali\\NJEGAMF\\";

Console.WriteLine("1. feladat: \n");

string f1(int start, int end)
{

    string current = start.ToString();

    for (int i = 1; i <= end; i++)
    {

        string next = "";

        foreach (char digit in current)
        {
            int doubledDigit = (digit - '0') * 2;
            next += doubledDigit.ToString();
        }

        current = next;
    }

    return current;

}

// 1. task (a part) --------------------------------------------------------------------------------------------------------------------------------------------------

Console.WriteLine($"A rész: {f1(1, 21)}\n");

// 1. task (b part) --------------------------------------------------------------------------------------------------------------------------------------------------

int f2 (int start)
{

    string current = start.ToString();

    for (int i = 1; i <= 30; i++)
    {

        string next = "";
        foreach (char digit in current)
        {
            int doubledDigit = (digit - '0') * 2;
            next += doubledDigit.ToString();
        }

        current = next;

        if (current.Length > 27 && current[^27..] == "216816212162121681684816816")
        {
            return start;
        }

    }

    return -1;

}

for (int i = 10; i <= 99; i++)
{
    int res = f2(i);
    if (res != -1)
    {
        Console.WriteLine($"B rész: {res}\n");
        break;
    }
}

// 1. task (c part) --------------------------------------------------------------------------------------------------------------------------------------------------

string f3(int start, int end)
{

    string current = start.ToString();

    for (int i = 1; i < end; i++)
    {
        current += current.Sum(x => x - '0');
    }

    return current;

}

Console.WriteLine($"C rész: {f3(11, 31)}");

// 2. task (a part) --------------------------------------------------------------------------------------------------------------------------------------------------

Console.WriteLine("\n-------------------------------------------------------------------------------------------------------\n");

Console.WriteLine("2. feladat: \n");

List<Game> games = [];

using (StreamReader reader = new($"{DIR}jatszmak.txt"))
{

    while (!reader.EndOfStream)
    {
        games.Add(new(reader.ReadLine()));
    }

}

var fe1 = string.Empty;

foreach (var game in games)
{
    fe1 += game.DidWhiteWin ? 'v' : 's';
}

Console.WriteLine($"A rész: {fe1}\n");

// 2. task (b part) --------------------------------------------------------------------------------------------------------------------------------------------------

var fe2 = games.Sum(x => x.KnightMoves);
Console.WriteLine($"B rész: {fe2}\n");

// 2. task (c part) --------------------------------------------------------------------------------------------------------------------------------------------------

string result = string.Empty;

for (int i = 0; i < games.Count; i++)
{
    if (games[i].DidQueenDie)
    {
        result += $"{i+1};";
    }
}

Console.WriteLine($"C rész: {result.TrimEnd(';')}\n");

// 2. task (d part) --------------------------------------------------------------------------------------------------------------------------------------------------

Console.WriteLine($"D rész: {games.Sum(x => x.QueenMoves)}\n");

// 2. task (e part) --------------------------------------------------------------------------------------------------------------------------------------------------

int count = 0;
foreach (var game in games)
{
    count += game.Moves.Where((_, i) => i % 2 == 0).Count(x => x.StartsWith('K') || x.StartsWith('O')) == 0 ? 1 : 0;
}

Console.WriteLine($"E rész: {count}\n");

// 2. task (f part) --------------------------------------------------------------------------------------------------------------------------------------------------

Console.WriteLine($"F rész: {games.Count(x => x.RemainingPieces > 20)}");