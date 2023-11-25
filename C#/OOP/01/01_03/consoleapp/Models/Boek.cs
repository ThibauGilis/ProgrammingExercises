namespace consoleapp.Models;

public class Boek
{
    private string _titel;
    private string _auteur;
    private double _bladzijden;

    public string Titel
    {
        get { return _titel; } set { _titel = value; }
    }
    public string Auteur
    {
        get { return _auteur; } set { _auteur = value; }
    }
    public double Bladzijden
    {
        get { return _bladzijden; } set { _bladzijden = value; }
    }

    public Boek()
    {
        this.Titel = "";
        this.Auteur = "";
        this._bladzijden = 0;
    }

    public string ToonGegevens(int BladzijdenPerDag)
    {
        return $"Het boek {this.Titel} van {this.Auteur} zou {Math.Ceiling(this.Bladzijden/BladzijdenPerDag)} dagen duren om uit te lezen.";
    }
}
