// See https://aka.ms/new-console-template for more information
using PNGppSkript.Compilator;

namespace Program
{
    class Starter
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!1234567");

            Constructor t = new Constructor();

            Console.WriteLine("sys");

            t.AddByte(2);
            t.DebugGenerate("C:\\Users\\COMP\\source\\repos\\Nikita35356\\PNGppSkript\\PNGppSkript\\ttt.png");


            Thread hidePrintThread = new Thread(IDE.Program.Start);
            hidePrintThread.SetApartmentState(ApartmentState.STA);
            hidePrintThread.Start();

            Console.
        }
    }
}


