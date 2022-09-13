// See https://aka.ms/new-console-template for more information
using System;
using System.IO;

// Part 1

Console.WriteLine("Enter your goal for today:");
Console.WriteLine("--------------------------");

var input = Console.ReadLine();

Console.WriteLine($"\n[For {DateTime.Now.ToString("dddd, MMMM dd, yyyy")} Your Goal Is:]\n");
var goal = (input.Length < 256) ? input : input.Substring(0, 256);
Console.WriteLine($"\"{goal}\"");
Console.Write("\n[Save Changes(Y/n)] ");
ConsoleKey response = Console.ReadKey(false).Key;

// string path = @"C:\Users\ITUStudent\dev\Intro-To-Programming-Sept-2022\Goals\Goals\goals.txt";
// string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\dev\Intro-To-Programming-Sept-2022\Goals\Goals\goals.txt";
string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\goals.txt";

if (response.Equals(ConsoleKey.Enter) || response.Equals(ConsoleKey.Y)) 
{
    if (!File.Exists(path))
    {
        using (StreamWriter sw = File.CreateText(path))
        {
            sw.WriteLine(goal);
        }
    }
    else
    {
        using (StreamWriter sw = File.AppendText(path))
        {
            sw.WriteLine(goal);
        }
    }
}


// Part 2

Console.Write("\n\n[View Previous Entries? (Y/n)] ");
ConsoleKey response1 = Console.ReadKey(false).Key;
if (response1.Equals(ConsoleKey.Enter) || response1.Equals(ConsoleKey.Y))
{
    using (StreamReader sr = File.OpenText(path))
    {
        Console.WriteLine("\n");
        string s = "";
        while ((s = sr.ReadLine()) != null)
        {
            Console.WriteLine(s);
        }
    }
}

// Part 3

// Part 4



