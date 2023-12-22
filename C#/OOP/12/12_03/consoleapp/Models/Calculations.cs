namespace consoleapp.Models;

public static class Calculations
{
    public static double DivideNumbers(double dividend, double divisor)
    {
        if (divisor == 0) throw new DivideByZeroException();
        return dividend / divisor;
    }
    public static double CalculateSquareRoot(double number)
    {
        if (number < 0) throw new ArithmeticException();
        return Math.Sqrt(number);
    }
}
