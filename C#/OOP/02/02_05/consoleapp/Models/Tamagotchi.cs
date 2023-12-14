namespace consoleapp.Models;

public class Tamagotchi
{
    private int _goedGevoel;
    private int _honger;
    private DateTime _laatsteMaaltijd;
    private string _naam;

    public int GoedGevoel
    {
        get { return _goedGevoel; }
        set 
        {
            if (value < -10)
            {
                value = -10;
            }
            else if (value > 10)
            {
                value = 10;
            }

            _goedGevoel = value;
        }
    }
    public int Honger
    {
        get { return _honger; }
        set
        {
            if (value < -5)
            {
                value = -5;
            }
            else if (value > 20)
            {
                value = 20;
            }

            _honger = value;
        }
    }
    public DateTime LaatsteMaaltijd
    {
        get { return _laatsteMaaltijd; }
        set { _laatsteMaaltijd = value; }
    }
    public string Naam
    {
        get { return _naam; }
        set { _naam = value; }
    }

    public Tamagotchi(string naam)
    {
        this.Naam = naam;
        this.Honger = 20;
        this.GoedGevoel = 10;
        this.LaatsteMaaltijd = DateTime.Now;
    }
    public Tamagotchi(string naam, int eenHonger, int eenGevoel)
    {
        this.Naam = naam;
        this.Honger = eenHonger;
        this.GoedGevoel = eenGevoel;
        this.LaatsteMaaltijd = DateTime.Now;
    }

    public void Eten(int eenheden)
    {
        if (eenheden < 0)
        {
            eenheden = 0;
        }
        else if (eenheden > 3)
        {
            eenheden = 3;
        }

        this.Honger += eenheden;
        this.LaatsteMaaltijd = DateTime.Now;
    }
    public void LiefKozen()
    {
        this.GoedGevoel++;
    }
    public void Straffen(int eenheden)
    {
        this.GoedGevoel -= eenheden;
    }
    public string Gevoel()
    {
        if (this.GoedGevoel > 0)
        {
            this.GoedGevoel--;
        }

        string seconden = ((DateTime.Now - this.LaatsteMaaltijd).TotalSeconds/30).ToString();
        this.Honger -= int.Parse(seconden);

        return $"{this.Naam} voelt zich {this.GoedGevoel} en heeft {this.Honger}";
    }
}
