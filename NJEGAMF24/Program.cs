const string DIR = "H:\\c#\\cli\\NJEGAMF24\\";

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