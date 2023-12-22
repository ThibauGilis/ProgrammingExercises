string[] Menu = new string[] { "Rekening", "Spaarrekening", "Zichtrekening" };
for (int i = 0; i < Menu.Length; i++)
{
    Console.WriteLine($"{i}. {Menu[i]}");
}

Console.Write("Maak uw keuze: ");
int keuze = int.Parse(Console.ReadLine());
Console.Write("Geef een IBAN: ");
string iban = Console.ReadLine();

switch (keuze)
{
    case 1:
        Spaarrekening spaarrekening = new Spaarrekening(iban);
        Console.WriteLine(spaarrekening.ToonGegevens());
        break;

    case 2:
        Console.Write("Geef een saldo: ");
        int saldo = int.Parse(Console.ReadLine());
        Zichtrekening zichtrekening = new Zichtrekening(iban, saldo);
        Console.WriteLine(zichtrekening.ToonGegevens());

        bool IsGelukt = false;
        do
        {
            Console.Write("Hoeveel wilt je afhalen: ");
            double afhalen = double.Parse(Console.ReadLine());
            try
            {
                zichtrekening.Afhalen(afhalen);
                IsGelukt = true;
            }
            catch (SaldoOnderNulExeption ex)
            {
                Console.WriteLine($"FOUT... {ex.Message}");
            }
        } while (!IsGelukt);
        break;

    default:
        Console.WriteLine("ERROR");
        break;
}
