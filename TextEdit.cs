using System.Runtime.Intrinsics.Arm;
using Microsoft.VisualBasic;

Menu();

static void Menu()
{
    Console.Clear();
    Console.WriteLine("What dou you want to do?");
    Console.WriteLine("1 - Open File");
    Console.WriteLine("2 - Edit File");
    Console.WriteLine("0 - Exit");
    short option = short.Parse(Console.ReadLine());

    switch (option)
    {
        case 1: OpenFile(); break;
        case 2: EditFile(); break;
        case 0: Environment.Exit(0); break;
        default: Menu(); break;
    }

    static void OpenFile()
    {
        Console.Clear();
        Console.WriteLine("qual o caminho do arquivo? ");
        var path = Console.ReadLine();
        using StreamReader file = new StreamReader(path);
        string text = File.ReadAllText(path);
        Console.WriteLine(text);
    }

    static void EditFile()
    {
        Console.Clear();
        Console.WriteLine("What do you want write? (ESC to Exit)");
        Console.WriteLine("----------------");
        string text = "";

        do
        {
            text += Console.ReadLine();
            text += Environment.NewLine;
        }
        while (Console.ReadKey().Key != ConsoleKey.Escape);

        SaveFile(text);

    }

    static void SaveFile(string text)
    {
        Console.Clear();
        Console.WriteLine("What your path?");
        var path = Console.ReadLine();

        using var file = new StreamWriter(path);
        file.Write(text);
        file.Close();

        Console.WriteLine($"Arquivo {path} salvo com sucesso");
        Console.ReadLine();
        Menu();
    }
}