namespace consoleapp.Models;

public class Auto
{
    private string _nummerplaat;
    private double _aantalKilometers;
    private double _kostPrijs;
    private double _literBrandstof;

    protected string Merk
    {
        get { return this.GetType().Name; }
    }
    protected string Nummerplaat
    {
        get { return _nummerplaat; }
        set { _nummerplaat = value; }
    }
    protected double AantalKilometers
    {
        get { return _aantalKilometers; }
        set { _aantalKilometers = value; }
    }
    protected double KostPrijs
    {
        get { return _kostPrijs; }
        set { _kostPrijs = value; }
    }
    protected double LiterBrandstof
    {
        get { return _literBrandstof; }
        set { _literBrandstof = value; }
    }

    protected Auto(string nummerplaat, double aantalKilometers, double kostPrijs, double literBrandstof)
    {
        this.Nummerplaat = nummerplaat;
        this.AantalKilometers = aantalKilometers;
        this.KostPrijs = kostPrijs;
        this.LiterBrandstof = literBrandstof;
    }

    public override string ToString()
    {
        return $"Ik ben een {this.Merk} met nummerplaat {this.Nummerplaat} ({this.AantalKilometers} km - {this.LiterBrandstof} liter)\nKostprijs: {this.KostPrijs} euro";
    }
    public override bool Equals(object? obj)
    {
        if (!(obj is Auto auto))
        {
            return false;
        }
        return auto.Nummerplaat == this.Nummerplaat;
    }
    public virtual void Rijden(double aantalKilometer)
    {
        this.AantalKilometers += aantalKilometer;
        this.LiterBrandstof -= aantalKilometer/20;
    }
}
