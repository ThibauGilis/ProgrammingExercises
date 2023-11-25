namespace consoleapp.Models;

public class Punt
{
    private double _x;
    private double _y;
    private string _omschrijving;

    public double X 
    {
        get { return _x; }
        set { _x = value; }
    }
    public double Y 
    {
        get { return _y; }
        set { _y = value; }
    }
    public string Omschrijving
    {
        get { return _omschrijving; }
        set { _omschrijving = value; }
    }

    public Punt()
    {
        this.X = 0;
        this.Y = 0;
        Omschrijving = $"{this.GetType().Name} :coord=({this.X},{this.Y})";
    }
    public Punt(double x, double y)
    {
        this.X=x; 
        this.Y=y;
        Omschrijving = $"{this.GetType().Name} :coord=({this.X},{this.Y})";
    }

    public virtual string ToonGegevens()
    {
        return this.Omschrijving;
    }
}
