// See https://aka.ms/new-console-template for more information
using PNGppSkript.Compilator;

Console.WriteLine("Hello, World!");

Constructor t = new Constructor();
List<string> list = new List<string>();
string FilePath = Console.ReadLine();

list.AddRange(File.ReadAllLines(filepath));