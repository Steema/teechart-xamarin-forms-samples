using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamControls.Droid.Renderer;

[assembly: ExportRenderer(typeof(XamControls.CustomRenders.SliderRenderer), typeof(MySliderRenderer))]
namespace XamControls.Droid.Renderer
{

	public class MySliderRenderer : SliderRenderer
	{
		public MySliderRenderer(Context context) : base(context)
		{
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Slider> e)
		{

			base.OnElementChanged(e);

			e.NewElement.ThumbColor = Color.FromHex("0B8DF9");
			e.NewElement.MaximumTrackColor = Color.FromHex("303030");
			e.NewElement.MinimumTrackColor = Color.FromHex("0B8DF9");

		}

	}
}