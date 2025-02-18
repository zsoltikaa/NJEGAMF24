class Varos
{

    public string Iranyitoszam { get; set; }
    public string Megye { get; set; }
    public double Szelesseg { get; set; }
    public double Hosszusag { get; set; }
    public double Terulet { get; set; }
    public int Lakossag { get; set; }
    public string Telepules { get; set; }
    public int KTav { get; set; }
    public int SZTav { get; set; }

    public Varos(string line)
    {

        string[] sl = line.Split(' ');

        Iranyitoszam = sl[0];
        Megye = sl[1];
        Szelesseg = double.Parse(sl[2].Replace('.', ','));
        Hosszusag = double.Parse(sl[3].Replace('.', ','));
        Terulet = double.Parse(sl[4].Replace('.', ','));
        Lakossag = int.Parse(sl[5]);
        Telepules = sl[6];
        KTav = int.Parse(sl[7]);
        SZTav = int.Parse(sl[8]);

    }

}