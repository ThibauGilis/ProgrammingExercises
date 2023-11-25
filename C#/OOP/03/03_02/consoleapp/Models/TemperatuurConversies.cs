namespace consoleapp.Models;

static public class TemperatuurConversies
{
    static public double ConverteerNaarGradenCelsius(double gradenFahrenheit)
    {
        return (gradenFahrenheit - 32) * 5 / 9;
    }
    static public double ConverteerNaarGradenFahrenheit(double gradenCelsius)
    {
        return (gradenCelsius * 9 / 5) + 32;
    }
}
