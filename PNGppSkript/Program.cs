// See https://aka.ms/new-console-template for more information
using PNGppSkript.Compilator;
using PNGppSkript.Decompiler;

Console.WriteLine("Ты попался на кликбейт");

Constructor t = new Constructor();

Console.WriteLine("бебебе");

t.AddByte(2);
t.AddVoid();
t.AddString("hello");
t.AddDouble(3.000978);
t.DebugGenerate("./tt.png");

Decompiler d = new Decompiler();
d.DecompilPNGtoFile("./tt.png", "./exit.txt");
Console.WriteLine(d.DecompilPNGtoString("./tt.png"));
Console.ReadLine();