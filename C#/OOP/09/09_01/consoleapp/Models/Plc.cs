namespace consoleapp.Models;

public class Plc
{
    private Licht _keukenLicht;
    private Licht _woonkamerLicht;
    private Verwarming _verwarming;

    public Licht KeukenLicht
    {
        get { return _keukenLicht; }
        set { _keukenLicht = value; }
    }
    public Licht WoonkamerLicht
    {
        get { return _woonkamerLicht; } 
        set { _woonkamerLicht = value; }
    }
    public Verwarming Verwarming
    {
        get { return _verwarming; } 
        set { _verwarming = value; }
    }

    public Plc(Licht keukenLicht, Licht woonkamerLicht, Verwarming verwarming)
    {
        this.KeukenLicht = keukenLicht;
        this.WoonkamerLicht = woonkamerLicht;
        this.Verwarming = verwarming;
    }

    public void DoeKeukenLichtAan()
    {
        this.KeukenLicht.AanUit = true;
    }
    public void DoeKeukenLichtUit()
    {
        this.KeukenLicht.AanUit = false;
    }
    public void DoeWoonkamerLichtAan()
    {
        this.WoonkamerLicht.AanUit = true;
    }
    public void DoeWoonkamerLichtUit()
    {
        this.WoonkamerLicht.AanUit = false;
    }
    public void ZetVerwarmingAan()
    {
        this.Verwarming.AanUit = true;
    }
    public void ZetVerwarmingUit()
    {
        this.Verwarming.AanUit = false;
    }
    public void PasTemperatuurAan(double temperatuur)
    {
        this.Verwarming.Graden = temperatuur;
    }
    public override string ToString()
    {
        return $"Keukenlicht: {(this.KeukenLicht.AanUit? "Aan": "Uit")}\nWoonkamerlicht: {(this.WoonkamerLicht.AanUit ? "Aan" : "Uit")}\nVerwarming: {(this.Verwarming.AanUit ? "Aan" : "Uit")}\nTemperatuur: {this.Verwarming.Graden}";
    }

}
