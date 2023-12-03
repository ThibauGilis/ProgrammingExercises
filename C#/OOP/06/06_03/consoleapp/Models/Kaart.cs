namespace consoleapp.Models;

public class Kaart
{
    private int _nummer;
    private string _soort;
    private string _kleur;

    public int Nummer
    {
        get { return _nummer; }
        set 
        { 
            if (value < 0)
            {
                _nummer = 0;
            }
            else if (value > 10) 
            { 
                _nummer = 10;
            }
            else
            {
                _nummer = value;
            }
        }
    }
    public string Soort
    {
        get { return _soort; }
        set { _soort = value;  }
    }
    public string Kleur
    {
        get { return _kleur; }
        set { _kleur = value; }
    }

    public Kaart(int nummer, string soort, string kleur)
    {
        this.Nummer = nummer;
        this.Soort = soort;
        this.Kleur = kleur;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Kaart kaart)
        {
            if (kaart.ToString() == this.ToString())
            {
                return true;
            }
        }

        return false;
    }
    public override string ToString()
    {
        return $"De kaart was van de kleur {this.Kleur} met een waarde van {this.Nummer} en {this.Soort} als soort.";
    }
}
