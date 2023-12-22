
void PrintTrainers(List<Trainer> Menu)
{
    Console.WriteLine();
    for (int i = 0; i < Menu.Count; i++)
    {
        Console.WriteLine($"{i+1}. {Menu[i]}");
    }
    Console.WriteLine();
}
void PrintVoetbalspelers(List<Voetbalspeler> Menu)
{
    Console.WriteLine();
    for (int i = 0; i < Menu.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {Menu[i]}");
    }
    Console.WriteLine();
}
int KeuzeTrainers(string vraag, List<Trainer> Menu)
{
    int keuze;
	do
	{
        Console.Write(vraag);
    } while (!int.TryParse(Console.ReadLine(), out keuze) || keuze < 1 || keuze > Menu.Count);
    return keuze-1;
}
int KeuzeVoetbalspeler(string vraag, List<Voetbalspeler> Menu)
{
    int keuze;
    do
    {
        Console.Write(vraag);
    } while (!int.TryParse(Console.ReadLine(), out keuze) || keuze < 1 || keuze > Menu.Count);
    return keuze - 1;
}

//-------------------------------------------------------------------------------------

List<Trainer> trainers = FileOperations.LeesTrainers();
List<Voetbalspeler> spelers = FileOperations.LeesSpelers();

PrintTrainers(trainers);
Trainer trainer = trainers[KeuzeTrainers("Kies een trainer: ", trainers)];
Team team = new Team(trainer, new List<Voetbalspeler>());

PrintVoetbalspelers(spelers);
while (team.AantalSpelers<11)
{
    Voetbalspeler speler = spelers[KeuzeVoetbalspeler("Kies een speler: ", spelers)];
    team.VoegSpelerToe(speler);
}

Console.WriteLine();
Console.WriteLine(team);
