using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Drawing;
using PNGppSkript.Api;

namespace PNGppSkript.Decompiler
{
    class Decompiler
    {
        private List<Color> pixels = new List<Color>();
        public void DecompilPNGtoFile(string fromPngFile, string toTextFile)
        {
            List<string> lines = new List<string>();
            PNGtoPixels(fromPngFile);
            PixelsToStringList(ref lines);
            SaveToFile(in lines, toTextFile);
        }

        public string DecompilPNGtoString(string fromPngFile)
        {
            List<string> lines = new List<string>();
            PNGtoPixels(fromPngFile);
            PixelsToStringList(ref lines);
            string code = "";
            foreach (string l in lines)
            {
                code += l;
            }
            return code;
        }

        private void SaveToFile(in List<string> strings, string toFile)
        {
            try
            {
                StreamWriter sw = new StreamWriter(toFile);

                foreach (string l in strings)
                {
                    sw.WriteLine(l);
                }

                sw.Close();
            }
            catch (Exception e) { }
        }

        private void PNGtoPixels(string nameFile)
        {
            Color _c;
            using (Bitmap image = new Bitmap(nameFile))
            {
                for (int y = 0; y < image.Height; y++)
                {
                    for (int x = 0; x < image.Width; x++)
                    {
                        _c = image.GetPixel(x, y);
                        if (_c.A == 255)
                        {
                            pixels.Add(_c);
                        }
                    }
                }
            }
        }

        private void PixelsToStringList(ref List<string> lines)
        {
            string line = "";
            for (int i = 0; i < pixels.Count; i++)
            {
                line = "unexist command";

                if (pixels[i] == ColorsT.Int)
                {
                    line = "addInt ";
                    line += BitConverter.ToInt32(getBytes(ref i, 2, true, false, true)); //[pixels[++i].R, pixels[i].B, pixels[++i].R, pixels[i].B]
                }
                else if (pixels[i] == ColorsT.Byte)
                {
                    line = "addByte ";
                    line += getBytes(ref i, 1, true, false, false)[0];
                }
                else if (pixels[i] == ColorsT.Double)
                {
                    line = "addDouble ";
                    line += BitConverter.ToDouble(getBytes(ref i, 4, false, true, true)).ToString();
                }
                else if (pixels[i] == ColorsT.String)
                {
                    line = "addString ";
                    byte[] t = getBytesString(ref i);
                    line += Encoding.Unicode.GetString(t);
                }
                lines.Add(line);
            }
        }

        private byte[] getBytes(ref int from, int countPixel, bool r, bool g, bool b)
        {
            List<byte> bytes = new List<byte>();
            int t = from;
            for (from++; from < t + countPixel+1; from++)
            {
                if (r) bytes.Add(pixels[from].R);
                if (g) bytes.Add(pixels[from].G);
                if (b) bytes.Add(pixels[from].B);
            }
            from--;

            return bytes.ToArray();
        }

        private byte[] getBytesString(ref int i)
        {
            List<byte> bytes = new List<byte>();
            for (i++;pixels[i] != ColorsT.EndString;i++)
            {
                bytes.Add(pixels[i].R);
                bytes.Add(pixels[i].G);
            }
            return bytes.ToArray();
        }
    }
}
