namespace consoleapp.Models;

public class Zwembad
{
    private double _breedte;
    private double _diepte;
    private double _lengte;
    private double _randafstand;

    public double Breedte 
    {
        get { return _breedte; } 
        set 
        {
            if (value < 0) value = 0;
            _breedte = value;
        } 
    }
    public double Diepte 
    {
        get { return _diepte; } 
        set 
        {
            if (value < 0) value = 0;
            _diepte = value; 
        } 
    }
    public double Lengte 
    {
        get { return _lengte; } 
        set 
        {
            if (value < 0) value = 0;
            _lengte = value; 
        } 
    }
    public double Randafstand 
    {
        get { return _randafstand; } 
        set 
        {   if (this.Diepte < value) value = 0;
            if (value < 0) value = 0;
            _randafstand = value; 
        } 
    }

    public Zwembad(double breedte, double lengte, double diepte, double randafstand) 
    {
        this.Breedte = breedte;
        this.Lengte = lengte;
        this.Diepte = diepte;
        this.Randafstand = randafstand;
    }

    public string ToonGegevens()
    {
        return $"Diepte = {this.Diepte}\nBreedte = {this.Breedte}\nLengte = {this.Lengte}\nRandafstand = {this.Randafstand}\n\nLiters water = {this.LiterWater()}.";
    }

    public double LiterWater()
    {
        return this.Breedte * this.Lengte * (this.Diepte - this.Randafstand) * 1000;
    }

}

