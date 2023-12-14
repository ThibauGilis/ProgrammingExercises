namespace consoleapp.Models;

public static class FileOperations
{
    public static double BerekenStroomsterkte(double spanning, double weerstand)
    {
        return spanning / weerstand;
    }
    public static double BerekenSpanning(double stroomsterkte, double weerstand)
    {
        return stroomsterkte * weerstand;
    }
    public static double BerekenWeerstand(double spanning, double stroomsterkte)
    {
        return spanning / stroomsterkte;
    }
    public static double BerekenVermogen(double spanning, double stroomsterkte)
    {
        return spanning * stroomsterkte;
    }
}
