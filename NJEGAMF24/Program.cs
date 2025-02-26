Console.ForegroundColor = ConsoleColor.Green;

const string DIR = "H:\\asztali\\NJEGAMF\\";

Console.WriteLine("1. feladat: ");

// 1. task (a part) ------------------------------------------------------------------------------------------------------------------------------------

// initialize an empty list to store the divisors of the number
List<int> divisors = [];

// number whose divisors we are finding
int num = 1310438493;

// variable to keep track of the good numbers found in the file
int goodNums = 0;

// find divisors of the number (from 1 up to the square root of the number)
for (int i = 1; i < Math.Sqrt(num); i++)
{
    // if i divides the number without a remainder, add it to the list of divisors
    if (num % i == 0)
    {
        divisors.Add(i);
    }
}

// read the file containing the numbers using a stream reader
using (StreamReader reader = new($"{DIR}\\szamok.txt"))
{
    // loop through each line in the file until the end
    while (!reader.EndOfStream)
    {
        // parse the current line as a long integer
        long line = long.Parse(reader.ReadLine());

        // counter to track how many divisors from the list are found for the current number
        int counter = 0;

        // check divisors of the current number (from 1 up to the square root of the number)
        for (long i = 1; i <= Math.Sqrt(line); i++)
        {
            // if i divides the current number without a remainder
            if (line % i == 0)
            {
                // check if i is one of the divisors of the original number
                if (divisors.ToHashSet().Contains((int)i))
                {
                    counter++;
                }
            }

            // if more than one divisor from the list is found, break early
            if (counter > 1)
            {
                break;
            }
        }

        // if exactly one divisor from the list was found, count it as a good number
        if (counter == 1)
        {
            goodNums++;
        }

        // reset the counter for the next number
        counter = 0;
    }
}

// print the number of good numbers found
Console.WriteLine($"A rész: {goodNums}");

// 1. task (b part) ------------------------------------------------------------------------------------------------------------------------------------

// input number as a string
string szam = "2354211341";

// convert the number string into a char array
char[] chars = szam.ToCharArray();
// sort the char array
Array.Sort(chars);

// initialize a variable to count the number of anagrams
int annagrams = 0;

// list to keep track of previously checked numbers to avoid duplicates
List<string> duplicates = [];

// open the file for reading using StreamReader
using (StreamReader reader = new($"{DIR}\\szamok.txt"))
{
    // loop through each line in the file
    while (!reader.EndOfStream)
    {
        // read the current line from the file
        string line = reader.ReadLine();

        // skip the line if it's already been processed (duplicate check)
        if (duplicates.ToHashSet<string>().Contains(line))
        {
            continue;
        }

        // add the line to the list of duplicates
        duplicates.Add(line);

        // convert the current line into a char array
        char[] charsLine = line.ToCharArray();
        // sort the char array of the current line
        Array.Sort(charsLine);

        // check if the sorted char arrays are the same, meaning it's an anagram
        if (chars.SequenceEqual(charsLine))
        {
            // increment the anagram counter
            annagrams++;
        }
    }
}

// output the number of anagrams found, subtract 1 to exclude the input number itself
Console.WriteLine($"B rész: {annagrams - 1}");

// 1. task (c part) ------------------------------------------------------------------------------------------------------------------------------------

// initialize an array to store the frequency of two-digit numbers (from 00 to 99)
int[] frequency = new int[100];

// open the file for reading using StreamReader
using (StreamReader sr = new($"{DIR}\\szamok.txt"))
{
    // variable to hold each line of the file
    string line;
    // loop through each line in the file
    while ((line = sr.ReadLine()) != null)
    {
        // iterate through each character in the line, except the last one
        for (int i = 0; i < line.Length - 1; i++)
        {
            // check if both current and next characters are digits
            if (char.IsDigit(line[i]) && char.IsDigit(line[i + 1]))
            {
                // calculate the two-digit number by combining the two characters
                int twoDigitNumber = (line[i] - '0') * 10 + (line[i + 1] - '0');
                // increment the frequency count for this two-digit number
                frequency[twoDigitNumber]++;
            }
        }
    }
}

// variable to store the most frequent two-digit number
int mostFrequent = 0;
// variable to store the maximum frequency
int maxFrequency = 0;

// loop through the frequency array to find the most frequent two-digit number
for (int i = 0; i < frequency.Length; i++)
{
    // if the current frequency is higher than the max, update the max and the most frequent number
    if (frequency[i] > maxFrequency)
    {
        maxFrequency = frequency[i];
        mostFrequent = i;
    }
}

// output the most frequent two-digit number
Console.WriteLine($"C rész: {mostFrequent}");

Console.WriteLine("\n----------------------------------------------------------------------------------\n");

// 2. task (a part) ------------------------------------------------------------------------------------------------------------------------------------

Console.WriteLine("2. feladat: ");

List<Varos> varosok = [];
List<Megye> megyek = [];


using (StreamReader sr = new($"{DIR}telepules.txt"))
{

    while (!sr.EndOfStream)
    {

        varosok.Add(new(sr.ReadLine()));

    }

}

using (StreamReader sr = new($"{DIR}megyek.txt"))
{

    while (!sr.EndOfStream)
    {

        megyek.Add(new(sr.ReadLine()));

    }

}

var f1 = varosok.GroupBy(v => v.Megye).OrderBy(g => g.Sum(v => v.Lakossag)).Skip(1).FirstOrDefault();
var megye = megyek.Where(m => m.MegyeKod.Equals(f1.Key)).FirstOrDefault();
Console.WriteLine($"A rész: {megye.MegyeNev}-{f1.Sum(l => l.Lakossag)}");

// 2. task (b part) ------------------------------------------------------------------------------------------------------------------------------------

var f2 = varosok.OrderByDescending(v => v.Szelesseg).FirstOrDefault();
Console.WriteLine($"B rész: {f2.Telepules}");

// 2. task (c part) ------------------------------------------------------------------------------------------------------------------------------------

var f3 = varosok.Where(k => k.SZTav <= 50 && k.KTav <= 50).Count();
Console.WriteLine($"C rész: {f3}");

// 2. task (d part) ------------------------------------------------------------------------------------------------------------------------------------

var f4 = varosok.Where(x => x.Szelesseg >= 47.3 && x.Szelesseg <= 47.4).OrderBy(x => x.Hosszusag).ToList();

string output = string.Empty;
double maxTeruletK = double.MinValue;

for (int i = 0; i < f4.Count - 1; i++)
{
    double teruletK = Math.Abs(f4[i].Terulet - f4[i + 1].Terulet);
    if (teruletK > maxTeruletK)
    {
        maxTeruletK = teruletK;
        output = $"{f4[i].Telepules}-{f4[i+1].Telepules}-{maxTeruletK:f2}";
    }
}

Console.WriteLine($"D rész: {output}");

// 2. task (e part) ------------------------------------------------------------------------------------------------------------------------------------

var f5 = varosok.Where(x => x.Telepules.ToLower().Contains("buda")).OrderBy(x => x.Hosszusag).Skip(2).First();
Console.WriteLine($"E rész: {f5.Telepules}");

// 2. task (f part) ------------------------------------------------------------------------------------------------------------------------------------

var f6 = varosok.Where(x => x.aetOrder).Count();
Console.WriteLine($"F rész: {f6}");
