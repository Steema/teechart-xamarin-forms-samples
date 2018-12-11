using Android.Graphics;
using Android.Widget;
using System;
using System.Linq;
using WeatherApp;
using WeatherApp.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ResolutionGroupName ("MyCompany")]
[assembly:ExportEffect (typeof(LabelShadowEffect), "LabelShadowEffect")]
namespace WeatherApp.Droid
{
	public class LabelShadowEffect : PlatformEffect
	{
		protected override void OnAttached ()
		{
			try {
				var control = Control as Android.Widget.TextView;
				var effect = (WeatherApp.Effects.LabelShadowEffect)Element.Effects.FirstOrDefault (e => e is WeatherApp.Effects.LabelShadowEffect);
				if (effect != null) {
					float radius = effect.Radius;
					float distanceX = effect.DistanceX;
					float distanceY = effect.DistanceY;
					Android.Graphics.Color color = effect.Color.ToAndroid ();
					control.SetShadowLayer (radius, distanceX, distanceY, color);
				}
			} catch (Exception ex) {
				Console.WriteLine ("Cannot set property on attached control. Error: ", ex.Message);
			}
		}

		protected override void OnDetached ()
		{
		}

    }
}