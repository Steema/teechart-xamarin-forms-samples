using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamControls.Components;
using XamControls.Droid.Renderer;

[assembly: ExportRenderer(typeof(XamControls.Components.LinearLayout), typeof(linearLayout))]
namespace XamControls.Droid.Renderer
{
	public class linearLayout : ViewRenderer<Components.LinearLayout, Android.Widget.LinearLayout>
	{
		public linearLayout(Context context) : base(context)
		{



		}

		protected override void OnElementChanged(ElementChangedEventArgs<Components.LinearLayout> e)
		{
				base.OnElementChanged(e);

				if(e.NewElement != null)
				{

						if(Control == null)
						{



						}

				}

				

		}

	}
}