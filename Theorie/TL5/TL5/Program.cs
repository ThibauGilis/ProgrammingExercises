
//Declaratie
string activiteit, invoer, smsAntwoord;
bool benJeVrij;
DateTime datumUurActiviteit;

//Schermkleuren aanpassen
Console.BackgroundColor = ConsoleColor.White;
Console.ForegroundColor = ConsoleColor.DarkBlue;
Console.Clear();
Console.Title = "Voorbeeld 1 - " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();

//inlezen
Console.WriteLine("Ontvvangen SMS-bericht\n");

do
{
    Console.Write("\tVoor welke activitet kreeg je een sms-bericht? ");
    activiteit = Console.ReadLine();
} while (string.IsNullOrWhiteSpace(activiteit));

do
{
    do
    {
        Console.Write("\tGeef datum en uur dat \"{0}\" zal doorgaan? ", activiteit);
        invoer = Console.ReadLine();
    } while (DateTime.TryParse(invoer, out datumUurActiviteit) == false);
} while (datumUurActiviteit < DateTime.Now);

do
{
    Console.Write("\tBen je vrij op {0} ('true' of 'false')? ", datumUurActiviteit);
    invoer = Console.ReadLine();
} while (!bool.TryParse(invoer, out benJeVrij));

// bewerking uitvoeren
if (benJeVrij == true)
{
    smsAntwoord = "Ik zal er zijn! ";
}
else
{
    smsAntwoord = "Spijtig, het zal voor een andere keer zijn!";
}

//resultaat tonen
Console.WriteLine("\n\tOp {0} om {1} - {2}", datumUurActiviteit.ToLongDateString(), datumUurActiviteit.ToShortTimeString(), smsAntwoord);