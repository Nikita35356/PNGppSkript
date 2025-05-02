// See https://aka.ms/new-console-template for more information
using PNGppSkript.Compilator;

Console.WriteLine("Hello, World!22");

Constructor t = new Constructor();
t.AddByte(22);
t.AddVoid();
t.AddString("скомпилировал Console.WriteLine(\"Hello,World!\");");
t.AddVoid();
t.AddInt(1);
t.DebugGenerate("C:\\Users\\COMP\\Documents\\csProjects\\PNGppSkript\\PNGppSkript\\test.png");