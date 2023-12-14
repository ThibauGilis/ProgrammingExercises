namespace consoleapp.Models;

public class Motor
{
    private int _cilinderinhoud;
    private int _pk;

    public int Cilinderinhoud
    {
        get { return _cilinderinhoud; }
        set { _cilinderinhoud = value; }
    }
    public int Pk
    {
        get { return _pk; }
        set { _pk = value; }
    }

    public Motor(int cilinderinhoud, int pk)
    {
        this.Cilinderinhoud = cilinderinhoud;
        this.Pk = pk;
    }

    public override string ToString()
    {
        return $"Cilinderinhoud: {this.Cilinderinhoud} - Pk: {this.Pk}";
    }


}
