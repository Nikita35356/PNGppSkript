using System.Text;



namespace PNGppSkript.Compilator
{
    class Constructor
    {
        private List<String> list = new List<String>();
        private List<object?> args = new List<object?>();
        private int maxWidth = 1;

        private void AddStep(String name, object? v, int width)
        {
            list.Add(name);
            args.Add(v);
            if (width > maxWidth) maxWidth = width;
        }

        public void AddString(String v) { AddStep("String",v,Encoding.Unicode.GetBytes(v).Length/2+2); }

        public void AddInt(int v) { AddStep("Int", v, 3);}

        public void AddVoid() { AddStep("Void", null, 1); }

        public void AddDouble(double v) { AddStep("Double", v, 5); }

        public void AddByte(byte v) { AddStep("Byte", v, 2); }

        public void DebugGenerate(string toFile)
        {
            Generator.DebugGenerateAndSave(list, args, maxWidth, toFile);
        }
    }
}
