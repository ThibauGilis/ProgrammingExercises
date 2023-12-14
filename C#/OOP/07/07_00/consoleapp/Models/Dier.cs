namespace consoleapp.Models;

public abstract class Dier
{
    public abstract bool IsZoogdier
    {
        get;
    }

    public abstract string Voeren();
    public abstract string MaakGeluid();
    public string Slaap()
    {
        return "Zzz";
    }
}
