namespace consoleapp.Models;

public class Winkel
{
    private string _voornaam;
    private string _familienaam;
    private double _uurloon;

    public string Voornaam
    {
        get { return _voornaam; } 
        set { _voornaam = value; }
    }
    public string Familienaam
    {
        get { return _familienaam; }
        set { _familienaam = value; }
    }
    public double Uurloon
    {
        get { return _uurloon; }
        set { _uurloon = value; }
    }

    public Winkel(string voornaam, string familienaam, double uurloon)
    {
        this.Voornaam = voornaam;
        this.Familienaam = familienaam;
        this.Uurloon = uurloon;
    }

    public virtual double Loon()
    {
        return this.Uurloon * 40 * 4; // 40 uur per week, 4 weken
    }
    public override string ToString()
    {
        return $"{this.Voornaam} {this.Familienaam} verdient {this.Loon()} euro per maand.";
    }
}
