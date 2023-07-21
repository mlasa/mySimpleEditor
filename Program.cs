using System;
using System.IO;

//My file: C:\Users\Marce\Desktop\myTextEditor\hello.txt 

namespace myTextEditor;
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("myTextEditor with C# - Marcella A.\r\n\r\n");
        Menu();
    }

    static void Menu()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("1 - Edit file");
        Console.WriteLine("2 - Open file");
        Console.WriteLine("0 - Exit\r\n");

        Console.ForegroundColor = ConsoleColor.White;

        try
        {
            short option = short.Parse(Console.ReadLine());

            while (option != 1 && option != 2 && option != 3 && option != 0)
            {
                Console.WriteLine("~Please select a valid option~\r\n");
                option = short.Parse(Console.ReadLine());
            }

            Console.ForegroundColor = ConsoleColor.Blue;

            switch (option)
            {
                case 1:
                    {
                        Edit(); break;
                    }
                case 2:
                    {
                        Open(); break;
                    }
                default:
                    {
                        Console.WriteLine("\r\n\r\n See ya!");
                        Environment.Exit(0);
                        break;
                    }
            }
        }
        catch
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Error.WriteLine("\r\nError:\r\nSorry, check if all the entered data was correct\r\n");
            Console.ForegroundColor = ConsoleColor.White;
            Menu();
        }
    }

    static void Edit()
    {
        string text = "";

        Console.WriteLine("Where is the file?");
        Console.ForegroundColor = ConsoleColor.White;
        string path = Console.ReadLine();

        text += Get(path);

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\r\nEditing file ... \r\n\r\n(key ESC to stop writing) \r\nType your text:");


        Console.ForegroundColor = ConsoleColor.White;
        do
        {
            //armazenar oque o usuario esta digitando
            text += Console.ReadLine();
            text += Environment.NewLine;
        }
        while (Console.ReadKey().Key != ConsoleKey.Escape);

        Save(text, path);
        Menu();
    }

    static void Open()
    {
        Console.WriteLine("\r\nOpening file ...");

        Console.WriteLine("Where is the file?");
        Console.ForegroundColor = ConsoleColor.White;
        string path = Console.ReadLine();

        try
        {
            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Here you are:\r\n");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(text);
            }
        }
        catch
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Error.WriteLine("Error: Possible wrong path");
            Console.ForegroundColor = ConsoleColor.White;
            Environment.Exit(0);
        }

        Menu();
    }
    static void Save(string text, string pathSaved = "")
    {
        var path = "";

        Console.WriteLine("\r\nSaving ...");
        if (pathSaved == "")
        {
            Console.WriteLine("Where do you want to save?");
            path = Console.ReadLine();
        }
        else path = pathSaved;

        using (var file = new StreamWriter(path))
        {
            file.Write(text);
        }


        //Console.Clear();
        //Console.WriteLine("\r\nSaved!");

        Menu();
    }
    static string Get(string path)
    {
        string text = "";
        try
        {
            using (var file = new StreamReader(path))
            {
                text = file.ReadToEnd();
            }
        }
        catch
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Error.WriteLine("Error: Possible wrong path");
            Console.ForegroundColor = ConsoleColor.White;
            Environment.Exit(0);
        }

        return text;
    }
}
