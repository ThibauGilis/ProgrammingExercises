namespace consoleapp.Models;

public class Student
{
    private string _naam;
    private double _punten;

    public string Naam
    {
        get { return _naam; }
        set { _naam = value; }
    }
    public double Punten
    { 
        get { return _punten; }
        set { _punten = value; }
    }
    public string Resultaat
    {
        get
        {
            if (this.Punten <50)
            {
                return "Niet Geslaagd!";
            }
            else
            {
                return "Geslaagd!";
            }
        }
    }

    public Student(): this("", 0)
    {

    }
    public Student(string naam, double punten)
    {
        this.Naam = naam;
        this.Punten = punten;
    }

    public override string ToString()
    {
        return $"{this.Naam}\t{this.Punten.ToString("0.00")}\t{this.Resultaat}";
    }
}
