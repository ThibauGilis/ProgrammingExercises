int raampassagiers = 0, passagiers = 0;
string invoer = "";

do
{
    do
    {
        Console.Write("Wil je aan het raam zitten (Y/N)? ");
        invoer = Console.ReadLine();
    } while (invoer != "Y" && invoer != "N");
    if (invoer == "Y")
    {
        raampassagiers++;
    }
    passagiers++;
} while (raampassagiers < 4 && passagiers < 8);

Console.WriteLine($"Er zijn {passagiers} passagiers. {raampassagiers} zitten er aan het raam.");