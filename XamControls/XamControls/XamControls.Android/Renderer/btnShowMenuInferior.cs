using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using XamControls.CustomRenders;
using XamControls.Droid.Renderer;
using Android.Content;
using Android.Graphics;
using Android.Widget;
using Android.Support.Design.Widget;

[assembly: ExportRenderer(typeof(CustomButtonShowMenuInferior), typeof(CustomButtonRenderer))]
namespace XamControls.Droid.Renderer
{
	public class CustomButtonRenderer : ButtonRenderer
	{

		Android.Widget.Button floatingButton;
		Context context;

		public CustomButtonRenderer(Context context) : base(context)
		{

			this.context = context;

		}

		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
		{
			base.OnElementChanged(e);
			if (e.OldElement == null)
			{

				floatingButton = new Android.Widget.Button(context);

				floatingButton = (Android.Widget.Button) FindViewById(Resource.Layout.floatingButton);
				
			}
		}
	}
}

/*
[assembly: ExportRenderer(typeof(CustomButtonShowMenuInferior), typeof(btnShowMenuInferior))]
namespace XamControls.Droid.Renderer
{
	
	public class btnShowMenuInferior : ButtonRenderer
	{
		
		private Context context;
		private Android.Widget.Button buttonAndroid;

		public btnShowMenuInferior(Context context) : base(context)
		{

			this.context = context;

		}

		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
		{

			base.OnElementChanged(e);
			
			if(Control != null)
			{
				
				buttonAndroid = Control;
				buttonAndroid = new Android.Widget.Button(context);
				SetNativeControl(buttonAndroid);
				buttonAndroid.SetTextColor(Android.Graphics.Color.White);
				buttonAndroid.SetBackgroundColor(Android.Graphics.Color.Red);
				

				Control.SetBackgroundResource(Resource.Drawable.buttonr)

			}

			if (e.OldElement != null)
			{

				return;

			}
			
			if (e.NewElement != null) { return; }

			

		}

				


	}
}
	*/