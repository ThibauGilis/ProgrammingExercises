namespace consoleapp.Models;

public class Bmi
{
    private double _gewicht;
    private double _lengte;
    private string _naam;

    public double Gewicht 
    {
        get { return _gewicht; } 
        set {  _gewicht = value; }
    }
    public double Lengte
    {
        get { return _lengte; } 
        set { _lengte = value; }
    }
    public string Naam
    {
        get { return _naam; }
        set { _naam = value; }
    }

    public Bmi()
    {
        this.Gewicht = 0.0;
        this.Lengte = 0.0;
        this.Naam = "";
    }
    public Bmi(string name, double weight, double length)
    {
        this.Gewicht = weight;
        this.Lengte = length;
        this.Naam = name;
    }

    public double BerekenBmi()
    {
        return Math.Round(this.Gewicht / Math.Pow(this.Lengte, 2), 1);
    }
    public string ToonGegevens()
    {
        return $"{this.Naam} weegt {this.Gewicht} kg en is {this.Lengte} m groot. De BMI is {this.BerekenBmi()}.";
    }
}
