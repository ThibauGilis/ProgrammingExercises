namespace consoleapp.Models;

public class Auto
{
    private double _brandstof;
    private int _huidigStand;
    private int _kilometerStand;

    public double Brandstof
    {
        get { return _brandstof; }
        set 
        { 
            if (value < 0)
            {
                _brandstof = 0;
            }
            else if (60 < value)
            {
                _brandstof = 60;
            }
            else
            {
                _brandstof = value;
            }
        }
    }
    public int HuidigStand
    {
        get { return _huidigStand; }
        set
        {
            if (value < 0)
            {
                _huidigStand = 0;
            }
            else
            {
                _huidigStand = value;
            }
        }
    }
    public int KilometerStand
    {
        get { return _kilometerStand; }
        set
        {
            if (value < 0)
            {
                _kilometerStand = 0;
            }
            else
            {
                _kilometerStand = value;
            }
        }
    }

    public Auto()
    {
        this.Brandstof = 0;
        this.HuidigStand = 0;
        this.KilometerStand = 0;
    }
    public Auto(double brandstof, int huidigStand, int kilometerStand)
    {
        this.Brandstof=brandstof;
        this.HuidigStand=huidigStand;
        this.KilometerStand=kilometerStand;
    }

    public void ToonGegevens()
    {
        bool check = true;

        Console.WriteLine("\nStatus\n------");
        if (this.Brandstof < 10)
        {
            Console.WriteLine("Voeg brandstof toe aub!");
            check = false;
        }
        if (24999 < this.HuidigStand-this.KilometerStand)
        {
            Console.WriteLine("Er is dringend onderhoud nodig!");
            check = false;
        }
        if (check)
        {
            Console.WriteLine("De auto is volledig in orde!");
        }
    }
}
