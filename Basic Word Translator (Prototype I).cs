using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    public static Dictionary<string, string> Words = new Dictionary<string, string>();

    static void Main()
    {
        LoadWords();
        Home();
    }

    static void LoadWords()
    {
        string path = "C:\\Users\\Furkan\\Desktop\\words.txt";
        if (File.Exists(path))
        {
            foreach (var line in File.ReadLines(path))
            {
                var parts = line.Split(':');
                if (parts.Length == 2)
                {
                    Words[parts[0].Trim().ToLower()] = parts[1].Trim(); // Küçük harf ile
                }
            }
        }
    }

    static void Home()
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("--------------------------------------------------------------------------------------------");
        Console.WriteLine("|         ______           ____   __ _______ _       __          __        _               |");
        Console.WriteLine("|        |  ____|         / __ \\ / _|__   __| |      \\ \\        / /       | |              |");
        Console.WriteLine("|        | |__ _   _ _ __| |  | | |_   | |  | |__   __\\ \\  /\\  / /__  __ _| | __           |");
        Console.WriteLine("|        |  __| | | | '__| |  | |  _|  | |  | '_ \\ / _ \\ \\/  \\/ / _ \\/ _` | |/ /           |");
        Console.WriteLine("|        | |  | |_| | |  | |__| | |    | |  | | | |  __/\\  /\\  /  __/ (_| |   <            |");
        Console.WriteLine("|        |_|   \\__,_|_|   \\____/|_|    |_|  |_| |_|\\___| \\/  \\/ \\___|\\__,_|_|\\_\\           |");
        Console.WriteLine("|                                  Turkish - English Translate                             |");
        Console.WriteLine("|                                         By Furkan Gül                                    |");
        Console.WriteLine("--------------------------------------------------------------------------------------------");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
        Mode();
    }

    static void Mode()
    {
        while (true)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("|   [0] Home Page                              |");
            Console.WriteLine("|   [1] Translate from Turkish to English      |");
            Console.WriteLine("|   [2] Translate from English to Turkish      |");
            Console.WriteLine("|   [3] Add new word                           |");
            Console.WriteLine("|   [4] Quit                                   |");
            Console.WriteLine("------------------------------------------------");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("     Mode: ");
            if (int.TryParse(Console.ReadLine(), out int mod))
            {
                Console.Clear();
                switch (mod)
                {
                    case 0:
                        Home();
                        break;
                    case 1:
                        TurkishtoEnglish();
                        break;
                    case 2:
                        EnglishtoTurkish();
                        break;
                    case 3:
                        AddWord();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }
    }

    static void AddWord()
    {
        Console.Write("Enter Turkish Word: ");
        string turkishWord = Console.ReadLine();
        Console.Write("Enter English Word: ");
        string englishWord = Console.ReadLine();

        if (!Words.ContainsKey(turkishWord.ToLower()))
        {
            Words[turkishWord.ToLower()] = englishWord;
            File.AppendAllText("C:\\Users\\Furkan\\Desktop\\words.txt", $"{turkishWord}:{englishWord}\n");
            Console.WriteLine("Word added successfully.");
        }
        else
        {
            Console.WriteLine("This word already exists.");
        }
    }

    static void TurkishtoEnglish()
    {
        Console.Write("Enter Turkish word: ");
        string turkishWord = Console.ReadLine().ToLower();
        if (Words.TryGetValue(turkishWord, out string englishTranslation))
        {
            Console.WriteLine($"English translation: {englishTranslation}");
        }
        else
        {
            Console.WriteLine("Word not found.");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    static void EnglishtoTurkish()
    {
        Console.Write("Enter English word: ");
        string englishWord = Console.ReadLine().ToLower();
        string turkishTranslation = Words.FirstOrDefault(x => x.Value.ToLower() == englishWord).Key;
        if (turkishTranslation != null)
        {
            Console.WriteLine($"Turkish translation: {turkishTranslation}");
        }
        else
        {
            Console.WriteLine("Word not found.");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
