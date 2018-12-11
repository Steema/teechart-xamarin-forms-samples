using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WeatherApp.Effects
{
    public class LabelShadowEffect : RoutingEffect
    {

        public LabelShadowEffect() : base("MyCompany.LabelShadowEffect")
        {
        }

        public float Radius { get; set; }

        public Color Color { get; set; }

        public float DistanceX { get; set; }

        public float DistanceY { get; set; }

    }
}
