namespace consoleapp.Models;

public class Vierkant
{
    private int _zijde;

    public int Zijde
    {
        get { return _zijde; }
        set 
        {
            if (value < 0)
            {
                _zijde = 0;
            }
            else if (value > 25)
            {
                _zijde = 25;
            }
            else
            {
                _zijde = value;
            }
        }
    }

    public Vierkant()
    {
        this.Zijde = 0;
    }

    public Vierkant(int lengte)
    {
        this.Zijde = lengte;
    }


    public double Diagonaal()
    { 
        return Math.Round(Math.Sqrt(2 * Math.Pow(this.Zijde, 2)), 2);
    }

    public int Oppervlakte()
    {
        return this.Zijde*this.Zijde;
    }

    public int Omtrek()
    {
        return 4 * this.Zijde;
    }

    public string Teken()
    {
        string uitvoer = "";
        for (int i = 0; i < this.Zijde; i++)
        {
            for (int j = 0; j < this.Zijde; j++)
            {
                uitvoer += "*";
                if (j < this.Zijde - 1)
                {
                    uitvoer += " ";
                }
            }

            if (i<this.Zijde-1)
            {
                uitvoer += "\n";
            }
        }
        return uitvoer;
    }
}
