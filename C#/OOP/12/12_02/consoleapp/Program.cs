
int PrintMenu(string[] menu)
{
    Console.WriteLine();
    for (int i = 0; i < menu.Length; i++)
    {
        Console.WriteLine($"{i + 1}. {menu[i]}");
    }
    Console.WriteLine();

    return LeesKeuze(menu);
}
void PrintProducten(List<Product> menu)
{
    for (int i = 0; i < menu.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {menu[i]}");
    }
    Console.WriteLine();
}
int LeesKeuze(string[] menu)
{
    int keuze;
    do
    {
        Console.Write("Geef uw keuze: ");
    } while (!int.TryParse(Console.ReadLine(), out keuze) || keuze < 1 || keuze > menu.Length);
    Console.WriteLine();
    return keuze;
}

//------------------------------------------------------

string[] Menu = new string[] { "Stripboek toevoegen", "Knuffel toevoegen", "Producten tonen", "Afsluiten" };
List<Product> producten = FileOperations.LeesProducten();

int keuze = PrintMenu(Menu);
while (keuze != 4)
{
    Product product = null;
    switch (keuze)
    {
        case 1:
            try
            {
                Console.Write("Geef naam: ");
                string naam = Console.ReadLine();
                Console.Write("Geef prijs: ");
                double.TryParse(Console.ReadLine(), out double prijs);
                Console.Write("Geef auteur: ");
                string auteur = Console.ReadLine();
                Console.Write("Geef aantal paginas: ");
                int.TryParse(Console.ReadLine(), out int aantalPaginas);

                product = new Stripboek(naam, prijs, auteur, aantalPaginas);
                if (producten.Contains(product)) throw new ProductBestaatReedsException();
                producten.Add(product);
            }
            catch (LegeTekstueleWaardeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NumeriekeWaardeOnderNulException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ProductBestaatReedsException)
            {
                Console.WriteLine(new ProductBestaatReedsException());
            }
            break;

        case 2:
            try
            {
                Console.Write("Geef naam: ");
                string naam = Console.ReadLine();
                Console.Write("Geef prijs: ");
                double.TryParse(Console.ReadLine(), out double prijs);
                Console.Write("Geef lengte: ");
                double.TryParse(Console.ReadLine(), out double lengte);
                Console.Write("Geef breedte: ");
                double.TryParse(Console.ReadLine(), out double breedte);
                Console.Write("Geef hoogte: ");
                double.TryParse(Console.ReadLine(), out double hoogte);

                product = new Knuffel(naam, prijs, lengte, breedte, hoogte);
                if (producten.Contains(product)) throw new ProductBestaatReedsException();
                producten.Add(product);
            }
            catch (LegeTekstueleWaardeException ex)
            {
                Console.WriteLine(new LegeTekstueleWaardeException(ex.Message));
            }
            catch (NumeriekeWaardeOnderNulException ex)
            {
                Console.WriteLine(new NumeriekeWaardeOnderNulException(ex.Message));
            }
            catch (ProductBestaatReedsException)
            {
                Console.WriteLine(new ProductBestaatReedsException());
            }
            break;

        case 3:
            PrintProducten(producten);
            break;
    }

    keuze = PrintMenu(Menu);
}
