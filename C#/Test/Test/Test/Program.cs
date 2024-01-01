Console.BackgroundColor = ConsoleColor.Black;
Console.ForegroundColor = ConsoleColor.White;

// ░▒▓█

int size = 60;
string box = new string('▒', size);
for  (int i = 0; i < 5; i++)
{
    box += "\n" + "▒▒" + new string(' ', size-4) + "▒▒";
}
box += "\n" + new string('▒', size);

Console.WriteLine(box);

Console.BackgroundColor = ConsoleColor.Gray;
Console.ForegroundColor = ConsoleColor.Black;
Console.SetCursorPosition(2, 1);
for (int i = 0; i < 5; i++)
{
    Console.WriteLine(new string(' ', size - 4));
    Console.CursorLeft = 2;
}

Console.SetCursorPosition(4, 2);
Console.Write("Charmander");

Console.BackgroundColor = ConsoleColor.DarkRed;
Console.ForegroundColor = ConsoleColor.White;
Console.CursorLeft += 4;
Console.Write(" Fire ");

Console.BackgroundColor = ConsoleColor.Gray;
Console.ForegroundColor = ConsoleColor.Black;
Console.SetCursorPosition(size-10, 2);
Console.WriteLine("Lv: 16");

Console.BackgroundColor = ConsoleColor.DarkGray;

Console.SetCursorPosition(4, 4);
Console.Write(" HP:" + new string(' ',40));

Console.ForegroundColor = ConsoleColor.Green;
Console.SetCursorPosition(9, 4);
Console.Write(new string('▬', 38));

Console.BackgroundColor = ConsoleColor.Gray;
Console.ForegroundColor = ConsoleColor.Black;

Console.CursorLeft += 3;
Console.Write("70/70");

Console.SetCursorPosition(50, 50);