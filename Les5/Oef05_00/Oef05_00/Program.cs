int tijd = 0;
double hoeveelheid;

do
{
    Console.Write("Hoeveelheid koffie (mg): ");
} while (double.TryParse(Console.ReadLine(), out hoeveelheid) == false);


do
{
    hoeveelheid /= 2;
    tijd += 5;
} while (hoeveelheid >= 1);

Console.WriteLine("Totale tijd: {0} uur", tijd);