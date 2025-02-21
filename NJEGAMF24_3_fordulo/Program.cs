Console.ForegroundColor = ConsoleColor.Green;

const string DIR = "H:\\asztali\\NJEGAMF\\";

List<Message> messages = [];

Console.WriteLine("1. feladat:"); //------------------------------------------------------------------------------------------------------------------------------

using (StreamReader sr = new($"{DIR}uzenetek.txt"))
{
    while (!sr.EndOfStream)
    {
        messages.Add(new(sr.ReadLine()));
    }
}

Console.WriteLine($"A rész: {messages.Sum(x => x.Content.Where(x => x == '?' || x == '-').Count())}");

