namespace consoleapp.Models;

public static class FileOperations
{
    public static string BestandProducten = "productlijst.txt";
    public static string BestandFouten = "foutenbestand.txt";

    public static List<Product> LeesProducten()
    {
        List<Product> products = new List<Product>();
        StreamReader reader = new StreamReader(BestandProducten);

        while (!reader.EndOfStream)
        {
            try
            {
                Product product = null;

                string[] data = reader.ReadLine().Split(';');
                string type = data[0];
                string naam = data[1];
                double prijs = double.Parse(data[2]);

                try
                {
                    switch (type)
                    {
                        case "Stripboek":
                            string auteur = data[3];
                            int aantalPaginas = int.Parse(data[4]);
                            product = new Stripboek(naam, prijs, auteur, aantalPaginas);
                            break;

                        case "Knuffel":
                            double lengte = double.Parse(data[3]);
                            double breedte = double.Parse(data[4]);
                            double hoogte = double.Parse(data[5]);
                            product = new Knuffel(naam, prijs, lengte, breedte, hoogte);
                            break;
                    }

                    if (!products.Contains(product))
                    {
                        products.Add(product);
                    }
                }
                catch (Exception ex)
                {
                    FoutLoggen(ex);
                }
            }
            catch (Exception ex)
            {
                FoutLoggen(ex);
                return null;
            }
        }

        return products;
    }
    public static void FoutLoggen(Exception fout)
    {
        StreamWriter writer = new StreamWriter(BestandFouten, true);
        writer.WriteLine($"{fout.GetType()}\n{fout.Message}\n{fout.StackTrace}");
    }
}
