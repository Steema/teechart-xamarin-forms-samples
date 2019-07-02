using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamControls.PCL.Utils
{
    public static class Helpers
    {
        public static int EnumItemsCount(Type enumeration)
        {
            int itemsCount = System.Enum.GetNames(enumeration).Length;
            return itemsCount;
        }

        public static string GetDrawableResource(string path)
        {
            string device = Xamarin.Forms.Device.RuntimePlatform;
            string fullPath = path;
            switch (device)
            {
                case Device.UWP:
                    fullPath = "Assets/" + path;
                    break;
            }
            return fullPath;
        }

        public static Style GetStyleResource(string key)
        {
            Style style = null;
            if (App.Current.Resources.TryGetValue(key, out var objectstyle))
            {
                style = (Style)objectstyle;
            }
            return style;
        }

        public static Color GetColorResource(string key)
        {
            Color color = default(Color);
            if (App.Current.Resources.TryGetValue(key, out var objectcolor))
            {
                color = (Color)objectcolor;
            }
            return color;
        }

        public static double GetDimenResource(string key)
        {
            Double dimen = default(double);
            if (App.Current.Resources.TryGetValue(key, out var objectdimen))
            {
                dimen = (double)objectdimen;
            }
            return dimen;
        }

    }
}
