namespace consoleapp.Models;

public class Bankrekening
{
    private string _ibanNummer;
    private string _landCode;
    private double _minimum;
    private double _saldo;

    public string IbanNummer
    {
        get { return _ibanNummer; }
        set { _ibanNummer = value; }
    }
    public string LandCode
    {
        get { return _landCode; }
        set { _landCode = value; }
    }
    public double Minimum
    {
        get { return _minimum; }
        set { _minimum = value; }
    }
    public double Saldo
    {
        get { return _saldo; }
        set { _saldo = value; }
    }

    public Bankrekening(string ibanNummer, double saldo)
    {
        this.IbanNummer = ibanNummer;
        this.LandCode = this.IbanNummer.Substring(0,2);
        this.Saldo = saldo;
    }

    public void Afhalen(double bedrag)
    {
        if (this.Saldo-bedrag < this.Minimum)
        {
            throw new SaldoOnderNulExeption(this.Saldo, this.Minimum);
        }
    }
    public void Storten(double bedrag)
    {
        this.Saldo += bedrag;
    }
    public virtual string ToonGegevens()
    {
        return $"Rekening {this.IbanNummer} met saldo {this.Saldo}";
    }
}
