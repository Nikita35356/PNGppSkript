// See https://aka.ms/new-console-template for more information
using PNGppSkript.Compilator;
using PNGppSkript.Decompiler;

Console.WriteLine("Hello, World!1234567");

Constructor t = new Constructor();

Console.WriteLine("бебебе");

t.AddByte(2);
t.AddVoid();
t.AddString("hello");
t.AddDouble(3.000978);
t.DebugGenerate("./tt.png");

Decompiler d = new Decompiler();
d.DecompilPNGtoFile("./tt.png", "./exit.txt");
d.DecompilPNGtoString("./tt.png");