using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using PNGppSkript.Api;

namespace PNGppSkript.Compilator
{
    class Generator
    {
        public static void DebugGenerateAndSave(List<string> list, List<object?> args, int maxWidth, string toFile)
        {
            using (Bitmap image = new Bitmap(maxWidth, list.Count))
            {
                string n = "";

                for (int y = 0; y < list.Count; y++)
                {
                    n = list[y];

                    if (n.Equals("String"))
                    {
                        image.SetPixel(0, y, ColorsT.String);
                        byte[] b = Encoding.Unicode.GetBytes((string) args[y]);
                        for (int i = 0; i < b.Length / 2; i++)
                        {
                            image.SetPixel(i + 1, y, Color.FromArgb(b[i * 2], b[(i * 2) + 1], 0));
                        }
                        image.SetPixel(b.Length / 2 + 1, y, ColorsT.EndString);
                    }
                    else if (n.Equals("Int"))
                    {
                        image.SetPixel(0, y, ColorsT.String);
                        byte[] b = BitConverter.GetBytes((int)args[y]);
                        for (int i = 0; i < b.Length / 2; i++)
                        {
                            image.SetPixel(i + 1, y, Color.FromArgb(b[i * 2], 0, b[(i * 2) + 1]));
                        }
                    }
                    else if (n.Equals("Double"))
                    {
                        image.SetPixel(0, y, ColorsT.Double);
                        byte[] b = BitConverter.GetBytes((double)args[y]);
                        for (int i = 0; i < b.Length / 2; i++)
                        {
                            image.SetPixel(i + 1, y, Color.FromArgb(0, b[i * 2], b[(i * 2) + 1]));
                        }
                    }
                    else if (n.Equals("Byte"))
                    {
                        image.SetPixel(0, y, ColorsT.Byte);
                        image.SetPixel(1, y, Color.FromArgb(255, (int)((byte)args[y]), 0, 0));
                    }
                }
                image.Save(toFile, ImageFormat.Png);
                image.Dispose();
            }
        }
    }
}
