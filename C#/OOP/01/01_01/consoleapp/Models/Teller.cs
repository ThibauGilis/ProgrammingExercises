namespace consoleapp.Models;

public class Teller
{
    private int _waarde;

    public int Waarde
    {
        get { return _waarde; }
        set { _waarde = value; }
    }

    public Teller()
    {
        this.Waarde = 0;
    }

    public void Verhoog()
    {
        this.Waarde++;
    }
    public void Verlaag() 
    {
        this.Waarde--;
    }
    public void Resetten() 
    {
        this.Waarde = 0;
    }
    public string ToonGegevens()
    {
        return $"De waarde van de teller is {this.Waarde}.";
    }
}
