
Console.Write("Enter the first number: ");
double number1 = double.Parse(Console.ReadLine());
Console.Write("Enter the second number: ");
double number2 = double.Parse(Console.ReadLine());

try
{
	double result = Calculations.DivideNumbers(number1, number2);
    double root = Calculations.CalculateSquareRoot(result);
    Console.WriteLine($"Result: {result}\nSquare root: {root}");
}
catch (DivideByZeroException)
{
    Console.WriteLine("Error: Division by zero is not allowed.");
}
catch (ArithmeticException)
{
    Console.WriteLine("Arithmetic Error: Cannot calculate square root of a negative number.");
}
catch (FormatException ex)
{
    Console.WriteLine(ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}