class Megye
{
    public string MegyeKod {get; set;}
    public string MegyeNev {get; set;}

    public Megye(string line)
    {

        string[] sl = line.Split('\t');

        MegyeKod = sl[0];
        MegyeNev = sl[1];

    }

}
