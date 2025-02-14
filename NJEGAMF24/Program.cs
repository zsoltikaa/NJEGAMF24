const string DIR = "H:\\c#\\cli\\NJEGAMF24\\";

// 1. feladat (a rész) ------------------------------------------------------------------------------------------------------------------------------------

List<int> osztok = [];

int num = 1310438493;

int goodNums = 0;

for (int i = 1; i < Math.Sqrt(num); i++)
{
    if (num % i == 0)
    {
        osztok.Add(i);
    }
}

using (StreamReader stream = new StreamReader($"{DIR}\\szamok.txt"))
{
    while (!stream.EndOfStream)
    {

        long line = long.Parse(stream.ReadLine());
        int counter = 0;

        for (long i = 1; i <= Math.Sqrt(line); i++)
        {
            if (line % i == 0)
            {
                if (osztok.ToHashSet().Contains((int)i))
                {
                    counter++;
                }
            }

            if (counter > 1)
            {
                break;
            }
        }
        if (counter == 1)
        {
            goodNums++;
        }
        counter = 0;
    }

}

Console.WriteLine($"A rész: {goodNums}");

// 1. feladat (b rész) ------------------------------------------------------------------------------------------------------------------------------------

string szam = "2354211341";

char[] chars = szam.ToCharArray();
Array.Sort(chars);

int annagrams = 0;

List<string> duplicates = [];

using (StreamReader sr = new($"{DIR}\\szamok.txt"))
{
    while (!sr.EndOfStream)
    {
        string line = sr.ReadLine();

        if (duplicates.ToHashSet<string>().Contains(line))
        {
            continue;
        }

        duplicates.Add(line);

        char[] charsLine = line.ToCharArray();
        Array.Sort(charsLine);

        if (chars.SequenceEqual(charsLine))
        {
            annagrams++;
        }
    }
}
Console.WriteLine($"B rész: {annagrams - 1}");

// 1. feladat (c rész) ------------------------------------------------------------------------------------------------------------------------------------

