namespace System.Drawing
{
    class ColorApi
    {
        public static Color FromHEX(int rgb) { return Color.FromArgb(255, (rgb & 0xff0000) >> 16, (rgb & 0xff00) >> 8, (rgb & 0xff)); }
    }
}
