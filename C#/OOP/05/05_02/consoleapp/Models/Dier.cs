namespace consoleapp.Models;

public class Dier
{
    private string _naam;
    public string Naam 
    {
        get { return _naam; }
        set { _naam = value; }
    }
    public virtual string Gegevens
    {
        get { return $"Mijn naam is {this.Naam} en ik ben een {this.GetType().Name}."; }
    }

    protected Dier(string naam)
    {
        this.Naam = naam;
    }
    public virtual string Praten(string zin)
    {
        return "";
    }
    public virtual string Strelen()
    {
        return "";
    }
    public override string ToString()
    {
        return this.Gegevens;
    }
    public override bool Equals(object? obj)
    {
        if (!(obj is Dier dier))
        {
            return false;
        }

        return dier.Naam == this.Naam;
    }
}
