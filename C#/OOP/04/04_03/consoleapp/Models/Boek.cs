namespace consoleapp.Models;

public class Boek
{
    private string _titel;
    private string _auteur;

    public string Titel
    {
        get { return _titel; }
        set { _titel = value; }
    }
    public string Auteur
    {
        get { return _auteur; }
        set { _auteur = value; }
    }

    public Boek(string titel, string auteur)
    {
        Titel = titel;
        Auteur = auteur;
    }

    public virtual string ToonGegevens()
    {
        return $"Het boek {this.Titel} van {this.Auteur}";
    }
}
