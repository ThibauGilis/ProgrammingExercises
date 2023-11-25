namespace consoleapp.Models;

public class Televisie
{
    private int _kanaal;
    private int _volume;

    public int Kanaal
    {
        get { return _kanaal; }
        set 
        {
            if (1 <= value && value <= 30)
            {
                _kanaal = value;
            }
        }
    }
    public int Volume
    {
        get { return _volume; }
        set 
        {
            if (0 <= value && value <= 10)
            {
                _volume = value;
            }
        }
    }

    public Televisie() 
    {
        this.Kanaal = 1;
        this.Volume = 5;
    }

    public string ToonGegevens()
    {
        return $"Huidige configuratie: Kanaal: {this.Kanaal} - Volume: {this.Volume}";
    }
    public void VermeerderKanaal()
    {
        this.Kanaal++;
    }
    public void VerminderKanaal()
    {
        this.Kanaal--;
    }
    public void VermeerderVolume()
    {
        this.Volume++;
    }
    public void VerminderVolume()
    {
        this.Volume--;
    }
}
