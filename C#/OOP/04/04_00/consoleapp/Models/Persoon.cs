namespace consoleapp.Models;

public class Persoon
{
    private string _voornaam;
    private string _achternaam;

    public string Voornaam
    {
        get { return _voornaam; }
        set { _voornaam = value; }
    }
    public string Achternaam
    {
        get { return _achternaam; }
        set { _achternaam = value; }
    }

    protected Persoon(string voornaam, string achternaam)
    {
        this.Voornaam = voornaam;
        this.Achternaam = achternaam;
    }

    public virtual string ToonGegevens()
    {
        return $"Mijn naam is {this.Voornaam} {this.Achternaam}";
    }
}
