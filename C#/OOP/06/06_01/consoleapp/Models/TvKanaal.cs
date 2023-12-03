namespace consoleapp.Models;

public class TvKanaal
{
    private int _nummer;
    private string _omschrijving;

    public int Nummer
    {
        get { return _nummer; }
        set { _nummer = value; }
    }
    public string Omschrijving
    {
        get { return _omschrijving; } 
        set { _omschrijving = value; }
    }

    public TvKanaal()
    {
        this.Nummer = 0;
        this.Omschrijving = "";
    }
    public TvKanaal(int nummer, string omschrijving)
    {
        this.Nummer = nummer;
        this.Omschrijving = omschrijving;
    }

    public override string ToString()
    {
        return $"Nummer van het kanaal is {this.Nummer}";
    }
}
