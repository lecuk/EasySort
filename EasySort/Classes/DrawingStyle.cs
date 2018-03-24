using System;
using System.Drawing;

namespace EasySort.Classes
{
    enum DrawingStyle
    {
        Default, Rainbow, DistanceBased, Monochrome, Custom
    }

    enum DrawingColor
    {
        Default, Selected, Swapped, Special
    }
    
    static class DrawingStyler
    {
        public static DrawingStyle style = DrawingStyle.Default;
        public static Color DefaultDefaultColor = Color.WhiteSmoke;
        public static Color DefaultSelectedColor = Color.Lime;
        public static Color DefaultSwappedColor = Color.Red;
        public static Color DefaultSpecialColor = Color.Magenta;
        
        public static Color CustomDefaultColor = DefaultDefaultColor;
        public static Color CustomSelectedColor = DefaultSelectedColor;
        public static Color CustomSwappedColor = DefaultSwappedColor;
        public static Color CustomSpecialColor = DefaultSpecialColor;

        public static Color GetColor(SortingArray array, int pos, DrawingColor color)
        {
            switch (color)
            {
                case DrawingColor.Default:
                    return GetDefaultColor(array, pos);
                case DrawingColor.Selected:
                    return GetSelectedColor(array, pos);
                case DrawingColor.Swapped:
                    return GetSwappedColor(array, pos);
                case DrawingColor.Special:
                    return GetSpecialColor(array, pos);
            }
            return Color.WhiteSmoke;
        }

        static Color GetDefaultColor(SortingArray array, int pos)
        {
            switch (style)
            {
                case DrawingStyle.Default:
                    return DefaultDefaultColor;
                case DrawingStyle.Rainbow:
                    return RainbowDefaultColor(array.Get(pos), array.Length - 1);
                case DrawingStyle.DistanceBased:
                    return DistanceDefaultColor(array.DistanceToSortedPosition(pos), array.Length);
                case DrawingStyle.Monochrome:
                    return Color.LightSlateGray;
                case DrawingStyle.Custom:
                    return CustomDefaultColor;
                default:
                    return Color.WhiteSmoke;
            }
        }

        static Color GetSelectedColor(SortingArray array, int pos)
        {
            switch (style)
            {
                case DrawingStyle.Default:
                    return DefaultSelectedColor;
                case DrawingStyle.Rainbow:
                    return RainbowSelectedColor(array.Get(pos), array.Length - 1);
                case DrawingStyle.DistanceBased:
                    return DistanceSelectedColor(array.DistanceToSortedPosition(pos), array.Length);
                case DrawingStyle.Monochrome:
                    return Color.LightGray;
                case DrawingStyle.Custom:
                    return CustomSelectedColor;
                default:
                    return Color.LightGray;
            }
        }

        static Color GetSwappedColor(SortingArray array, int pos)
        {
            switch (style)
            {
                case DrawingStyle.Default:
                    return DefaultSwappedColor;
                case DrawingStyle.Rainbow:
                    return RainbowSwappedColor();
                case DrawingStyle.DistanceBased:
                    return DistanceSwappedColor();
                case DrawingStyle.Monochrome:
                    return Color.White;
                case DrawingStyle.Custom:
                    return CustomSwappedColor;
                default:
                    return Color.LightGray;
            }
        }

        static Color GetSpecialColor(SortingArray array, int pos)
        {
            switch (style)
            {
                case DrawingStyle.Default:
                    return DefaultSpecialColor;
                case DrawingStyle.Rainbow:
                    return RainbowSpecialColor(array.Get(pos), array.Length - 1);
                case DrawingStyle.DistanceBased:
                    return DistanceSpecialColor();
                case DrawingStyle.Monochrome:
                    return Color.White;
                case DrawingStyle.Custom:
                    return CustomSpecialColor;
                default:
                    return Color.Gray;
            }
        }

        static Color RainbowDefaultColor(int val, int max)
        {
            float h = 360f * val / max;
            float s = 100;
            float v = 80f;
            return ColorFromHSV(h, s, v);
        }

        static Color RainbowSelectedColor(int val, int max)
        {
            float h = 360f * val / max;
            float s = 50f;
            float v = 100;
            return ColorFromHSV(h, s, v);
        }

        static Color RainbowSwappedColor()
        {
            return Color.White;
        }

        static Color RainbowSpecialColor(int val, int max)
        {
            float h = 360f * val / max;
            float s = 100f;
            float v = 100;
            return Negative(ColorFromHSV(h, s, v));
        }

        static Color DistanceDefaultColor(int distance, int maxDistance)
        {
            if (distance > 0)
            {
                int r = (int)(255.0 * distance / maxDistance);
                int g = Math.Max(0, 220 - r);
                int b = 0;
                return Color.FromArgb(r, g, b);
            }
            else
                return Color.Lime;
        }

        static Color DistanceSelectedColor(int distance, int maxDistance)
        {
            if (distance > 0)
                return Color.Yellow;
            else
                return Color.GreenYellow;
        }

        static Color DistanceSwappedColor()
        {
            return Color.White;
        }

        static Color DistanceSpecialColor()
        {
            return Color.Blue;
        }

        public static Color Negative(Color origin)
        {
            return Color.FromArgb(255 - origin.R, 255 - origin.G, 255 - origin.B);
        }

        //                                 0-360    0-100    0-100
        public static Color ColorFromHSV (float h, float s, float v)
        {
            h = Math.Max(0, Math.Min(h, 360));
            s = Math.Max(0, Math.Min(s, 100));
            v = Math.Max(0, Math.Min(v, 100));

            int i = (int)(h / 60) % 6;

            float Vmin = (100 - s) * v / 100;
            float a = (v - Vmin) * (h % 60) / 60;
            float Vinc = Vmin + a;
            float Vdec = v - a;

            float r = 0, g = 0, b = 0;
            switch (i)
            {
                case 0:
                    r = v;
                    g = Vinc;
                    b = Vmin;
                    break;
                case 1:
                    r = Vdec;
                    g = v;
                    b = Vmin;
                    break;
                case 2:
                    r = Vmin;
                    g = v;
                    b = Vinc;
                    break;
                case 3:
                    r = Vmin;
                    g = Vdec;
                    b = v;
                    break;
                case 4:
                    r = Vinc;
                    g = Vmin;
                    b = v;
                    break;
                case 5:
                    r = v;
                    g = Vmin;
                    b = Vdec;
                    break;
            }
            int rI = (int)(r / 100 * 255);
            int gI = (int)(g / 100 * 255);
            int bI = (int)(b / 100 * 255);

            return Color.FromArgb(rI, gI, bI);
        }
    }
}
