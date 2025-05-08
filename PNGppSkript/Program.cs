// See https://aka.ms/new-console-template for more information
using System.Text;
using PNGppSkript.Compilator;
using PNGppSkript.Decompiler;

List<string> list = new List<string>();
//Specify the path to your file
string file = "exit.txt";
list.AddRange(File.ReadAllLines(file));
Constructor t = new Constructor();

foreach (string s in list)
{
    t.AddString(s);
    t.DebugGenerate("./tt.png");
}


Console.ReadLine();